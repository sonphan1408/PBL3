using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Services;
using GUI.Session;

namespace GUI
{
    public partial class ucPaymentHistory : UserControl
    {
        private bool _isInitialized = false; // guard: chỉ refresh sau khi Load đã chạy

        public ucPaymentHistory()
        {
            InitializeComponent();
            this.Load += UcPaymentHistory_Load;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible && _isInitialized)
            {
                System.Diagnostics.Debug.WriteLine("[ucPaymentHistory] OnVisibleChanged — refreshing");
                RefreshData();
            }
        }

        public void RefreshData()
        {
            if (!_isInitialized) return;
            System.Diagnostics.Debug.WriteLine("[ucPaymentHistory] RefreshData called");
            LoadAccountInfo();
            if (dgvPaymentHistory != null)
                dgvPaymentHistory.Rows.Clear();
            LoadPaymentData();
            StyleDataGridView();
        }

        private void UcPaymentHistory_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadAccountInfo();
            LoadPaymentData();
            StyleDataGridView();
            _isInitialized = true; // đánh dấu đã khởi tạo xong
        }

        private void LoadAccountInfo()
        {
            try
            {
                // Get current user's account info
                if (UserSession.CurrentUser == null)
                {
                    return;
                }

                // Update Balance label
                lblBalanceAmount.Text = "$" + UserSession.CurrentUser.Balance.ToString("F2");

                // For Digital Savings, you may need to calculate from user's savings accounts
                // For now, we'll display 0 if not implemented
                lblDigitalSavingsAmount.Text = "$0.00";
            }
            catch (Exception ex)
            {
                // Silently fail - use default values
            }
        }

        private void SetupDataGridView()
        {
            // Clear existing columns
            dgvPaymentHistory.Columns.Clear();

            // Add columns
            dgvPaymentHistory.Columns.Add("Invoice", "Mã hóa đơn");
            dgvPaymentHistory.Columns.Add("BillingTo", "Bên nhận");
            dgvPaymentHistory.Columns.Add("Status", "Trạng thái");
            dgvPaymentHistory.Columns.Add("PaymentDate", "Ngày thanh toán");
            dgvPaymentHistory.Columns.Add("Amount", "Số tiền");
            dgvPaymentHistory.Columns.Add("PaymentFor", "Thanh toán cho");

            // Set column widths
            dgvPaymentHistory.Columns["Invoice"].Width = 100;
            dgvPaymentHistory.Columns["BillingTo"].Width = 120;
            dgvPaymentHistory.Columns["Status"].Width = 80;
            dgvPaymentHistory.Columns["PaymentDate"].Width = 110;
            dgvPaymentHistory.Columns["Amount"].Width = 90;
            dgvPaymentHistory.Columns["PaymentFor"].Width = 120;

            // Configure row height
            dgvPaymentHistory.RowTemplate.Height = 35;

            // Set auto size mode for better look
            dgvPaymentHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Hide the fake custom header panel
            if (pnlTableHeader != null)
            {
                pnlTableHeader.Visible = false;
            }

            // Show and style native column headers like Transaction History
            dgvPaymentHistory.ColumnHeadersVisible = true;
            dgvPaymentHistory.EnableHeadersVisualStyles = false;
            dgvPaymentHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 55, 99);
            dgvPaymentHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPaymentHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvPaymentHistory.ColumnHeadersHeight = 40;
            dgvPaymentHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void StyleDataGridView()
        {
            // Alternate row colors for better readability
            for (int i = 0; i < dgvPaymentHistory.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dgvPaymentHistory.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);
                }
                else
                {
                    dgvPaymentHistory.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                dgvPaymentHistory.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                dgvPaymentHistory.Rows[i].DefaultCellStyle.Font = new Font("Arial", 10F);
            }
        }

        private void LoadPaymentData()
        {
            try
            {
                // Get current user's account number
                if (UserSession.CurrentUser == null)
                {
                    MessageBox.Show("Vui lòng đăng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string accountNumber = UserSession.CurrentUser.AccountNumber;

                // Get invoices from database
                var invoices = PaymentService.GetInvoicesByAccount(accountNumber);

                if (invoices == null || invoices.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Load data into DataGridView
                foreach (var invoice in invoices)
                {
                    string invoiceId = "INV" + invoice.InvoiceID.ToString().PadLeft(4, '0');
                    string billingTo = invoice.ProviderName ?? "N/A";
                    string status = invoice.Status ?? "UNKNOWN";
                    string paymentDate = invoice.DueDate != DateTime.MinValue ? invoice.DueDate.ToString("yyyy-MM-dd") : "-";
                    string amount = "$" + invoice.Amount.ToString("F2");
                    string paymentFor = "CHUYỂN KHOẢN";

                    dgvPaymentHistory.Rows.Add(invoiceId, billingTo, status, paymentDate, amount, paymentFor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
