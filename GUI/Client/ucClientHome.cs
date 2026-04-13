using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL.Services;
using DTO.Models;

namespace GUI.Client
{
    public partial class ucClientHome : UserControl
    {
        // Data from SQL Server
        private string currentUsername;
        private AccountDTO currentAccount;
        private CustomerDTO currentCustomer;
        private List<TransactionDTO> transactions;

        // Sample data for balance history
        private List<decimal> balanceData = new List<decimal> { 600, 500, 400, 400, 500, 400, 500, 600, 1000 };
        private List<string> dateLabels = new List<string> { "06/2025", "06/2025", "06/2025", "06/2025", "06/2025", "06/2025", "06/2025", "06/2025", "06/2025" };

        public ucClientHome()
        {
            InitializeComponent();
            InitializeUI();
        }

        public ucClientHome(string username)
        {
            InitializeComponent();
            currentUsername = username;
            InitializeUI();
            LoadDataFromDatabase();
        }

        private void InitializeUI()
        {
            // Setup button click event
            btnTransfer.Click += BtnTransfer_Click;

            // Ẩn Control Chart1 (màu xanh mặc định) che mất biểu đồ vẽ tay ở dưới
            Control[] charts = this.Controls.Find("chart1", true);
            if (charts.Length > 0)
            {
                charts[0].Visible = false;
            }
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                // Get account information
                currentAccount = AccountService.GetAccountByUsername(currentUsername);
                if (currentAccount == null)
                {
                    MessageBox.Show("Cannot find account information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get customer information
                currentCustomer = AccountService.GetCustomerInfo(currentAccount.CustomerID);
                if (currentCustomer == null)
                {
                    MessageBox.Show("Cannot find customer information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update UI with account info
                UserName = currentCustomer.FullName;
                BalanceAmount = "$" + currentAccount.Balance.ToString("F2");
                CardNumber = currentAccount.AccountNumber;

                // Get financial information (savings and loans)
                int savingsCount = FinancialService.GetTotalSavingsAccounts(currentAccount.CustomerID);
                decimal totalSavings = FinancialService.GetTotalSavings(currentAccount.CustomerID);
                decimal totalLoans = FinancialService.GetTotalLoans(currentAccount.CustomerID);

                // Update financial info labels (if they exist)
                // Note: Adjust control names based on your actual Designer
                SavingsAmount = savingsCount.ToString();
                LoansAmount = totalLoans > 0 ? totalLoans.ToString("F2") : "0";

                // Load transactions
                transactions = TransactionService.GetTransactionsByAccount(currentAccount.AccountNumber, 10);
                LoadTransactionHistory();

                // Load savings items
                LoadSavingsItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransactionHistory()
        {
            lstHistory.Items.Clear();

            if (transactions != null && transactions.Count > 0)
            {
                foreach (var transaction in transactions)
                {
                    string type = transaction.Description ?? "Transaction";
                    lstHistory.Items.Add(type);
                    lstHistory.Items.Add("$" + transaction.Amount.ToString("F2"));
                    lstHistory.Items.Add(transaction.CreatedAt.ToString("yyyy-MM-dd"));
                    lstHistory.Items.Add("");
                }
            }
            else
            {
                lstHistory.Items.Add("No transactions found");
            }
        }

        private void LoadSavingsItems()
        {
            lstSavingsItems.Items.Clear();

            try
            {
                List<FinancialProductDTO> savings = FinancialService.GetSavingsByCustomer(currentAccount.CustomerID);

                if (savings != null && savings.Count > 0)
                {
                    foreach (var saving in savings)
                    {
                        string item = $"{saving.ProductName.PadRight(30)} ${saving.Amount.ToString("F2")}";
                        lstSavingsItems.Items.Add(item);
                    }
                }
                else
                {
                    lstSavingsItems.Items.Add("No savings accounts");
                }
            }
            catch (Exception ex)
            {
                lstSavingsItems.Items.Add("Error loading savings: " + ex.Message);
            }
        }

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTransferAmount.Text))
            {
                MessageBox.Show($"Transfer of {txtTransferAmount.Text} initiated successfully!", "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTransferAmount.Clear();
            }
            else
            {
                MessageBox.Show("Please enter an amount to transfer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Properties to allow binding/updating data from outside
        public string UserName
        {
            get { return lblCardHolder.Text; }
            set { lblCardHolder.Text = value; }
        }

        public string BalanceAmount
        {
            get { return lblBalanceAmount.Text; }
            set { lblBalanceAmount.Text = value; }
        }

        public string SavingsAmount
        {
            get { return lblSavingsAmount.Text; }
            set { lblSavingsAmount.Text = value; }
        }

        public string LoansAmount
        {
            get { return lblLoansAmount.Text; }
            set { lblLoansAmount.Text = value; }
        }

        public string CardNumber
        {
            get { return lblCardNumber.Text; }
            set { lblCardNumber.Text = value; }
        }

        private void pnlBalanceChart_Paint(object sender, PaintEventArgs e)
        {
            if (balanceData == null || balanceData.Count == 0)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Panel panel = sender as Panel;
            if (panel == null) return;

            int width = panel.Width;
            int height = panel.Height;

            // Padding
            int paddingLeft = 50;
            int paddingRight = 20;
            int paddingTop = 30;
            int paddingBottom = 40;

            int chartWidth = width - paddingLeft - paddingRight;
            int chartHeight = height - paddingTop - paddingBottom;

            // Find min and max values
            decimal maxValue = balanceData.Max();
            decimal minValue = balanceData.Min();
            decimal valueRange = maxValue - minValue;
            if (valueRange == 0) valueRange = 1;

            // Draw Y-axis labels and grid lines
            Brush gridBrush = new SolidBrush(Color.FromArgb(220, 230, 245)); // Xanh nhạt cho lưới
            Brush labelBrush = new SolidBrush(Color.FromArgb(50, 100, 180)); // Xanh đậm cho nhãn
            Font labelFont = new Font("Arial", 8);

            int gridLines = 5;
            for (int i = 0; i <= gridLines; i++)
            {
                decimal value = minValue + (valueRange / gridLines) * i;
                int y = paddingTop + chartHeight - (int)((value - minValue) / valueRange * chartHeight);

                // Draw grid line
                g.DrawLine(new Pen(gridBrush), paddingLeft, y, width - paddingRight, y);

                // Draw Y-axis label
                string label = ((int)value).ToString();
                SizeF labelSize = g.MeasureString(label, labelFont);
                g.DrawString(label, labelFont, labelBrush, paddingLeft - labelSize.Width - 5, y - labelSize.Height / 2);
            }

            // Draw X-axis
            g.DrawLine(new Pen(Color.FromArgb(220, 230, 245), 2), paddingLeft, paddingTop + chartHeight, width - paddingRight, paddingTop + chartHeight);

            // Draw data points and lines
            Pen chartLinePen = new Pen(Color.DodgerBlue, 2); // Màu xanh cho đường biểu đồ
            Brush pointBrush = new SolidBrush(Color.DodgerBlue); // Màu xanh cho điểm

            List<PointF> points = new List<PointF>();

            for (int i = 0; i < balanceData.Count; i++)
            {
                decimal value = balanceData[i];
                int x = paddingLeft + (int)(i * (double)chartWidth / (balanceData.Count - 1));
                int y = paddingTop + chartHeight - (int)((value - minValue) / valueRange * chartHeight);

                points.Add(new PointF(x, y));
            }

            // Draw connecting lines
            for (int i = 0; i < points.Count - 1; i++)
            {
                g.DrawLine(chartLinePen, points[i], points[i + 1]);
            }

            // Draw points
            for (int i = 0; i < points.Count; i++)
            {
                g.FillEllipse(pointBrush, points[i].X - 4, points[i].Y - 4, 8, 8);
                g.DrawEllipse(new Pen(Color.White, 2), points[i].X - 4, points[i].Y - 4, 8, 8);
            }

            // Draw X-axis labels (Month)
            for (int i = 0; i < dateLabels.Count; i++)
            {
                int x = paddingLeft + (int)(i * (double)chartWidth / (balanceData.Count - 1));
                string label = dateLabels[i];
                SizeF labelSize = g.MeasureString(label, labelFont);
                g.DrawString(label, labelFont, labelBrush, x - labelSize.Width / 2, paddingTop + chartHeight + 5);
            }

            // Cleanup
            chartLinePen.Dispose();
            pointBrush.Dispose();
            gridBrush.Dispose();
            labelBrush.Dispose();
            labelFont.Dispose();
        }

        private void lblViewAll1_Click(object sender, EventArgs e)
        {

        }

        private void pnlBalanceCards_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblBalanceHistoryTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblMoreBanking_Click(object sender, EventArgs e)
        {

        }

        private void ucClientHome_Load(object sender, EventArgs e)
        {

        }

        private void pnlMyBalance_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlHistoryTransactions_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTransfer_Click_1(object sender, EventArgs e)
        {

        }

        private void LLHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pnlMyLoans_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
