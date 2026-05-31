using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;         
using BLL.Services;            // PaymentService
using DTO.Models;              // InvoiceDTO

namespace GUI.Client
{
    public partial class ucPaymentElectricity : UserControl
    {
        // khai bao service de goi ham lay du lieu 
        private PaymentService _paymentService = new PaymentService();

        private decimal _selectedAmount = 0; // Luu tam so tien cua hoa don dien duoc chon
        private int _selectedInvoiceId = 0; // Luu tam ID hoa don de cap nhat trang thai trong DB

        public Action<UserControl> NavigateTo { get; set; }

        public ucPaymentElectricity()
        {
            InitializeComponent();

            this.Load += ucPaymentElectricity_Load;
        }


        private void ucPaymentElectricity_Load(object sender, EventArgs e)
        {
            cboProvider.DropDownStyle = ComboBoxStyle.DropDownList;

            // Hien thi so du
            LoadBalanceUI();

            // Do du lieu nha cung cap
            cboProvider.DataSource = _paymentService.GetProviders(1);

            // An cac o nhap lieu nang cao luc dau, chi hien thi sau khi chon duoc hoa don dien can thanh toan
            SetAdvancedFormVisible(false);
            // load danh sach hoa don dien dang cho xu ly len panel ben phai
            LoadPendingInvoices(1);
        }

        /// Ham goi BLL de lay danh sach hoa don dien
        private void LoadPendingInvoices(int serviceTypeId)
        {
            pnlUnpaidList.Controls.Clear();

            try
            {
                // Lay so tai khoan dang dang nhap tu Session de truyen vao BLL
                string currentAccountNumber = GUI.Session.UserSession.CurrentUser.AccountNumber;

                // Goi BLL lay danh sach hoa don dien dang cho xu ly cua khach hang
                List<InvoiceDTO> unpaidElectricityInvoices = _paymentService.GetPendingInvoices(currentAccountNumber, serviceTypeId);

                // Neu khong no tien dien
                if (unpaidElectricityInvoices == null || unpaidElectricityInvoices.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "Bạn không có hóa đơn tiền điện nào cần thanh toán.",
                        Font = new Font("Segoe UI", 10f, FontStyle.Italic),
                        ForeColor = Color.DimGray,
                        AutoSize = true,
                        Location = new Point(20, 20)
                    };
                    pnlUnpaidList.Controls.Add(lblEmpty);
                    return;
                }

                // Tao cac card hien thi thong tin co ban cua tung hoa don dien va them vao panel ben phai
                int yPosition = 10;
                foreach (InvoiceDTO inv in unpaidElectricityInvoices)
                {
                    KryptonGroup card = CreateInvoiceCard(inv, yPosition);

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
                MessageBox.Show("Không thể tải danh sách hóa đơn điện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Thiet ke cau truc va giao dien co ban cho tung card hien thi thong tin hoa don dien

        private KryptonGroup CreateInvoiceCard(InvoiceDTO invoice, int yPos)
        {
            KryptonGroup card = new KryptonGroup();
            card.Size = new Size(pnlUnpaidList.Width - 25, 110);
            card.Location = new Point(10, yPos);
            card.Cursor = Cursors.Hand;

            card.StateCommon.Border.Rounding = 12;
            card.StateCommon.Border.Color1 = Color.LightGray;
            card.StateCommon.Back.Color1 = Color.White;

            Label lblProvider = new Label
            {
                Text = invoice.ProviderName,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(21, 41, 88), 
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

        /// Do du lieu chi tiet cua hoa don dien duoc chon vao cac o ben trai de hien thi va xac nhan thanh toan
        private void FillInvoiceToForm(InvoiceDTO invoice)
        {
            cboProvider.Text = invoice.ProviderName;
            txtCustomerCode.Text = invoice.BillCode;
            txtAmount.Text = invoice.Amount.ToString("N0") + " VND";

            _selectedAmount = invoice.Amount;
            _selectedInvoiceId = invoice.InvoiceID;

            txtCustomerCode.ReadOnly = true;

            SetAdvancedFormVisible(true);
            txtPassword.Focus();
        }

        /// Ham an hien cac o nhap lieu va cac label lien quan
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

        /// su kien go thu cong
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
                    List<InvoiceDTO> unpaidInvoices = _paymentService.GetPendingInvoices(currentAccountNumber, 1);

                    InvoiceDTO matchInvoice = unpaidInvoices.Find(i => i.BillCode.Equals(searchCode, StringComparison.OrdinalIgnoreCase));

                    if (matchInvoice != null)
                    {
                        FillInvoiceToForm(matchInvoice);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn tiền điện chưa thanh toán nào khớp với mã trên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetAdvancedFormVisible(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            ucInvoicePayment ucInvoices = new ucInvoicePayment();

            ucInvoices.NavigateTo = this.NavigateTo;

            NavigateTo?.Invoke(ucInvoices);
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string inputPassword = txtPassword.Text.Trim();
            string billCode = txtCustomerCode.Text.Trim();

            if (string.IsNullOrEmpty(inputPassword))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu xác nhận!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra so du
            decimal currentBal = GUI.Session.UserSession.CurrentUser.Balance ;
            if (currentBal < _selectedAmount)
            {
                MessageBox.Show("Số dư tài khoản không đủ để thực hiện giao dịch!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string currentUserPassword = GUI.Session.UserSession.CurrentUser.Password;

            // Goi BLL de xu ly logic thanh toan va tra ve thong diep loi neu co, neu thanh cong se tra ve chuoi rong
            string accountNumber = GUI.Session.UserSession.CurrentUser.AccountNumber;
            string errorMessage = _paymentService.ProcessPayment(inputPassword, currentUserPassword, billCode, _selectedAmount, ref currentBal, accountNumber, _selectedInvoiceId);


            if (string.IsNullOrEmpty(errorMessage)) // BLL xu ly thanh cong, tra ve chuoi rong, va cap nhat so du moi vao bien currentBal
            {
                // Cap nhat lai so du moi vao Session
                GUI.Session.UserSession.CurrentUser.Balance = currentBal;
                GUI.Session.UserSession.UpdateBalance(0);
                LoadBalanceUI();

                var dashboardForm = this.FindForm() as frmClientDashboard;
                if (dashboardForm != null)
                {
                    dashboardForm.RefreshDashboardBalance();
                }

                MessageBox.Show("Thanh toán hóa đơn điện thành công!", "Giao dịch thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var notifData = new DTO.Models.NotificationMessageDTO
                {
                    OperationType = "payment",
                    NotificationType = "transaction",
                    PaymentAmount = _selectedAmount,
                    InvoiceId = "Điện - " + billCode
                };
                GUI.Session.UserSession.RaiseNotification(notifData);

                txtCustomerCode.Clear();
                SetAdvancedFormVisible(false);
                LoadPendingInvoices(1);
            }
            else // Bll bao loi
            {
                MessageBox.Show(errorMessage, "Lỗi giao dịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // Ham hien thi so du tai khoan len giao dien, goi khi load form va sau khi thanh toan thanh cong de cap nhat so du moi
        private void LoadBalanceUI()
        {
            decimal currentBal = GUI.Session.UserSession.CurrentUser.Balance;

            kryptonLabel1.Text = currentBal.ToString("N0") + " VND";
        }
    }
}

