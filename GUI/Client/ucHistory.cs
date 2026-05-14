using System;
using System.Collections.Generic;
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
                MessageBox.Show("Error loading history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (textBox1.Text == "Search transactions...")
            {
                textBox1.ForeColor = System.Drawing.Color.Gray;
            }
            
            textBox1.Enter += (s, e) =>
            {
                if (textBox1.Text == "Search transactions...")
                {
                    textBox1.Text = "";
                    textBox1.ForeColor = System.Drawing.Color.Black;
                }
            };
            
            textBox1.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox1.Text = "Search transactions...";
                    textBox1.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Clear();
            
            // Add columns
            dataGridView1.Columns.Add("TransactionID", "ID Transaction");
            dataGridView1.Columns.Add("TransactionType", "Type");
            dataGridView1.Columns.Add("FromAccount", "Sender");
            dataGridView1.Columns.Add("ToAccount", "Receiver");
            dataGridView1.Columns.Add("Amount", "Amount");
            dataGridView1.Columns.Add("BalanceBefore", "Balance Before");
            dataGridView1.Columns.Add("BalanceAfter", "Balance After");
            dataGridView1.Columns.Add("CreatedAt", "Date");

            // Set column widths
            dataGridView1.Columns["TransactionID"].Width = 150;
            dataGridView1.Columns["TransactionType"].Width = 80;
            dataGridView1.Columns["FromAccount"].Width = 120;
            dataGridView1.Columns["ToAccount"].Width = 120;
            dataGridView1.Columns["Amount"].Width = 100;
            dataGridView1.Columns["BalanceBefore"].Width = 120;
            dataGridView1.Columns["BalanceAfter"].Width = 120;
            dataGridView1.Columns["CreatedAt"].Width = 100;
        }

        private void SetupEventHandlers()
        {
            button1.Click += Button1_Click;
            textBox1.KeyPress += TextBox1_KeyPress;

            // Setup Combobox options for sorting
            RECNET.DropDownStyle = ComboBoxStyle.DropDownList;
            RECNET.Items.Clear();
            RECNET.Items.Add("All Transactions");
            RECNET.Items.Add("Recent");
            RECNET.Items.Add("Amount increasing");
            RECNET.Items.Add("Amount decreasing");
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
            if (searchText != "search transactions..." && !string.IsNullOrWhiteSpace(searchText))
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
            
            if (sortOption == "Amount increasing")
            {
                displayList.Sort((a, b) => a.Amount.CompareTo(b.Amount));
            }
            else if (sortOption == "Amount decreasing")
            {
                displayList.Sort((a, b) => b.Amount.CompareTo(a.Amount));
            }
            else // "Recent" or "All Transactions"
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
                    MessageBox.Show("Please login first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string accountNumber = UserSession.CurrentUser.AccountNumber;
                System.Diagnostics.Debug.WriteLine($"[ucHistory] Loading data for account: {accountNumber}");

                // Load balance
                decimal balance = AccountService.GetAccountBalance(accountNumber);
                lblBalanceAmount.Text = $"${balance:N2}";
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
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateDataGridView(List<TransactionDTO> transactions)
        {
            try
            {
                dataGridView1.Rows.Clear();

                if (transactions == null || transactions.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("[ucHistory] No transactions to display");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"[ucHistory] Populating DataGridView with {transactions.Count} rows");

                foreach (var transaction in transactions)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    row.Cells["TransactionID"].Value = transaction.TransactionID.ToString().Substring(0, Math.Min(8, transaction.TransactionID.ToString().Length));
                    row.Cells["TransactionType"].Value = transaction.TypeID;
                    row.Cells["FromAccount"].Value = transaction.FromAccount ?? "-";
                    row.Cells["ToAccount"].Value = transaction.ToAccount ?? "-";
                    row.Cells["Amount"].Value = $"${transaction.Amount:N2}";
                    row.Cells["BalanceBefore"].Value = $"${transaction.BalanceBefore:N2}";
                    row.Cells["BalanceAfter"].Value = $"${transaction.BalanceAfter:N2}";
                    row.Cells["CreatedAt"].Value = transaction.CreatedAt.ToString("yyyy-MM-dd");

                    // Alternate row colors
                    if (rowIndex % 2 == 0)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
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
            }
        }
    }
}
