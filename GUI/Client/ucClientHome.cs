using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL.Services;
using DTO.Models;
using GUI.Session;

namespace GUI.Client
{
    public partial class ucClientHome : UserControl
    {
        // Data from SQL Server
        private AccountCustomerDTO currentAccount;
        private CustomerDTO currentCustomer;
        private List<TransactionDTO> transactions;

        private decimal currentTotalIncome = 0;
        private decimal currentTotalExpense = 0;

        // Sample data for balance history
        private List<decimal> balanceData = new List<decimal> { 600, 500, 400, 400, 500, 400, 500, 600, 1000 };
        private List<string> dateLabels = new List<string> { "06/2025", "06/2025", "06/2025", "06/2025", "06/2025", "06/2025", "06/2025", "06/2025", "06/2025" };

        public ucClientHome()
        {
            InitializeComponent();
            if (this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;

            InitializeUI();
            LoadDataFromDatabase();
        }

        private PictureBox picChart;

        private void InitializeUI()
        {
            // Setup button click event
            btnTransfer.Click += BtnTransfer_Click;

            if (this.picDonutChart != null)
            {
                this.picDonutChart.Paint += PicDonutChart_Paint;
            }
            if (this.pnlLegendExIn != null)
            {
                this.pnlLegendExIn.Paint += PnlLegendExIn_Paint;
            }

            if (lblTotalExpenseAmount != null)
            {
                lblTotalExpenseAmount.Font = new Font(lblTotalExpenseAmount.Font, FontStyle.Bold);
            }
            if (lblTotalIncomeAmount != null)
            {
                lblTotalIncomeAmount.Font = new Font(lblTotalIncomeAmount.Font, FontStyle.Bold);
            }

            // Ẩn Control Chart1 (màu xanh mặc định) che mất biểu đồ vẽ tay ở dưới
            Control[] charts = this.Controls.Find("chart1", true);
            if (charts.Length > 0)
            {
                charts[0].Visible = false;
            }

            // Dùng PictureBox bọc lên trên Panel của pnlBalanceChart để vẽ đồ thị đẹp hơn
            if (this.pnlBalanceChart != null && this.pnlBalanceChart.Panel != null)
            {
                picChart = new PictureBox();
                picChart.Dock = DockStyle.Fill;
                picChart.BackColor = Color.Transparent;
                picChart.Paint += PnlBalanceChart_Paint;
                this.pnlBalanceChart.Panel.Controls.Add(picChart);
                picChart.BringToFront();
            }
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                // Get account information
                currentAccount = AccountService.GetAccountByUsername(UserSession.CurrentUser.Username);
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
                int savingsCount = 0;
                decimal totalSavings = 0;
                decimal totalLoans = 0;

                try
                {
                    savingsCount = FinancialService.GetTotalSavingsAccounts(currentAccount.CustomerID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Warning: Could not load savings count: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    totalSavings = FinancialService.GetTotalSavings(currentAccount.CustomerID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Warning: Could not load total savings: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    totalLoans = FinancialService.GetTotalLoans(currentAccount.CustomerID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Warning: Could not load total loans: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Update financial info labels (if they exist)
                // Note: Adjust control names based on your actual Designer
                SavingsAmount = "0"; // savingsCount.ToString();
                LoansAmount = "0"; // totalLoans > 0 ? totalLoans.ToString("F2") : "0";

                // Load transactions
                transactions = TransactionService.GetTransactionsByAccount(currentAccount.AccountNumber, 10);
                LoadTransactionHistory();

                // Load payment summary
                LoadPaymentSummary();

                // Load balance history for the chart
                LoadBalanceHistory();

                // Load savings items
                LoadSavingsItems();

                // Trigger chart redraw
                if (picChart != null)
                {
                    picChart.Invalidate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBalanceHistory()
        {
            try
            {
                balanceData.Clear();
                dateLabels.Clear();

                if (transactions != null && transactions.Count > 0)
                {
                    decimal tempBal = currentAccount.Balance;

                    // Thêm điểm cuối cùng (số dư hiện tại)
                    balanceData.Insert(0, tempBal);
                    dateLabels.Insert(0, "Hiện tại");

                    // Tính ngược số dư cho từng giao dịch
                    foreach (var tx in transactions)
                    {
                        // Giá trị 'tempBal' lúc này chính là biến động số dư SAU khi diễn ra giao dịch 'tx'
                        balanceData.Insert(0, tempBal);
                        dateLabels.Insert(0, tx.CreatedAt.ToString("MM/dd"));

                        // Hoàn tác giao dịch 'tx' để truy hồi số dư TRƯỚC thời điểm thực hiện 'tx'
                        if (tx.FromAccount == currentAccount.AccountNumber)
                        {
                            tempBal += tx.Amount; // Nếu đã chuyển đi, thì ngày trước số dư phải cao hơn
                        }
                        else if (tx.ToAccount == currentAccount.AccountNumber)
                        {
                            tempBal -= tx.Amount; // Nếu đã nhận, thì ngày trước số dư thấp hơn
                        }
                    }
                }
                else
                {
                    // Trạng thái mặc định nếu chưa có giao dịch biểu diễn thành một đường đi ngang
                    balanceData = new List<decimal> { currentAccount.Balance, currentAccount.Balance, currentAccount.Balance };
                    dateLabels = new List<string> { DateTime.Now.AddMonths(-2).ToString("MM/dd"), DateTime.Now.AddMonths(-1).ToString("MM/dd"), "Hiện tại" };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading balance history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                List<SavingContractsDTO> savings = FinancialService.GetSavingContractsByAccountNumber(UserSession.CurrentUser.AccountNumber);

                if (savings != null && savings.Count > 0)
                {
                    foreach (var saving in savings)
                    {
                        string item = $"{saving.SavingType.PadRight(20)} ${saving.PrincipalAmount.ToString("F2")}";
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

        private void LoadPaymentSummary()
        {
            try
            {
                if (currentAccount != null)
                {
                    currentTotalIncome = TransactionService.GetTotalIncome(currentAccount.AccountNumber);
                    currentTotalExpense = TransactionService.GetTotalExpense(currentAccount.AccountNumber);

                    if (lblTotalIncomeAmount != null)
                        lblTotalIncomeAmount.Text = "$" + currentTotalIncome.ToString("N2");

                    if (lblTotalExpenseAmount != null)
                        lblTotalExpenseAmount.Text = "$" + currentTotalExpense.ToString("N2");

                    if (picDonutChart != null)
                        picDonutChart.Invalidate();

                    if (pnlLegendExIn != null)
                        pnlLegendExIn.Invalidate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payment summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PicDonutChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Control chart = sender as Control;
            if (chart == null) return;

            int width = chart.Width;
            int height = chart.Height;

            int size = Math.Min(width, height) - 20;
            if (size <= 0) return;

            Rectangle rect = new Rectangle((width - size) / 2, (height - size) / 2, size, size);

            decimal total = currentTotalIncome + currentTotalExpense;

            Color incomeColor = Color.FromArgb(120, 190, 250); // Light blue
            Color expenseColor = Color.FromArgb(20, 70, 130);  // Dark blue

            if (total == 0)
            {
                using (SolidBrush emptyBrush = new SolidBrush(Color.LightGray))
                {
                    g.FillEllipse(emptyBrush, rect);
                }
            }
            else
            {
                float expenseAngle = (float)((currentTotalExpense / total) * 360);
                float incomeAngle = 360 - expenseAngle;

                using (SolidBrush expenseBrush = new SolidBrush(expenseColor))
                {
                    g.FillPie(expenseBrush, rect, -90, expenseAngle);
                }

                using (SolidBrush incomeBrush = new SolidBrush(incomeColor))
                {
                    g.FillPie(incomeBrush, rect, -90 + expenseAngle, incomeAngle);
                }
            }

            int innerSize = (int)(size * 0.5);
            Rectangle innerRect = new Rectangle((width - innerSize) / 2, (height - innerSize) / 2, innerSize, innerSize);

            using (SolidBrush innerBrush = new SolidBrush(Color.SkyBlue))
            {
                g.FillEllipse(innerBrush, innerRect);
            }

            if (total > 0)
            {
                using (Font font = new Font("Arial", 8, FontStyle.Regular))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    float expenseAngle = (float)((currentTotalExpense / total) * 360);

                    if (currentTotalExpense > 0)
                    {
                        float expCenterAngle = -90 + (expenseAngle / 2);
                        DrawStringAtAngle(g, "Expense", font, textBrush, rect, innerSize, expCenterAngle);
                    }

                    if (currentTotalIncome > 0)
                    {
                        float incCenterAngle = -90 + expenseAngle + ((360 - expenseAngle) / 2);
                        DrawStringAtAngle(g, "Income", font, textBrush, rect, innerSize, incCenterAngle);
                    }
                }
            }
        }

        private void DrawStringAtAngle(Graphics g, string text, Font font, Brush brush, Rectangle rect, int innerSize, float angle)
        {
            double rad = angle * Math.PI / 180;
            int radius = (rect.Width / 2 + innerSize / 2) / 2;
            int cx = rect.X + rect.Width / 2;
            int cy = rect.Y + rect.Height / 2;

            float x = cx + (float)(radius * Math.Cos(rad));
            float y = cy + (float)(radius * Math.Sin(rad));

            SizeF size = g.MeasureString(text, font);
            g.DrawString(text, font, brush, x - size.Width / 2, y - size.Height / 2);
        }

        private void PnlLegendExIn_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Color incomeColor = Color.FromArgb(120, 190, 250); 
            Color expenseColor = Color.FromArgb(20, 70, 130);

            int yIncome = lblLegendIncome != null ? lblLegendIncome.Location.Y + (lblLegendIncome.Height - 12) / 2 : 12;
            g.FillEllipse(new SolidBrush(incomeColor), new Rectangle(5, yIncome, 12, 12));

            int yExpense = lblLegendExpense != null ? lblLegendExpense.Location.Y + (lblLegendExpense.Height - 12) / 2 : 37;
            g.FillEllipse(new SolidBrush(expenseColor), new Rectangle(5, yExpense, 12, 12));
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
            get { return lblUserName.Text; }
            set { lblUserName.Text = value; }
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

        private void PnlBalanceChart_Paint(object sender, PaintEventArgs e)
        {
            if (balanceData == null || balanceData.Count == 0)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Control panel = sender as Control;
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
            Pen chartLinePen = new Pen(Color.White, 3); // Cập nhật sang viền trắng để giống mẫu
            Brush pointBrush = new SolidBrush(Color.DodgerBlue);

            List<PointF> points = new List<PointF>();

            for (int i = 0; i < balanceData.Count; i++)
            {
                decimal value = balanceData[i];
                int x = paddingLeft + (int)(i * (double)chartWidth / (balanceData.Count - 1));
                int y = paddingTop + chartHeight - (int)((value - minValue) / valueRange * chartHeight);

                points.Add(new PointF(x, y));
            }

            // Fill gradient under curve
            if (points.Count > 1)
            {
                using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddCurve(points.ToArray(), 0.3f); // Thêm điểm vẽ đường uốn lượn

                    // Thêm cạnh đi xuống và đóng vùng để tô màu
                    path.AddLine(points[points.Count - 1].X, paddingTop + chartHeight, points[points.Count - 1].X, paddingTop + chartHeight);
                    path.AddLine(points[points.Count - 1].X, paddingTop + chartHeight, points[0].X, paddingTop + chartHeight);
                    path.CloseFigure();

                    // Vẽ Gradient ngả từ trên xanh xuống nhạt dần
                    Rectangle gradientRect = new Rectangle(paddingLeft, paddingTop, chartWidth, chartHeight);
                    if (gradientRect.Height > 0 && gradientRect.Width > 0)
                    {
                        using (System.Drawing.Drawing2D.LinearGradientBrush fillBrush = 
                               new System.Drawing.Drawing2D.LinearGradientBrush(
                               gradientRect, Color.FromArgb(180, 50, 150, 255), Color.FromArgb(20, 50, 150, 255), 
                               System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                        {
                            g.FillPath(fillBrush, path);
                        }
                    }
                }

                // Vẽ đường curve phía trên cùng
                g.DrawCurve(chartLinePen, points.ToArray(), 0.3f);
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

        private void pnlBalanceChart_Paint(object sender, PaintEventArgs e)
        {
            // This event is handled by PnlBalanceChart_Paint for pnlBalanceChart.Panel
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

        private void kryptonGroup3_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTransferAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSavings_Click(object sender, EventArgs e)
        {

        }
    }
}
