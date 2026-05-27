using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Thêm thư viện này cho Chart
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

        public Action<UserControl> NavigateTo { get; set; }
        public ucClientHome()
        {
            InitializeComponent();
            if (this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;

            InitializeUI();
            LoadDataFromDatabase();

            // Subscribe để refresh khi có giao dịch mới
            UserSession.BalanceChanged += RefreshData;
        }

        /// <summary>
        /// Tự động refresh khi người dùng quay lại trang chủ
        /// </summary>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                System.Diagnostics.Debug.WriteLine("[ucClientHome] OnVisibleChanged — refreshing data");
                LoadDataFromDatabase();
            }
        }

        /// <summary>
        /// Gọi từ bên ngoài khi balance thay đổi
        /// </summary>
        public void RefreshData()
        {
            System.Diagnostics.Debug.WriteLine("[ucClientHome] RefreshData called");
            if (this.InvokeRequired)
                this.Invoke(new Action(LoadDataFromDatabase));
            else
                LoadDataFromDatabase();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw beautiful abstract background decorations (Glassmorphism style blobs)
            using (SolidBrush b1 = new SolidBrush(Color.FromArgb(25, 30, 144, 255))) // Faint Blue
            {
                e.Graphics.FillEllipse(b1, -150, -150, 600, 600);
            }
            using (SolidBrush b2 = new SolidBrush(Color.FromArgb(20, 0, 191, 255))) // Faint Cyan
            {
                e.Graphics.FillEllipse(b2, this.Width - 500, this.Height - 400, 700, 700);
            }
            using (SolidBrush b3 = new SolidBrush(Color.FromArgb(20, 138, 43, 226))) // Faint Purple
            {
                e.Graphics.FillEllipse(b3, this.Width / 2 - 300, this.Height - 350, 600, 600);
            }
        }

        private void InitializeUI()
        {
            // Setup button click event
            if (btnTransfer != null)
            {
                btnTransfer.Click += BtnTransfer_Click;
            }

            if (this.picDonutChart != null)
            {
                this.picDonutChart.Paint += PicDonutChart_Paint;
            }



            if (LLHistory != null)
            {
                LLHistory.LinkClicked += LLHistory_LinkClicked;
            }

            if (LLPaySec != null)
            {
                LLPaySec.LinkClicked += LLPaySec_LinkClicked;
            }
        }

        private void LLHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dashboard = this.ParentForm as frmClientDashboard;
            if (dashboard != null)
            {
                dashboard.NavigateToTransactionHistory();
            }
        }

        private void LLPaySec_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dashboard = this.ParentForm as frmClientDashboard;
            if (dashboard != null)
            {
                dashboard.NavigateToPaymentHistory();
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
                    MessageBox.Show("Không tìm thấy thông tin tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get customer information
                currentCustomer = AccountService.GetCustomerInfo(currentAccount.CustomerID);
                if (currentCustomer == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update UI with account info
                BalanceAmount = "$" + currentAccount.Balance.ToString("N2");
                CardNumber = currentAccount.AccountNumber;

                // Cập nhật Tiết kiệm và Khoản vay từ Database
                int totalSavings = FinancialService.GetTotalSavingsAccounts(currentCustomer.CustomerID);
                int totalLoans = FinancialService.GetTotalLoansCount(currentCustomer.CustomerID);
                SavingsAmount = totalSavings.ToString();
                LoansAmount = totalLoans.ToString();

                // Load transactions
                transactions = TransactionService.GetTransactionsByAccount(currentAccount.AccountNumber, 10);
                LoadTransactionHistory();

                // Load payment summary
                LoadPaymentSummary();

                // Load balance history for the chart
                LoadBalanceHistory();

                // Load savings items
                LoadSavingsItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var dailyBalance = new Dictionary<string, decimal>();
                    dailyBalance["Hiện tại"] = tempBal;

                    foreach (var tx in transactions)
                    {
                        string dateKey = tx.CreatedAt.ToString("MM/dd");
                        if (tx.FromAccount == currentAccount.AccountNumber)
                            tempBal += tx.Amount;
                        else if (tx.ToAccount == currentAccount.AccountNumber)
                            tempBal -= tx.Amount;
                        dailyBalance[dateKey] = tempBal;
                    }

                    string todayKey = DateTime.Today.ToString("MM/dd");
                    var sortedDates = dailyBalance.Keys
                        .Where(k => k != "Hiện tại")
                        .OrderBy(k =>
                        {
                            DateTime parsed;
                            return DateTime.TryParseExact(k, "MM/dd",
                                System.Globalization.CultureInfo.InvariantCulture,
                                System.Globalization.DateTimeStyles.None, out parsed)
                                ? parsed : DateTime.MinValue;
                        })
                        .ToList();

                    foreach (var date in sortedDates)
                    {
                        if (date == todayKey)
                        {
                            dateLabels.Add("Hiện tại");
                            balanceData.Add(dailyBalance["Hiện tại"]);
                        }
                        else
                        {
                            dateLabels.Add(date);
                            balanceData.Add(dailyBalance[date]);
                        }
                    }

                    if (!sortedDates.Contains(todayKey))
                    {
                        dateLabels.Add("Hiện tại");
                        balanceData.Add(dailyBalance["Hiện tại"]);
                    }
                }
                else
                {
                    balanceData = new List<decimal> { currentAccount.Balance, currentAccount.Balance, currentAccount.Balance };
                    dateLabels = new List<string> { DateTime.Now.AddMonths(-2).ToString("MM/dd"), DateTime.Now.AddMonths(-1).ToString("MM/dd"), "Hiện tại" };
                }

                if (chart1 != null)
                {
                    chart1.Series.Clear();
                    Series series = new Series("Số dư");

                    series.ChartType = SeriesChartType.Line;
                    series.Color = Color.FromArgb(30, 100, 220);
                    series.BorderWidth = 3;
                    series.MarkerStyle = MarkerStyle.Circle;
                    series.MarkerSize = 8;
                    series.MarkerColor = Color.FromArgb(30, 100, 220);
                    series.MarkerBorderColor = Color.White;
                    series.MarkerBorderWidth = 2;

                    for (int i = 0; i < balanceData.Count; i++)
                    {
                        series.Points.AddXY(dateLabels[i], balanceData[i]);
                    }

                    chart1.Series.Add(series);

                    var area = chart1.ChartAreas[0];
                    area.BackColor = Color.White;
                    area.AxisX.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
                    area.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
                    area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                    area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                    area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
                    area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
                    area.AxisX.LineColor = Color.FromArgb(180, 180, 180);
                    area.AxisY.LineColor = Color.FromArgb(180, 180, 180);
                    area.AxisY.LabelStyle.Format = "#,0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử số dư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransactionHistory()
        {
            if (lstHistory == null) return;
            lstHistory.Items.Clear();


            
            // Subscribe to DrawItem event (ensure single subscription)
            lstHistory.DrawItem -= LstHistory_DrawItem;
            lstHistory.DrawItem += LstHistory_DrawItem;

            if (transactions != null && transactions.Count > 0)
            {
                foreach (var transaction in transactions)
                {
                    lstHistory.Items.Add(transaction);
                }
            }
            else
            {
                lstHistory.Items.Add("Không có giao dịch nào");
            }
        }

        private void LstHistory_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            ListBox listBox = sender as ListBox;
            var item = listBox.Items[e.Index];

            // Draw subtle separator line between items
            using (Pen pen = new Pen(Color.FromArgb(150, 180, 230)))
            {
                e.Graphics.DrawLine(pen, e.Bounds.Left + 4, e.Bounds.Bottom - 1, e.Bounds.Right - 4, e.Bounds.Bottom - 1);
            }

            if (item is TransactionDTO transaction)
            {
                // Truncate description to fit in the left column
                string description = transaction.Description ?? "Giao dịch";
                if (description.Length > 14) description = description.Substring(0, 12) + "...";

                string toAcc = (transaction.ToAccount ?? "").Trim().Replace("\0", "");
                string myAcc = (currentAccount.AccountNumber ?? "").Trim().Replace("\0", "");
                bool isIncome = string.Equals(toAcc, myAcc, StringComparison.OrdinalIgnoreCase) || toAcc.Contains(myAcc);
                decimal amountValue = transaction.Amount;
                string amountStr = (isIncome ? "+" : "-") + amountValue.ToString("N0").Replace(",", ".") + " VND";
                Color amountColor = isIncome ? Color.FromArgb(20, 160, 80) : Color.FromArgb(200, 50, 40);

                string dateStr = transaction.CreatedAt.ToString("dd/MM/yyyy");

                int totalWidth = e.Bounds.Width;
                int leftPad = e.Bounds.Left + 6;
                // Column widths: description=28%, amount=38%, date=34% of total
                int descWidth  = (int)(totalWidth * 0.28);
                int amtWidth   = (int)(totalWidth * 0.38);
                int dateWidth  = totalWidth - descWidth - amtWidth;

                using (Font regularFont = new Font("Times New Roman", 9f))
                {
                    StringFormat centerLeft  = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near };
                    StringFormat centerRight = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Far };

                    // Description — left column
                    using (Brush textBrush = new SolidBrush(Color.FromArgb(30, 30, 30)))
                    {
                        e.Graphics.DrawString(description, regularFont, textBrush,
                            new Rectangle(leftPad, e.Bounds.Top, descWidth, e.Bounds.Height), centerLeft);
                    }

                    // Amount — middle column, right-aligned
                    using (Brush amountBrush = new SolidBrush(amountColor))
                    {
                        e.Graphics.DrawString(amountStr, regularFont, amountBrush,
                            new Rectangle(leftPad + descWidth, e.Bounds.Top, amtWidth, e.Bounds.Height), centerRight);
                    }

                    // Date — right column, right-aligned
                    using (Brush dateBrush = new SolidBrush(Color.FromArgb(80, 80, 100)))
                    {
                        e.Graphics.DrawString(dateStr, regularFont, dateBrush,
                            new Rectangle(leftPad + descWidth + amtWidth, e.Bounds.Top, dateWidth - 6, e.Bounds.Height), centerRight);
                    }

                    centerLeft.Dispose();
                    centerRight.Dispose();
                }
            }
            else
            {
                using (Brush textBrush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(item.ToString(), listBox.Font, textBrush, e.Bounds, new StringFormat { LineAlignment = StringAlignment.Center });
                }
            }
        }

        private void LoadSavingsItems()
        {
            if (lstSavingsItems == null) return;
            lstSavingsItems.Items.Clear();

            // Đăng ký sự kiện DrawItem
            lstSavingsItems.DrawItem -= LstSavingsItems_DrawItem;
            lstSavingsItems.DrawItem += LstSavingsItems_DrawItem;

            try
            {
                List<SavingContractsDTO> savings = FinancialService.GetSavingContractsByAccountNumber(UserSession.CurrentUser.AccountNumber);

                if (savings != null && savings.Count > 0)
                {
                    foreach (var saving in savings)
                    {
                        lstSavingsItems.Items.Add(saving);
                    }
                }
                else
                {
                    lstSavingsItems.Items.Add("Không có tài khoản tiết kiệm");
                }
            }
            catch (Exception ex)
            {
                lstSavingsItems.Items.Add("Lỗi khi tải tiết kiệm: " + ex.Message);
            }
        }

        private void LstSavingsItems_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();

            ListBox listBox = sender as ListBox;
            var item = listBox.Items[e.Index];

            // Vẽ đường gạch dưới phân cách các dòng
            using (Pen pen = new Pen(Color.FromArgb(150, 180, 230)))
            {
                e.Graphics.DrawLine(pen, e.Bounds.Left + 4, e.Bounds.Bottom - 1, e.Bounds.Right - 4, e.Bounds.Bottom - 1);
            }

            if (item is SavingContractsDTO saving)
            {
                string description = saving.SavingType ?? "Tiết kiệm";
                if (description.Length > 14) description = description.Substring(0, 12) + "...";

                decimal amountValue = saving.PrincipalAmount;
                string amountStr = amountValue.ToString("N0").Replace(",", ".") + " VND";
                Color amountColor = Color.FromArgb(20, 160, 80); // Màu xanh cho tiền tiết kiệm

                string dateStr = saving.StartDate.ToString("dd/MM/yyyy");

                int totalWidth = e.Bounds.Width;
                int leftPad = e.Bounds.Left + 6;
                int descWidth  = (int)(totalWidth * 0.35);
                int amtWidth   = (int)(totalWidth * 0.35);
                int dateWidth  = totalWidth - descWidth - amtWidth;

                using (Font regularFont = new Font("Times New Roman", 9f))
                {
                    StringFormat centerLeft = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
                    StringFormat centerRight = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };

                    using (Brush textBrush = new SolidBrush(Color.Black))
                    {
                        e.Graphics.DrawString(description, regularFont, textBrush,
                            new Rectangle(leftPad, e.Bounds.Top, descWidth, e.Bounds.Height), centerLeft);
                    }
                    using (Brush amountBrush = new SolidBrush(amountColor))
                    {
                        e.Graphics.DrawString(amountStr, regularFont, amountBrush,
                            new Rectangle(leftPad + descWidth, e.Bounds.Top, amtWidth, e.Bounds.Height), centerRight);
                    }
                    using (Brush dateBrush = new SolidBrush(Color.FromArgb(80, 80, 100)))
                    {
                        e.Graphics.DrawString(dateStr, regularFont, dateBrush,
                            new Rectangle(leftPad + descWidth + amtWidth, e.Bounds.Top, dateWidth - 6, e.Bounds.Height), centerRight);
                    }
                    
                    centerLeft.Dispose();
                    centerRight.Dispose();
                }
            }
            else
            {
                using (Brush textBrush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(item.ToString(), listBox.Font, textBrush, e.Bounds, new StringFormat { LineAlignment = StringAlignment.Center });
                }
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải tổng quan thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            Color incomeColor = Color.FromArgb(120, 190, 250);
            Color expenseColor = Color.FromArgb(20, 70, 130);

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

            // Cập nhật màu nền ở giữa vòng Donut khớp với màu nền UI
            using (SolidBrush innerBrush = new SolidBrush(Color.FromArgb(226, 240, 255)))
            {
                g.FillEllipse(innerBrush, innerRect);
            }
        }

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTransferAmount.Text))
            {
                MessageBox.Show($"Chuyển khoản {txtTransferAmount.Text} thành công!", "Chuyển khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTransferAmount.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tiền cần chuyển.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ReloadBalance()
        {
            // Đọc số dư mới nhất từ Session
            decimal currentBal = GUI.Session.UserSession.CurrentUser.Balance;

            // Gán lại vào Label trên giao diện Home
            lblBalanceAmount.Text = currentBal.ToString("N0") + " VND";
        }

        // Properties to allow binding/updating data from outside
        public string UserName
        {
            get { return lblUserName.Text; }
            set { lblUserName.Text = value; }
        }

        public string BalanceAmount
        {
            get { return lblBalanceAmount != null ? lblBalanceAmount.Text : ""; }
            set { if (lblBalanceAmount != null) lblBalanceAmount.Text = value; }
        }

        public string SavingsAmount
        {
            get { return lblSavingsAmount != null ? lblSavingsAmount.Text : ""; }
            set { if (lblSavingsAmount != null) lblSavingsAmount.Text = value; }
        }

        public string LoansAmount
        {
            get { return lblLoansAmount != null ? lblLoansAmount.Text : ""; }
            set { if (lblLoansAmount != null) lblLoansAmount.Text = value; }
        }

        public string CardNumber
        {
            get { return lblCardNumber != null ? lblCardNumber.Text : ""; }
            set { if (lblCardNumber != null) lblCardNumber.Text = value; }
        }

        private void ucClientHome_Load(object sender, EventArgs e)
        {
            // Gọi hàm cập nhật số dư ngay khi trang chủ vừa load lên
            ReloadBalance();
        }

        private void lblLoansAmount_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lstSavingsItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picDonutChart_Click(object sender, EventArgs e)
        {

        }

        private void txtTransferAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlBankCard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}