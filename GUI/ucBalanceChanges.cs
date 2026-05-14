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
using DTO.Models;
using GUI.Session;

namespace GUI
{
    public partial class ucBalanceChanges: UserControl
    {
        private List<TransactionDTO> allTransactions = new List<TransactionDTO>();
        private string currentAccountNumber = "";
        private const string SearchPlaceholder = "Search transactions...";
        private bool isDataLoaded = false;

        public ucBalanceChanges()
        {
            InitializeComponent();
            if (this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;

            // Subscribe ở đây để luôn nhận được event
            UserSession.BalanceChanged += UserSession_BalanceChanged;
        }

        /// <summary>
        /// Tự động refresh khi người dùng chuyển sang trang này
        /// </summary>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible && isDataLoaded)
            {
                System.Diagnostics.Debug.WriteLine("[ucBalanceChanges] OnVisibleChanged — refreshing data");
                LoadData();
            }
        }

        /// <summary>
        /// Public method to refresh data - called from dashboard when balance changes
        /// </summary>
        public void RefreshData()
        {
            System.Diagnostics.Debug.WriteLine("[ucBalanceChanges] RefreshData called externally");
            LoadData(currentAccountNumber);
        }

        private void ucBalanceChanges_Load(object sender, EventArgs e)
        {
            if (!isDataLoaded)
            {
                LoadData();
                isDataLoaded = true;
            }

            // Set placeholder text
            txtSearch.Text = SearchPlaceholder;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;
        }

        private void UserSession_BalanceChanged()
        {
            // Fallback refresh if called directly
            try
            {
                System.Diagnostics.Debug.WriteLine("[ucBalanceChanges] BalanceChanged event fired - fallback refresh");
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
                System.Diagnostics.Debug.WriteLine($"[ucBalanceChanges] Error in BalanceChanged handler: {ex.Message}");
            }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == SearchPlaceholder)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = SearchPlaceholder;
                txtSearch.ForeColor = Color.Gray;
            }
        }

        public void LoadData(string accountNumber = "")
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[ucBalanceChanges] LoadData called");
                
                // Get account from session if not provided
                if (string.IsNullOrEmpty(accountNumber))
                {
                    if (UserSession.CurrentUser != null)
                    {
                        accountNumber = UserSession.CurrentUser.AccountNumber;
                    }
                    else
                    {
                        MessageBox.Show("Please login first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                currentAccountNumber = accountNumber;
                System.Diagnostics.Debug.WriteLine($"[ucBalanceChanges] Loading data for account: {accountNumber}");

                // Load balance
                decimal balance = AccountService.GetAccountBalance(accountNumber);
                lblBalance.Text = $"${balance:F2}";
                System.Diagnostics.Debug.WriteLine($"[ucBalanceChanges] Balance loaded: {balance}");

                // Load transactions
                allTransactions = TransactionService.GetTransactionsByAccount(accountNumber, 100);
                System.Diagnostics.Debug.WriteLine($"[ucBalanceChanges] Loaded {allTransactions.Count} transactions");
                
                DisplayTransactions(allTransactions);
                System.Diagnostics.Debug.WriteLine("[ucBalanceChanges] Transactions displayed");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ucBalanceChanges] Error loading data: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayTransactions(List<TransactionDTO> transactions)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"[ucBalanceChanges] DisplayTransactions called with {transactions.Count} transactions");
                
                pnlTransactions.Controls.Clear();

                if (transactions.Count == 0)
                {
                    Label lblNoData = new Label();
                    lblNoData.Text = "No transactions found";
                    lblNoData.Font = new Font("Segoe UI", 12F);
                    lblNoData.ForeColor = Color.Gray;
                    lblNoData.Padding = new Padding(20);
                    pnlTransactions.Controls.Add(lblNoData);
                    return;
                }

                foreach (var transaction in transactions)
                {
                    Panel transactionPanel = CreateTransactionPanel(transaction);
                    transactionPanel.Width = Math.Max(400, pnlTransactions.Width - 60); // Ngăn lỗi ArgumentException khi Width < 60
                    pnlTransactions.Controls.Add(transactionPanel);
                }
                
                System.Diagnostics.Debug.WriteLine("[ucBalanceChanges] DisplayTransactions completed successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ucBalanceChanges] Error in DisplayTransactions: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private Panel CreateTransactionPanel(TransactionDTO transaction)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"[ucBalanceChanges] Creating panel for transaction: {transaction.TransactionID}");
                
                Panel panel = new Panel();
                panel.Height = 90;
                panel.Margin = new Padding(0, 0, 0, 10);
                panel.BorderStyle = BorderStyle.FixedSingle;

                // Determine if it's a withdrawal or deposit
                bool isWithdrawal = transaction.Amount < 0 || transaction.FromAccount == currentAccountNumber;
                Color borderColor = isWithdrawal ? Color.FromArgb(211, 84, 0) : Color.FromArgb(40, 167, 69);
                Color backgroundColor = isWithdrawal ? Color.FromArgb(255, 245, 238) : Color.FromArgb(241, 248, 245);
                Color textColor = isWithdrawal ? Color.FromArgb(139, 55, 0) : Color.FromArgb(25, 110, 45);

                panel.BackColor = backgroundColor;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.ForeColor = textColor;

                // Icon circle
                PictureBox picIcon = new PictureBox();
                picIcon.Location = new Point(20, 15);
                picIcon.Size = new Size(60, 60);
                picIcon.BackColor = backgroundColor;
                picIcon.BorderStyle = BorderStyle.None;
                
                // Draw circle
                picIcon.Paint += (s, e) =>
                {
                    e.Graphics.Clear(backgroundColor);
                    e.Graphics.FillEllipse(new SolidBrush(borderColor), 0, 0, picIcon.Width, picIcon.Height);
                    
                    // Draw arrow
                    int centerX = picIcon.Width / 2;
                    int centerY = picIcon.Height / 2;
                    Pen whitePen = new Pen(Color.White, 3);
                    
                    if (isWithdrawal)
                    {
                        // Up arrow for withdrawal
                        e.Graphics.DrawLine(whitePen, centerX, centerY + 15, centerX, centerY - 15);
                        e.Graphics.DrawLine(whitePen, centerX - 8, centerY - 5, centerX, centerY - 15);
                        e.Graphics.DrawLine(whitePen, centerX + 8, centerY - 5, centerX, centerY - 15);
                    }
                    else
                    {
                        // Down arrow for deposit
                        e.Graphics.DrawLine(whitePen, centerX, centerY - 15, centerX, centerY + 15);
                        e.Graphics.DrawLine(whitePen, centerX - 8, centerY + 5, centerX, centerY + 15);
                        e.Graphics.DrawLine(whitePen, centerX + 8, centerY + 5, centerX, centerY + 15);
                    }
                };

                panel.Controls.Add(picIcon);

                // Account info
                Label lblAccountInfo = new Label();
                lblAccountInfo.Location = new Point(90, 15);
                lblAccountInfo.Size = new Size(400, 25);
                lblAccountInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                lblAccountInfo.ForeColor = textColor;
                lblAccountInfo.Text = $"Account: {transaction.FromAccount}";
                panel.Controls.Add(lblAccountInfo);

                // Description
                Label lblDescription = new Label();
                lblDescription.Location = new Point(90, 40);
                lblDescription.Size = new Size(400, 40);
                lblDescription.Font = new Font("Segoe UI", 9F);
                lblDescription.ForeColor = Color.FromArgb(100, 100, 100);
                lblDescription.Text = $"Remainder:\n{transaction.Description}";
                lblDescription.AutoEllipsis = true;
                panel.Controls.Add(lblDescription);

                // Amount
                Label lblAmount = new Label();
                lblAmount.Location = new Point(panel.Width - 150, 15);
                lblAmount.Size = new Size(130, 25);
                lblAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                lblAmount.TextAlign = ContentAlignment.TopRight;
                lblAmount.ForeColor = borderColor;
                lblAmount.Text = $"{(isWithdrawal ? "-" : "+")}{Math.Abs(transaction.Amount):F2}";
                panel.Controls.Add(lblAmount);

                // Balance after
                Label lblBalanceAfter = new Label();
                lblBalanceAfter.Location = new Point(panel.Width - 150, 40);
                lblBalanceAfter.Size = new Size(130, 20);
                lblBalanceAfter.Font = new Font("Segoe UI", 9F);
                lblBalanceAfter.ForeColor = textColor;
                lblBalanceAfter.TextAlign = ContentAlignment.TopRight;
                lblBalanceAfter.Text = $"${transaction.BalanceAfter:F2}";
                panel.Controls.Add(lblBalanceAfter);

                // Date
                Label lblDate = new Label();
                lblDate.Location = new Point(panel.Width - 150, 60);
                lblDate.Size = new Size(130, 15);
                lblDate.Font = new Font("Segoe UI", 8F);
                lblDate.TextAlign = ContentAlignment.TopRight;
                lblDate.ForeColor = Color.Gray;
                lblDate.Text = transaction.CreatedAt.ToString("yyyy-MM-dd");
                panel.Controls.Add(lblDate);
                
                System.Diagnostics.Debug.WriteLine($"[ucBalanceChanges] Panel created successfully for transaction: {transaction.TransactionID}");
                return panel;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ucBalanceChanges] Error in CreateTransactionPanel: {ex.Message}\n{ex.StackTrace}");
                return new Panel(); // Return empty panel if error occurs
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == SearchPlaceholder || string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                DisplayTransactions(allTransactions);
                return;
            }

            string searchText = txtSearch.Text.ToLower();
            
            var filtered = allTransactions.Where(t =>
                (t.Description != null && t.Description.ToLower().Contains(searchText)) ||
                (t.FromAccount != null && t.FromAccount.ToLower().Contains(searchText)) ||
                t.Amount.ToString().Contains(searchText)
            ).ToList();

            DisplayTransactions(filtered);
        }
    }
}
