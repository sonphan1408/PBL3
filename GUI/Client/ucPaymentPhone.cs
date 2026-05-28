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
        // khai bao service de goi ham lay du lieu 
        private PaymentService _paymentService = new PaymentService();

        private decimal _selectedAmount = 0;
        private int _paymentStep = 1;         // 1: chon sdt + menh gia, 2: xac nhan + nhap mat khau
        private bool _isCustomAmount = false; // neu chon o "So khac" thi truong hop nay se true, nguoc lai la false de biet dang o che do menh gia co san hay nhap tay
        private KryptonTextBox _selectedKryptonBox = null; // highlight o menh gia dang chon

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

            cboProvider.DataSource = _paymentService.GetProviders(4);

            GenerateAmountOptions();

            SetPaymentState(1);

            LoadPendingInvoices(4);
        }

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

                KryptonGroup card = new KryptonGroup();
                card.Name = names[i];
                card.Size = new Size(boxWidth, boxHeight);
                card.Location = new Point(padding + col * (boxWidth + padding), padding + row * (boxHeight + padding));
                card.Cursor = Cursors.Hand;

                card.StateCommon.Border.Rounding = 8;
                card.StateCommon.Border.Color1 = Color.LightGray;
                card.StateCommon.Border.Width = 1;
                card.StateCommon.Back.Color1 = Color.White;

                Label lbl = new Label();
                lbl.Text = amounts[i];
                lbl.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
                lbl.Dock = DockStyle.Fill; 
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BackColor = Color.Transparent; 

                card.Click += KryptonGroupAmount_Click;
                lbl.Click += KryptonGroupAmount_Click;
                card.Panel.Click += KryptonGroupAmount_Click;

                card.Panel.Controls.Add(lbl);
                pnlAmountSelection.Controls.Add(card);
            }
        }

        /// su kien xay ra khi nhap vao 1 trong 6 o menh gia
        private KryptonGroup _selectedGroup = null; 

        private void KryptonGroupAmount_Click(object sender, EventArgs e)
        {
            KryptonGroup clickedGroup = (sender is KryptonGroup) ? (KryptonGroup)sender : (KryptonGroup)((Control)sender).Parent.Parent;

            if (_selectedGroup != null) _selectedGroup.StateCommon.Back.Color1 = Color.White;

            _selectedGroup = clickedGroup;
            _selectedGroup.StateCommon.Back.Color1 = Color.LightCyan;

            // logic lay tien
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

        /// Ham quan ly hien thi giao dien 2 trang thai khi chon menh gia va xac nhan
        private void SetPaymentState(int step)
        {
            _paymentStep = step;

            if (_paymentStep == 1) // chon menh gia va nhap so dien thoai
            {
                pnlAmountSelection.Visible = true; 
                pnlAmountSelection.BringToFront();

                lblAmount.Visible = false;
                txtAmount.Visible = false;
                lblPassword.Visible = false;
                txtPassword.Visible = false;

                txtPhoneNumber.ReadOnly = false;
                txtAmount.Clear();
                txtPassword.Clear();
            }
            else if (_paymentStep == 2) // xac nhan thong tin va nhap mat khau de thanh toan
            {
                pnlAmountSelection.Visible = false; 

                lblAmount.Visible = true;
                txtAmount.Visible = true;
                lblPassword.Visible = true;
                txtPassword.Visible = true;

                txtPhoneNumber.ReadOnly = true; 

                if (_isCustomAmount)
                {
                    // truong hop nhap so khac: mo khoa o nhap tien, de nguoi dung tu nhap so tien vao
                    txtAmount.ReadOnly = false;
                    txtAmount.Clear();
                    txtAmount.Focus();
                }
                else
                {
                    // truong hop chon menh gia co san: hien thi so tien da chon, va khoa o nhap tien
                    txtAmount.ReadOnly = true;
                    txtAmount.Text = _selectedAmount.ToString("N0") + " VND";
                    txtPassword.Focus();
                }
            }
        }

        /// load danh sach cac so dien thoai 
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
                    // Neu go so dien thoai khong luu trong database thi se hien thong bao
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text.Trim();

            // Kiem tra so dien thoai hop le: khong duoc de trong, phai co 10 chu so, bat dau bang 0, va chi chua cac chu so
            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length != 10 || !phoneNumber.StartsWith("0") || !System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d+$"))
            {
                MessageBox.Show("Số điện thoại nhập sai, vui lòng nhập lại!\n(Số điện thoại hợp lệ phải bắt đầu bằng 0 và có độ dài 10 chữ số)", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNumber.Focus();
                return;
            }
            // bam confirm lan dau tien de chon menh gia va so dien thoai, bam lan thu 2 de xac nhan va thanh toan
            if (_paymentStep == 1)
            {
                if (_selectedGroup == null)
                {
                    MessageBox.Show("Vui lòng chọn một mệnh giá để nạp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SetPaymentState(2);
            }
            else if (_paymentStep == 2)
            {
                // Kiem tra rang buoc 
                if (_isCustomAmount)
                {
                    string digitsOnly = System.Text.RegularExpressions.Regex.Replace(txtAmount.Text, @"[^\d]", "");

                    if (string.IsNullOrEmpty(digitsOnly) || !long.TryParse(digitsOnly, out long customAmount) || customAmount <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAmount.Focus();
                        return;
                    }

                    // Kiem tra dieu kien tien nhap vao phai la boi so cua 10,000 VND
                    //if (customAmount % 10000 != 0)
                    //{
                    //    MessageBox.Show($"Số tiền bạn đang nhập là {customAmount.ToString("N0")} VND.\nVui lòng nhập đầy đủ chữ số và phải là bội số của 10,000 VND (Ví dụ: 30000, 50000...)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    txtAmount.Focus();
                    //    return;
                    //}
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

                // string errorMessage = _paymentService.ProcessPayment(...);

                string errorMessage = _paymentService.ProcessPhonePayment(inputPassword, currentUserPassword, phoneNumber, _selectedAmount, ref currentBal);


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