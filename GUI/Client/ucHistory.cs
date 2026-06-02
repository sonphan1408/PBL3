using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL.Services;
using DTO.Models;
using GUI.Session;

namespace GUI.Client
{
    public partial class ucHistory : UserControl
    {
        private AccountCustomerDTO currentAccount;
        private List<TransactionDTO> allTransactions;
        private bool isDataLoaded = false;

        public ucHistory()
        {
            InitializeComponent();
            if (this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;

            try
            {
                InitializeDataGridView();
                SetupEventHandlers();
                LoadDataFromDatabase();
                isDataLoaded = true;

                // Subscribe ở đây để đảm bảo luôn nhận được event dù Load chưa chạy
                UserSession.BalanceChanged += UserSession_BalanceChanged;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR in constructor: " + ex.Message);
            }
        }

        /// <summary>
        /// Tự động refresh khi người dùng chuyển sang trang này
        /// </summary>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible && isDataLoaded)
            {
                System.Diagnostics.Debug.WriteLine("[ucHistory] OnVisibleChanged — refreshing data");
                LoadDataFromDatabase();
            }
        }

        /// <summary>
        /// Public method to refresh data - called from dashboard when balance changes
        /// </summary>
        public void RefreshData()
        {
            System.Diagnostics.Debug.WriteLine("[ucHistory] RefreshData called externally");
            LoadDataFromDatabase();
        }

        private void ucHistory_Load(object sender, EventArgs e)
        {
            try
            {
                if (!isDataLoaded)
                {
                    LoadDataFromDatabase();
                    isDataLoaded = true;
                }
                SetupSearchPlaceholder();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in ucHistory_Load: " + ex.Message);
                MessageBox.Show("Lỗi khi tải lịch sử: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserSession_BalanceChanged()
        {
            // Fallback refresh if called directly
            try
            {
                System.Diagnostics.Debug.WriteLine("[ucHistory] BalanceChanged event fired - fallback refresh");
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => RefreshData()));
                }
                else
                {
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ucHistory] Error in BalanceChanged handler: {ex.Message}");
            }
        }

        private void SetupSearchPlaceholder()
        {
            if (textBox1.Text == "Tìm kiếm giao dịch...")
            {
                textBox1.ForeColor = System.Drawing.Color.Gray;
            }
            
            textBox1.Enter += (s, e) =>
            {
                if (textBox1.Text == "Tìm kiếm giao dịch...")
                {
                    textBox1.Text = "";
                    textBox1.ForeColor = System.Drawing.Color.Black;
                }
            };
            
            textBox1.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox1.Text = "Tìm kiếm giao dịch...";
                    textBox1.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Clear();

            // Add columns matching the target design
            dataGridView1.Columns.Add("TransactionID", "Mã giao dịch");
            dataGridView1.Columns.Add("TransactionType", "Loại");
            dataGridView1.Columns.Add("FromAccount", "Người gửi");
            dataGridView1.Columns.Add("ToAccount", "Người nhận");
            dataGridView1.Columns.Add("Amount", "Số tiền");
            dataGridView1.Columns.Add("Status", "Trạng thái");
            dataGridView1.Columns.Add("TimeRequest", "Thời gian yêu cầu");
            dataGridView1.Columns.Add("TimeApprove", "Thời gian duyệt");

            // Set column widths
            dataGridView1.Columns["TransactionID"].Width = 120;
            dataGridView1.Columns["TransactionType"].Width = 60;
            dataGridView1.Columns["FromAccount"].Width = 130;
            dataGridView1.Columns["ToAccount"].Width = 130;
            dataGridView1.Columns["Amount"].Width = 100;
            dataGridView1.Columns["Status"].Width = 60;
            dataGridView1.Columns["TimeRequest"].Width = 160;
            dataGridView1.Columns["TimeApprove"].Width = 160;

            // Restore original dark blue header style
            var headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.Color.FromArgb(25, 55, 99);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(25, 55, 99);
            dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Alternating rows: original white / light gray
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
        }

        private void SetupEventHandlers()
        {
            button1.Click += Button1_Click;
            textBox1.KeyPress += TextBox1_KeyPress;

            // Setup Combobox options for sorting
            RECNET.DropDownStyle = ComboBoxStyle.DropDownList;
            RECNET.Items.Clear();
            RECNET.Items.Add("Tất cả giao dịch");
            RECNET.Items.Add("Gần đây nhất");
            RECNET.Items.Add("Số tiền tăng dần");
            RECNET.Items.Add("Số tiền giảm dần");
            RECNET.SelectedIndex = 0;
            
            RECNET.SelectedIndexChanged += (s, e) => FilterTransactions();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FilterTransactions();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                FilterTransactions();
                e.Handled = true;
            }
        }

        private void FilterTransactions()
        {
            if (allTransactions == null) return;

            string searchText = textBox1.Text.ToLower().Trim();
            List<TransactionDTO> displayList = new List<TransactionDTO>(allTransactions);
            
            // Apply filtering
            bool isPlaceholder = textBox1.ForeColor == System.Drawing.Color.Gray || 
                                 searchText == "tìm kiếm giao dịch..." || 
                                 string.IsNullOrWhiteSpace(searchText);
                                 
            if (!isPlaceholder)
            {
                displayList = displayList.FindAll(t =>
                    t.TransactionID.ToString().ToLower().Contains(searchText) ||
                    (t.Description != null && t.Description.ToLower().Contains(searchText)) ||
                    (t.FromAccount != null && t.FromAccount.ToLower().Contains(searchText)) ||
                    (t.ToAccount != null && t.ToAccount.ToLower().Contains(searchText)) ||
                    t.Amount.ToString().Contains(searchText)
                );
            }
            
            // Apply sorting
            string sortOption = RECNET.SelectedItem?.ToString();
            
            if (sortOption == "Số tiền tăng dần")
            {
                displayList.Sort((a, b) => a.Amount.CompareTo(b.Amount));
            }
            else if (sortOption == "Số tiền giảm dần")
            {
                displayList.Sort((a, b) => b.Amount.CompareTo(a.Amount));
            }
            else // "Gần đây nhất" or "Tất cả giao dịch"
            {
                displayList.Sort((a, b) => b.CreatedAt.CompareTo(a.CreatedAt));
            }
            
            PopulateDataGridView(displayList);
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[ucHistory] LoadDataFromDatabase called");
                
                // Get current account
                if (UserSession.CurrentUser == null)
                {
                    System.Diagnostics.Debug.WriteLine("[ucHistory] CurrentUser is null");
                    MessageBox.Show("Vui lòng đăng nhập trước", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string accountNumber = UserSession.CurrentUser.AccountNumber;
                System.Diagnostics.Debug.WriteLine($"[ucHistory] Loading data for account: {accountNumber}");

                // Load balance
                decimal balance = AccountService.GetAccountBalance(accountNumber);
                lblBalanceAmount.Text = $"{balance:N2} VNĐ";
                System.Diagnostics.Debug.WriteLine($"[ucHistory] Balance loaded: {balance}");

                // Load transactions
                allTransactions = TransactionService.GetTransactionsByAccount(accountNumber, 100);
                System.Diagnostics.Debug.WriteLine($"[ucHistory] Loaded {allTransactions.Count} transactions");
                
                // Update info panels
                lblTotalTransactionsAmount.Text = allTransactions.Count.ToString();
                
                decimal totalAmount = 0;
                foreach (var transaction in allTransactions)
                {
                    totalAmount += transaction.Amount;
                }
                
                FilterTransactions();
                System.Diagnostics.Debug.WriteLine("[ucHistory] DataGridView populated and sorted");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ucHistory] Error loading data: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateDataGridView(List<TransactionDTO> transactions)
        {
            try
            {
                dataGridView1.Rows.Clear();

                // Xóa label cũ nếu có
                var oldLabel = dataGridView1.Controls["lblEmptyData"];
                if (oldLabel != null) dataGridView1.Controls.Remove(oldLabel);

                if (transactions == null || transactions.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("[ucHistory] No transactions to display");
                    Label lblEmpty = new Label();
                    lblEmpty.Name = "lblEmptyData";
                    lblEmpty.Text = "Không có dữ liệu giao dịch.";
                    lblEmpty.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                    lblEmpty.ForeColor = Color.Gray;
                    lblEmpty.AutoSize = false;
                    lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
                    lblEmpty.Dock = DockStyle.Fill;
                    lblEmpty.BackColor = Color.White;
                    dataGridView1.Controls.Add(lblEmpty);
                    lblEmpty.BringToFront();
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"[ucHistory] Populating DataGridView with {transactions.Count} rows");

                foreach (var transaction in transactions)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    string txId = transaction.TransactionID.ToString();
                    row.Cells["TransactionID"].Value = txId.Substring(0, Math.Min(8, txId.Length));
                    string txType = "Khác";
                    switch(transaction.TypeID)
                    {
                        case 1: txType = "Chuyển tiền nội bộ"; break;
                        case 3: txType = "Chuyển khoản liên ngân hàng"; break;
                        case 4: txType = "Thanh toán hóa đơn"; break;
                        case 5: txType = "Sổ tiết kiệm"; break;
                        case 6: txType = "Khoản vay"; break;
                    }
                    row.Cells["TransactionType"].Value = txType;
                    string fromAcc = transaction.FromAccount ?? "-";
                    string toAcc = transaction.ToAccount ?? "-";

                    if (fromAcc == toAcc)
                    {
                        if (transaction.TypeID == 5) { if (transaction.Amount > 0 && transaction.Description?.Contains("Mở") == false && transaction.Description?.Contains("Gửi") == false) fromAcc = "Sổ tiết kiệm"; else toAcc = "Sổ tiết kiệm"; }
                        else if (transaction.TypeID == 6) { if (transaction.Description?.Contains("Giải ngân") == true) fromAcc = "Khoản vay"; else toAcc = "Khoản vay"; }
                        else if (transaction.TypeID == 4) toAcc = "Thanh toán";
                    }

                    row.Cells["FromAccount"].Value = fromAcc;
                    row.Cells["ToAccount"].Value = toAcc;
                    row.Cells["Amount"].Value = transaction.Amount.ToString("N0");
                    row.Cells["Status"].Value = "Thành công";
                    row.Cells["TimeRequest"].Value = transaction.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                    row.Cells["TimeApprove"].Value = transaction.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");

                    // Alternate row colors (original style)
                    if (rowIndex % 2 == 0)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }
                }
                
                System.Diagnostics.Debug.WriteLine("[ucHistory] DataGridView populated successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ucHistory] Error in PopulateDataGridView: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Lỗi hiển thị danh sách: {ex.Message}\n{ex.StackTrace}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
