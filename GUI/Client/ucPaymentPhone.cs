using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit;
using BLL.Services;
using DTO.Models;

namespace GUI.Client
{
    public partial class ucPaymentPhone : UserControl
    {
        // 1. Khai báo tầng Service để xử lý nghiệp vụ
        private PaymentService _paymentService = new PaymentService();

        // 2. Các biến kiểm soát trạng thái máy (State Machine)
        private decimal _selectedAmount = 0;
        private int _paymentStep = 1;         // 1: Chọn mệnh giá, 2: Nhập mật khẩu/Số tiền khác
        private bool _isCustomAmount = false; // Đánh dấu nếu chọn ô "Số khác"
        private KryptonTextBox _selectedKryptonBox = null; // Lưu lại ô đang chọn để highlight

        // 3. Cầu nối Delegate dùng để quay lại màn hình chính Payments
        public Action<UserControl> NavigateTo { get; set; }

        public ucPaymentPhone()
        {
            InitializeComponent();
            this.Load += ucPaymentPhone_Load;
        }

        private void ucPaymentPhone_Load(object sender, EventArgs e)
        {
            cboProvider.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadBalanceUI();

            // Đổ dữ liệu các nhà mạng Điện thoại (ServiceTypeID = 4)
            cboProvider.DataSource = _paymentService.GetProviders(4);

            // 🌟 1. Gọi hàm tự động vẽ 6 ô mệnh giá vào Panel bạn đã tạo
            GenerateAmountOptions();

            // Bắt đầu ở Trạng thái 1: Chọn số điện thoại & Mệnh giá
            SetPaymentState(1);

            // Tải danh sách các số điện thoại đang chờ nạp
            LoadPendingInvoices(4);
        }

        /// <summary>
        /// Hàm tự động vẽ 6 ô KryptonTextBox bo góc vào trong pnlAmountSelection
        /// </summary>
        private void GenerateAmountOptions()
        {
            if (pnlAmountSelection == null) return;
            pnlAmountSelection.Controls.Clear();

            string[] amounts = { "10,000 VND", "20,000 VND", "50,000 VND", "100,000 VND", "200,000 VND", "Số khác (VND)" };
            string[] names = { "card10k", "card20k", "card50k", "card100k", "card200k", "cardOther" };

            int padding = 10;
            int boxWidth = (pnlAmountSelection.Width - (padding * 4)) / 3;
            int boxHeight = 40;

            for (int i = 0; i < 6; i++)
            {
                int row = i / 3;
                int col = i % 3;

                // 1. Tạo Group làm khung bo góc
                KryptonGroup card = new KryptonGroup();
                card.Name = names[i];
                card.Size = new Size(boxWidth, boxHeight);
                card.Location = new Point(padding + col * (boxWidth + padding), padding + row * (boxHeight + padding));
                card.Cursor = Cursors.Hand;

                // Cấu hình bo góc cho Group
                card.StateCommon.Border.Rounding = 8;
                card.StateCommon.Border.Color1 = Color.LightGray;
                card.StateCommon.Border.Width = 1;
                card.StateCommon.Back.Color1 = Color.White;

                // 2. Tạo Label đặt bên trong Group
                Label lbl = new Label();
                lbl.Text = amounts[i];
                lbl.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
                lbl.Dock = DockStyle.Fill; // Lệnh này ép Label tự động phình to lấp đầy 100% khoảng trống bên trong khung
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BackColor = Color.Transparent; // Để hiện màu nền của Group

                // 3. Sự kiện Click vào Group hoặc Label đều như nhau
                card.Click += KryptonGroupAmount_Click;
                lbl.Click += KryptonGroupAmount_Click;
                card.Panel.Click += KryptonGroupAmount_Click;

                card.Panel.Controls.Add(lbl);
                pnlAmountSelection.Controls.Add(card);
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi người dùng nhấp vào 1 trong 6 ô mệnh giá
        /// </summary>
        private KryptonGroup _selectedGroup = null; // Biến này lưu khung đang được chọn

        private void KryptonGroupAmount_Click(object sender, EventArgs e)
        {
            // Tìm cái Group (nếu người dùng lỡ bấm vào Label, parent của nó chính là Group)
            KryptonGroup clickedGroup = (sender is KryptonGroup) ? (KryptonGroup)sender : (KryptonGroup)((Control)sender).Parent.Parent;

            // Tẩy màu cũ
            if (_selectedGroup != null) _selectedGroup.StateCommon.Back.Color1 = Color.White;

            // Tô màu mới
            _selectedGroup = clickedGroup;
            _selectedGroup.StateCommon.Back.Color1 = Color.LightCyan;

            // Logic lấy tiền
            if (_selectedGroup.Name == "cardOther")
            {
                _isCustomAmount = true;
                _selectedAmount = 0;
            }
            else
            {
                _isCustomAmount = false;
                string rawNumber = ((Label)_selectedGroup.Panel.Controls[0]).Text.Replace(" VND", "").Replace(",", "").Trim();
                decimal.TryParse(rawNumber, out _selectedAmount);
            }
        }

        /// <summary>
        /// Hàm quản lý 2 trạng thái hiển thị của màn hình Nạp tiền
        /// </summary>
        private void SetPaymentState(int step)
        {
            _paymentStep = step;

            if (_paymentStep == 1) // BƯỚC 1: CHỌN MỆNH GIÁ
            {
                pnlAmountSelection.Visible = true; // Hiện panel chứa 6 ô KryptonTextBox
                pnlAmountSelection.BringToFront();

                lblAmount.Visible = false;
                txtAmount.Visible = false;
                lblPassword.Visible = false;
                txtPassword.Visible = false;

                txtPhoneNumber.ReadOnly = false;
                txtAmount.Clear();
                txtPassword.Clear();
            }
            else if (_paymentStep == 2) // BƯỚC 2: XÁC NHẬN & THANH TOÁN
            {
                pnlAmountSelection.Visible = false; // Ẩn panel chọn mệnh giá

                lblAmount.Visible = true;
                txtAmount.Visible = true;
                lblPassword.Visible = true;
                txtPassword.Visible = true;

                txtPhoneNumber.ReadOnly = true; // Khóa số điện thoại lại

                if (_isCustomAmount)
                {
                    // Trường hợp "Số khác": Mở khóa ô tiền cho phép nhập tay
                    txtAmount.ReadOnly = false;
                    txtAmount.Clear();
                    txtAmount.Focus();
                }
                else
                {
                    // Trường hợp mệnh giá cố định: Khóa ô tiền, tự điền chữ
                    txtAmount.ReadOnly = true;
                    txtAmount.Text = _selectedAmount.ToString("N0") + " VND";
                    txtPassword.Focus();
                }
            }
        }

        /// <summary>
        /// Tải danh sách số điện thoại cần nạp và tạo Card tối giản
        /// </summary>
        private void LoadPendingInvoices(int serviceTypeId)
        {
            pnlUnpaidList.Controls.Clear();

            try
            {
                string currentAccountNumber = GUI.Session.UserSession.CurrentUser.AccountNumber;
                List<InvoiceDTO> unpaidPhoneInvoices = _paymentService.GetPendingInvoices(currentAccountNumber, serviceTypeId);

                if (unpaidPhoneInvoices == null || unpaidPhoneInvoices.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "Không có số điện thoại nào đang lưu.",
                        Font = new Font("Segoe UI", 10f, FontStyle.Italic),
                        ForeColor = Color.DimGray,
                        AutoSize = true,
                        Location = new Point(20, 20)
                    };
                    pnlUnpaidList.Controls.Add(lblEmpty);
                    return;
                }

                int yPosition = 10;
                foreach (InvoiceDTO inv in unpaidPhoneInvoices)
                {
                    KryptonGroup card = CreateSimplePhoneCard(inv.BillCode, yPosition);

                    // Click vào Card sẽ đổ số ĐT sang form và đưa về Bước 1 để chọn mệnh giá
                    card.Click += (s, e) => FillInvoiceToForm(inv);
                    card.Panel.Click += (s, e) => FillInvoiceToForm(inv);
                    foreach (Control child in card.Panel.Controls)
                    {
                        child.Click += (s, e) => FillInvoiceToForm(inv);
                    }

                    pnlUnpaidList.Controls.Add(card);
                    yPosition += card.Height + 15;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private KryptonGroup CreateSimplePhoneCard(string phoneNumber, int yPos)
        {
            KryptonGroup card = new KryptonGroup();
            card.Size = new Size(pnlUnpaidList.Width - 25, 45);
            card.Location = new Point(10, yPos);
            card.Cursor = Cursors.Hand;

            card.StateCommon.Border.Rounding = 8;
            card.StateCommon.Border.Color1 = Color.LightGray;
            card.StateCommon.Border.Width = 1;
            card.StateCommon.Back.Color1 = Color.White;

            Label lblPhone = new Label
            {
                Text = phoneNumber,
                Font = new Font("Segoe UI", 11f, FontStyle.Regular),
                ForeColor = Color.MediumBlue,
                Location = new Point(15, 10),
                AutoSize = true
            };

            card.Panel.Controls.Add(lblPhone);
            return card;
        }

        private void FillInvoiceToForm(InvoiceDTO invoice)
        {
            cboProvider.Text = invoice.ProviderName;
            txtPhoneNumber.Text = invoice.BillCode;

            // Đảm bảo đưa người dùng về Bước 1 để họ tự chọn mệnh giá nạp
            SetPaymentState(1);
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchCode = txtPhoneNumber.Text.Trim();
                if (string.IsNullOrEmpty(searchCode)) return;

                e.Handled = true;
                e.SuppressKeyPress = true;

                try
                {
                    string currentAccountNumber = GUI.Session.UserSession.CurrentUser.AccountNumber;
                    List<InvoiceDTO> unpaidInvoices = _paymentService.GetPendingInvoices(currentAccountNumber, 4);

                    InvoiceDTO matchInvoice = unpaidInvoices.Find(i => i.BillCode.Equals(searchCode, StringComparison.OrdinalIgnoreCase));

                    if (matchInvoice != null)
                    {
                        FillInvoiceToForm(matchInvoice);
                    }
                    // Nếu gõ số lạ không lưu trong Database, hệ thống vẫn cho phép nạp bình thường (ở lại Bước 1)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            {
                if (_paymentStep == 2)
                {
                    SetPaymentState(1);
                }
                else if (_paymentStep == 1)
                {
                    ucInvoicePayment ucInvoices = new ucInvoicePayment();
                    ucInvoices.NavigateTo = this.NavigateTo;
                    NavigateTo?.Invoke(ucInvoices);
                }
            }
        }

        /// <summary>
        /// Nút Xác nhận gánh 2 nhiệm vụ (Next và Pay)
        /// </summary>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text.Trim();

            // Kiểm tra số điện thoại hợp lệ: bắt đầu bằng 0, có 10 chữ số, chỉ chứa số
            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length != 10 || !phoneNumber.StartsWith("0") || !System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d+$"))
            {
                MessageBox.Show("Số điện thoại nhập sai, vui lòng nhập lại!\n(Số điện thoại hợp lệ phải bắt đầu bằng 0 và có độ dài 10 chữ số)", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNumber.Focus();
                return;
            }

            // ==========================================
            // ĐANG Ở BƯỚC 1: BẤM ĐỂ CHUYỂN SANG BƯỚC 2
            // ==========================================
            if (_paymentStep == 1)
            {
                if (_selectedGroup == null)
                {
                    MessageBox.Show("Vui lòng chọn một mệnh giá để nạp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SetPaymentState(2);
            }
            // ==========================================
            // ĐANG Ở BƯỚC 2: BẤM ĐỂ THANH TOÁN
            // ==========================================
            else if (_paymentStep == 2)
            {
                // Kiểm tra ràng buộc bội số 10.000 nếu là ô "Số khác"
                if (_isCustomAmount)
                {
                    // 1. Dùng Regex lọc lấy CHỈ CÁC CHỮ SỐ (Loại bỏ các ký tự phẩy, chấm, chữ VNĐ)
                    string digitsOnly = System.Text.RegularExpressions.Regex.Replace(txtAmount.Text, @"[^\d]", "");

                    // 2. Chuyển sang kiểu long (số nguyên) để phép chia dư (%) chính xác tuyệt đối
                    if (string.IsNullOrEmpty(digitsOnly) || !long.TryParse(digitsOnly, out long customAmount) || customAmount <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAmount.Focus();
                        return;
                    }

                    // 3. Kiểm tra khắt khe điều kiện bội số của 10.000 (Nhập 30 sẽ báo lỗi ngay)
                    if (customAmount % 10000 != 0)
                    {
                        MessageBox.Show($"Số tiền bạn đang nhập là {customAmount.ToString("N0")} VND.\nVui lòng nhập đầy đủ chữ số và phải là bội số của 10,000 VND (Ví dụ: 30000, 50000...)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAmount.Focus();
                        return;
                    }
                    _selectedAmount = customAmount;
                }

                string inputPassword = txtPassword.Text.Trim();
                if (string.IsNullOrEmpty(inputPassword))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu xác nhận!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal currentBal = GUI.Session.UserSession.CurrentUser.Balance;
                string currentUserPassword = GUI.Session.UserSession.CurrentUser.Password;

                string errorMessage = _paymentService.ProcessPayment(inputPassword, currentUserPassword, phoneNumber, _selectedAmount, ref currentBal);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    GUI.Session.UserSession.CurrentUser.Balance = currentBal;
                    LoadBalanceUI();

                    var dashboardForm = this.FindForm() as frmClientDashboard;
                    if (dashboardForm != null) dashboardForm.RefreshDashboardBalance();

                    MessageBox.Show($"Đã nạp thành công {_selectedAmount.ToString("N0")} VND cho thuê bao {phoneNumber}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtPhoneNumber.Clear();
                    if (_selectedGroup != null) _selectedGroup.StateCommon.Back.Color1 = Color.White;
                    _selectedGroup = null;

                    SetPaymentState(1);
                    LoadPendingInvoices(4);
                }
                else
                {
                    MessageBox.Show(errorMessage, "Lỗi giao dịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
        }

        private void LoadBalanceUI()
        {
            decimal currentBal = GUI.Session.UserSession.CurrentUser.Balance;
            kryptonLabel1.Text = currentBal.ToString("N0") + " VND";
        }
    }
}