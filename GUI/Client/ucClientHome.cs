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

            // Định dạng font chữ đậm cho tổng thu/chi
            if (lblTotalExpenseAmount != null)
            {
                lblTotalExpenseAmount.Font = new Font(lblTotalExpenseAmount.Font, FontStyle.Bold);
            }
            if (lblTotalIncomeAmount != null)
            {
                lblTotalIncomeAmount.Font = new Font(lblTotalIncomeAmount.Font, FontStyle.Bold);
            }

            if (LLHistory != null)
            {
                LLHistory.LinkClicked += LLHistory_LinkClicked;
            }

            if (LLPaySec != null)
            {
                LLPaySec.LinkClicked += LLPaySec_LinkClicked;
            }

            // Note: Đã xóa phần ẩn chart1 và vẽ picChart thủ công vì UI mới đang dùng trực tiếp chart1
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
                BalanceAmount = "$" + currentAccount.Balance.ToString("F2");
                CardNumber = currentAccount.AccountNumber;

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
                MessageBox.Show("Error loading balance history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransactionHistory()
        {
            if (lstHistory == null) return;
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
            if (lstSavingsItems == null) return;
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
            using (SolidBrush innerBrush = new SolidBrush(Color.SkyBlue))
            {
                g.FillEllipse(innerBrush, innerRect);
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
    }
}