using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;         // Sử dụng namespace mới đã sửa lỗi CS0246
using BLL.Services;            // Tầng xử lý nghiệp vụ PaymentService
using DTO.Models;              // Đối tượng InvoiceDTO

namespace GUI.Client
{
    public partial class ucPaymentInternet : UserControl
    {
        // 1. Khai báo tầng Service để xử lý nghiệp vụ
        private PaymentService _paymentService = new PaymentService();

        private decimal _selectedAmount = 0; // Lưu tạm số tiền của hóa đơn đang chọn

        // 2. Cầu nối Delegate dùng để quay lại màn hình chính Payments
        public Action<UserControl> NavigateTo { get; set; }

        public ucPaymentInternet()
        {
            InitializeComponent();

            // Đăng ký sự kiện Load cho giao diện
            this.Load += ucPaymentInternet_Load;
        }

        /// <summary>
        /// Sự kiện chạy khi bắt đầu mở giao diện Thanh toán Internet
        /// </summary>
        private void ucPaymentInternet_Load(object sender, EventArgs e)
        {
            // Cấu hình ComboBox cố định danh sách, không cho gõ bậy
            cboProvider.DropDownStyle = ComboBoxStyle.DropDownList;

            // 🌟 Hiện số dư ngay khi mở Form
            LoadBalanceUI();

            // 🌟 Đổ dữ liệu các công ty Internet (ServiceTypeID = 3) vào ComboBox
            cboProvider.DataSource = _paymentService.GetProviders(3);

            // Trạng thái 1: Mặc định ẩn các ô Số tiền, Mật khẩu khi chưa chọn hóa đơn
            SetAdvancedFormVisible(false);
            // BẮT ĐẦU LOAD: Chỉ truyền số 3 (Dịch vụ INTERNET) xuống để lọc danh sách bên phải
            LoadPendingInvoices(3);
        }

        /// <summary>
        /// Hàm gọi BLL lấy dữ liệu hóa đơn internet và tự động vẽ lên panel bên phải
        /// </summary>
        private void LoadPendingInvoices(int serviceTypeId)
        {
            // Làm sạch danh sách cũ
            pnlUnpaidList.Controls.Clear();

            try
            {
                // Lấy số tài khoản đang đăng nhập từ Session hệ thống
                string currentAccountNumber = GUI.Session.UserSession.CurrentUser.AccountNumber;

                // Gọi Service lọc đúng các hóa đơn chưa thanh toán của dịch vụ internet (ID = 3)
                List<InvoiceDTO> unpaidInternetInvoices = _paymentService.GetPendingInvoices(currentAccountNumber, serviceTypeId);

                // Nếu khách hàng không nợ tiền internet nào thì hiển thị thông báo trống
                if (unpaidInternetInvoices == null || unpaidInternetInvoices.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "Bạn không có hóa đơn tiền internet nào cần thanh toán.",
                        Font = new Font("Segoe UI", 10f, FontStyle.Italic),
                        ForeColor = Color.DimGray,
                        AutoSize = true,
                        Location = new Point(20, 20)
                    };
                    pnlUnpaidList.Controls.Add(lblEmpty);
                    return;
                }

                // Tiến hành chạy vòng lặp dựng các Card hóa đơn internet
                int yPosition = 10;
                foreach (InvoiceDTO inv in unpaidInternetInvoices)
                {
                    // Đúc một cái khung KryptonGroup bo góc
                    KryptonGroup card = CreateInvoiceCard(inv, yPosition);

                    // Bấm vào vùng trống của Card hoặc lòng Panel đều kích hoạt đổ dữ liệu sang trái
                    card.Click += (s, e) => FillInvoiceToForm(inv);
                    card.Panel.Click += (s, e) => FillInvoiceToForm(inv);

                    // Bấm vào các chữ (Label) bên trong Card cũng kích hoạt đổ dữ liệu
                    foreach (Control child in card.Panel.Controls)
                    {
                        child.Click += (s, e) => FillInvoiceToForm(inv);
                    }

                    // Thêm Card vào thùng chứa lớn bên phải
                    pnlUnpaidList.Controls.Add(card);
                    yPosition += card.Height + 15; // Tịnh tiến khoảng cách trục Y xuống dưới
                }
            }
            catch (Exception ex)
            {
                // Đã sửa về MessageBox mặc định của Windows để tránh lỗi chồng hàm CS1503
                MessageBox.Show("Không thể tải danh sách hóa đơn internet: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Thiết kế cấu trúc bo góc và chữ hiển thị bên trong Card hóa đơn
        /// </summary>
        private KryptonGroup CreateInvoiceCard(InvoiceDTO invoice, int yPos)
        {
            KryptonGroup card = new KryptonGroup();
            card.Size = new Size(pnlUnpaidList.Width - 25, 110);
            card.Location = new Point(10, yPos);
            card.Cursor = Cursors.Hand;

            // Style bo góc mượt mà cho thẻ hóa đơn
            card.StateCommon.Border.Rounding = 12;
            card.StateCommon.Border.Color1 = Color.LightGray;
            card.StateCommon.Back.Color1 = Color.White;

            Label lblProvider = new Label
            {
                Text = invoice.ProviderName,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(21, 41, 88), // Màu xanh thương hiệu
                Location = new Point(15, 12),
                AutoSize = true
            };

            Label lblCode = new Label
            {
                Text = $"Mã KH: {invoice.BillCode}",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                ForeColor = Color.Gray,
                Location = new Point(15, 40),
                AutoSize = true
            };

            string formattedDate = invoice.DueDate.HasValue ? invoice.DueDate.Value.ToString("dd/MM/yyyy") : "Không giới hạn";
            Label lblDate = new Label
            {
                Text = $"Hạn thanh toán: {formattedDate}",
                Font = new Font("Segoe UI", 9f, FontStyle.Italic),
                ForeColor = Color.DarkOrange,
                Location = new Point(15, 68),
                AutoSize = true
            };

            Label lblPrice = new Label
            {
                Text = invoice.Amount.ToString("N0") + " VND",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.Crimson,
                Location = new Point(card.Width - 160, 40),
                AutoSize = true,
                TextAlign = ContentAlignment.TopRight
            };

            card.Panel.Controls.Add(lblProvider);
            card.Panel.Controls.Add(lblCode);
            card.Panel.Controls.Add(lblDate);
            card.Panel.Controls.Add(lblPrice);

            return card;
        }

        /// <summary>
        /// Đổ ngược dữ liệu hóa đơn internet sang Form bên trái và mở rộng sang Trạng thái 2
        /// </summary>
        private void FillInvoiceToForm(InvoiceDTO invoice)
        {
            cboProvider.Text = invoice.ProviderName;
            txtCustomerCode.Text = invoice.BillCode;
            txtAmount.Text = invoice.Amount.ToString("N0") + " VND";

            // 🌟 Lưu lại số tiền để lát nữa đem đi trừ
            _selectedAmount = invoice.Amount;

            // Khóa cứng ô nhập mã lại, không cho người dùng sửa lung tung sau khi đã chọn bill nhạy cảm
            txtCustomerCode.ReadOnly = true;

            // Bật hiển thị các ô Mật khẩu và Số tiền lên màn hình
            SetAdvancedFormVisible(true);
            txtPassword.Focus();
        }

        /// <summary>
        /// Hàm quản lý ẩn/hiện đồng bộ các Control nâng cao ở form bên trái
        /// </summary>
        private void SetAdvancedFormVisible(bool isVisible)
        {
            lblAmount.Visible = isVisible;
            txtAmount.Visible = isVisible;
            lblPassword.Visible = isVisible;
            txtPassword.Visible = isVisible;

            if (!isVisible)
            {
                txtPassword.Text = string.Empty;
                txtCustomerCode.ReadOnly = false;
            }
        }

        /// <summary>
        /// Xử lý sự kiện gõ tìm kiếm thủ công Mã hóa đơn bằng bàn phím rồi nhấn Enter
        /// </summary>
        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchCode = txtCustomerCode.Text.Trim();
                if (string.IsNullOrEmpty(searchCode)) return;

                e.Handled = true;
                e.SuppressKeyPress = true;

                try
                {
                    string currentAccountNumber = GUI.Session.UserSession.CurrentUser.AccountNumber;
                    // Lấy riêng list hóa đơn internet (3) về để đối chiếu tìm kiếm nhanh
                    List<InvoiceDTO> unpaidInvoices = _paymentService.GetPendingInvoices(currentAccountNumber, 3);

                    InvoiceDTO matchInvoice = unpaidInvoices.Find(i => i.BillCode.Equals(searchCode, StringComparison.OrdinalIgnoreCase));

                    if (matchInvoice != null)
                    {
                        FillInvoiceToForm(matchInvoice);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn tiền internet chưa thanh toán nào khớp với mã trên hộ gia đình này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetAdvancedFormVisible(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút "Thoát" để điều hướng tráo đổi UserControl quay ngược về trang tổng Payments
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            ucInvoicePayment ucInvoices = new ucInvoicePayment();

            // Gắn lại cầu nối để khi về trang tổng, người dùng bấm nút khác vẫn chuyển trang tiếp được
            ucInvoices.NavigateTo = this.NavigateTo;

            // Gọi Delegate yêu cầu Dashboard đổi ruột hiển thị
            NavigateTo?.Invoke(ucInvoices);
        }

        /// <summary>
        /// Nút xác nhận thanh toán cuối cùng
        /// </summary>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 1. Gom dữ liệu từ trên màn hình
            string inputPassword = txtPassword.Text.Trim();
            string billCode = txtCustomerCode.Text.Trim();

            if (string.IsNullOrEmpty(inputPassword))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu xác nhận!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem số dư có đủ để thanh toán không
            decimal currentBal = GUI.Session.UserSession.CurrentUser.Balance;
            if (currentBal < _selectedAmount)
            {
                MessageBox.Show("Số dư tài khoản không đủ để thực hiện giao dịch!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy mật khẩu chuẩn từ Session của người dùng đang đăng nhập
            string currentUserPassword = GUI.Session.UserSession.CurrentUser.Password;

            // GỌI BLL: Không tự trừ tiền và không tự xét số dư ở GUI nữa
            string errorMessage = _paymentService.ProcessPayment(inputPassword, currentUserPassword, billCode, _selectedAmount, ref currentBal);

            //MessageBox.Show($"Bạn gõ: [{inputPassword}]\nHệ thống lưu: [{currentUserPassword}]", "Debug Check");

            if (string.IsNullOrEmpty(errorMessage)) // BLL trả về rỗng -> Giao dịch hoàn hảo
            {
                // Cập nhật lại số dư từ BLL vào Session
                GUI.Session.UserSession.CurrentUser.Balance = currentBal;
                LoadBalanceUI();

                var dashboardForm = this.FindForm() as frmClientDashboard;
                if (dashboardForm != null)
                {
                    dashboardForm.RefreshDashboardBalance();
                }

                MessageBox.Show("Thanh toán hóa đơn internet thành công!", "Giao dịch thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Dọn dẹp giao diện và gọi LoadPendingInvoices để "giấu" Card đi
                txtCustomerCode.Clear();
                SetAdvancedFormVisible(false);
                LoadPendingInvoices(1);
            }
            else // BLL báo lỗi
            {
                MessageBox.Show(errorMessage, "Lỗi giao dịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // Viết thêm hàm này để hiển thị số dư từ Session lên giao diện
        private void LoadBalanceUI()
        {
            // Lấy số dư hiện tại từ Session (Nếu null thì mặc định là 0)
            decimal currentBal = GUI.Session.UserSession.CurrentUser.Balance;

            // Gán vào Label bạn vừa kéo thả lúc nãy
            kryptonLabel1.Text = currentBal.ToString("N0") + " VND";
        }

        private void lbProvider_Click(object sender, EventArgs e)
        {

        }
    }
}
