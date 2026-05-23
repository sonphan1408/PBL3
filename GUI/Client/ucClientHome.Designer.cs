namespace GUI.Client
{


    partial class ucClientHome
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.LLPayment = new System.Windows.Forms.LinkLabel();
            this.pnlTotals = new System.Windows.Forms.Panel();
            this.MoneyTotalIn = new System.Windows.Forms.Label();
            this.MoneyTotalEx = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblTitleBalHist = new System.Windows.Forms.Label();
            this.pnlBalance = new GUI.Client.RoundedPanel();
            this.lblTitleBalance = new System.Windows.Forms.Label();
            this.lblBalanceAmount = new System.Windows.Forms.Label();
            this.pnlSavings = new GUI.Client.RoundedPanel();
            this.lblTitleSavings = new System.Windows.Forms.Label();
            this.lblSavingsAmount = new System.Windows.Forms.Label();
            this.pnlLoans = new GUI.Client.RoundedPanel();
            this.lblTitleLoans = new System.Windows.Forms.Label();
            this.lblLoansAmount = new System.Windows.Forms.Label();
            this.pnlBankCard = new GUI.Client.RoundedPanel();
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.pnlChart = new GUI.Client.RoundedPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTransHist = new GUI.Client.RoundedPanel();
            this.lblTitleTransHist = new System.Windows.Forms.Label();
            this.LLHistory = new System.Windows.Forms.LinkLabel();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.pnlPayment = new GUI.Client.RoundedPanel();
            this.lblTitlePayment = new System.Windows.Forms.Label();
            this.LLPaySec = new System.Windows.Forms.LinkLabel();
            this.picDonutChart = new System.Windows.Forms.PictureBox();
            this.LBTotalEx = new System.Windows.Forms.Label();
            this.lblTotalExpenseAmount = new System.Windows.Forms.Label();
            this.LBTotalIn = new System.Windows.Forms.Label();
            this.lblTotalIncomeAmount = new System.Windows.Forms.Label();
            this.lblSeparatorLine = new System.Windows.Forms.Label();
            this.picIncomeIndicator = new System.Windows.Forms.PictureBox();
            this.LabelIcome = new System.Windows.Forms.Label();
            this.picExpenseIndicator = new System.Windows.Forms.PictureBox();
            this.labelExpense = new System.Windows.Forms.Label();
            this.pnlSavingsList = new GUI.Client.RoundedPanel();
            this.lblTitleSavingsList = new System.Windows.Forms.Label();
            this.LLSaving = new System.Windows.Forms.LinkLabel();
            this.lstSavingsItems = new System.Windows.Forms.ListBox();
            this.pnlTransfer = new GUI.Client.RoundedPanel();
            this.lblTitleTransfer = new System.Windows.Forms.Label();
            this.txtTransferAmount = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.pnlTotals.SuspendLayout();
            this.pnlBalance.SuspendLayout();
            this.pnlSavings.SuspendLayout();
            this.pnlLoans.SuspendLayout();
            this.pnlBankCard.SuspendLayout();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnlTransHist.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDonutChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIncomeIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExpenseIndicator)).BeginInit();
            this.pnlSavingsList.SuspendLayout();
            this.pnlTransfer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLegend
            // 
            this.pnlLegend.Location = new System.Drawing.Point(236, 147);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(129, 62);
            this.pnlLegend.TabIndex = 8;
            this.pnlLegend.Visible = false;
            // 
            // LLPayment
            // 
            this.LLPayment.AutoSize = true;
            this.LLPayment.Location = new System.Drawing.Point(258, 13);
            this.LLPayment.Name = "LLPayment";
            this.LLPayment.Size = new System.Drawing.Size(81, 16);
            this.LLPayment.TabIndex = 2;
            this.LLPayment.TabStop = true;
            this.LLPayment.Text = "Xem tất cả";
            // 
            // pnlTotals
            // 
            this.pnlTotals.Controls.Add(this.MoneyTotalIn);
            this.pnlTotals.Controls.Add(this.MoneyTotalEx);
            this.pnlTotals.Location = new System.Drawing.Point(236, 32);
            this.pnlTotals.Name = "pnlTotals";
            this.pnlTotals.Size = new System.Drawing.Size(129, 100);
            this.pnlTotals.TabIndex = 8;
            this.pnlTotals.Visible = false;
            // 
            // MoneyTotalIn
            // 
            this.MoneyTotalIn.AutoSize = true;
            this.MoneyTotalIn.Location = new System.Drawing.Point(22, 76);
            this.MoneyTotalIn.Name = "MoneyTotalIn";
            this.MoneyTotalIn.Size = new System.Drawing.Size(69, 16);
            this.MoneyTotalIn.TabIndex = 9;
            this.MoneyTotalIn.Text = "$1,100.00";
            // 
            // MoneyTotalEx
            // 
            this.MoneyTotalEx.AutoSize = true;
            this.MoneyTotalEx.Location = new System.Drawing.Point(13, 29);
            this.MoneyTotalEx.Name = "MoneyTotalEx";
            this.MoneyTotalEx.Size = new System.Drawing.Size(58, 16);
            this.MoneyTotalEx.TabIndex = 9;
            this.MoneyTotalEx.Text = "$417.00";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Arial", 10F);
            this.lblUserName.Location = new System.Drawing.Point(52, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(80, 16);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "User Name";
            // 
            // lblTitleBalHist
            // 
            this.lblTitleBalHist.AutoSize = true;
            this.lblTitleBalHist.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitleBalHist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitleBalHist.Location = new System.Drawing.Point(20, 157);
            this.lblTitleBalHist.Name = "lblTitleBalHist";
            this.lblTitleBalHist.Size = new System.Drawing.Size(195, 40);
            this.lblTitleBalHist.TabIndex = 22;
            this.lblTitleBalHist.Text = "Lịch sử số dư";
            // 
            // pnlBalance
            // 
            this.pnlBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlBalance.BorderRadius = 20;
            this.pnlBalance.Controls.Add(this.lblTitleBalance);
            this.pnlBalance.Controls.Add(this.lblBalanceAmount);
            this.pnlBalance.DrawBankCardPattern = false;
            this.pnlBalance.GradientAngle = 90F;
            this.pnlBalance.GradientEndColor = System.Drawing.Color.White;
            this.pnlBalance.GradientStartColor = System.Drawing.Color.White;
            this.pnlBalance.Location = new System.Drawing.Point(22, 40);
            this.pnlBalance.Name = "pnlBalance";
            this.pnlBalance.Size = new System.Drawing.Size(240, 100);
            this.pnlBalance.TabIndex = 18;
            this.pnlBalance.UseGradient = false;
            // 
            // lblTitleBalance
            // 
            this.lblTitleBalance.AutoSize = true;
            this.lblTitleBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitleBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTitleBalance.Location = new System.Drawing.Point(20, 15);
            this.lblTitleBalance.Name = "lblTitleBalance";
            this.lblTitleBalance.Size = new System.Drawing.Size(149, 30);
            this.lblTitleBalance.TabIndex = 0;
            this.lblTitleBalance.Text = "Số dư của tôi";
            // 
            // lblBalanceAmount
            // 
            this.lblBalanceAmount.AutoSize = true;
            this.lblBalanceAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblBalanceAmount.Font = new System.Drawing.Font("Times New Roman", 18.27692F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblBalanceAmount.Location = new System.Drawing.Point(20, 45);
            this.lblBalanceAmount.Name = "lblBalanceAmount";
            this.lblBalanceAmount.Size = new System.Drawing.Size(127, 37);
            this.lblBalanceAmount.TabIndex = 1;
            this.lblBalanceAmount.Text = "$424.38";
            // 
            // pnlSavings
            // 
            this.pnlSavings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlSavings.BorderRadius = 20;
            this.pnlSavings.Controls.Add(this.lblTitleSavings);
            this.pnlSavings.Controls.Add(this.lblSavingsAmount);
            this.pnlSavings.DrawBankCardPattern = false;
            this.pnlSavings.GradientAngle = 90F;
            this.pnlSavings.GradientEndColor = System.Drawing.Color.White;
            this.pnlSavings.GradientStartColor = System.Drawing.Color.White;
            this.pnlSavings.Location = new System.Drawing.Point(286, 40);
            this.pnlSavings.Name = "pnlSavings";
            this.pnlSavings.Size = new System.Drawing.Size(240, 100);
            this.pnlSavings.TabIndex = 19;
            this.pnlSavings.UseGradient = false;
            // 
            // lblTitleSavings
            // 
            this.lblTitleSavings.AutoSize = true;
            this.lblTitleSavings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitleSavings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTitleSavings.Location = new System.Drawing.Point(20, 15);
            this.lblTitleSavings.Name = "lblTitleSavings";
            this.lblTitleSavings.Size = new System.Drawing.Size(185, 30);
            this.lblTitleSavings.TabIndex = 0;
            this.lblTitleSavings.Text = "Tiết kiệm của tôi";
            // 
            // lblSavingsAmount
            // 
            this.lblSavingsAmount.AutoSize = true;
            this.lblSavingsAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblSavingsAmount.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblSavingsAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblSavingsAmount.Location = new System.Drawing.Point(20, 45);
            this.lblSavingsAmount.Name = "lblSavingsAmount";
            this.lblSavingsAmount.Size = new System.Drawing.Size(35, 38);
            this.lblSavingsAmount.TabIndex = 1;
            this.lblSavingsAmount.Text = "1";
            // 
            // pnlLoans
            // 
            this.pnlLoans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlLoans.BorderRadius = 20;
            this.pnlLoans.Controls.Add(this.lblTitleLoans);
            this.pnlLoans.Controls.Add(this.lblLoansAmount);
            this.pnlLoans.DrawBankCardPattern = false;
            this.pnlLoans.GradientAngle = 90F;
            this.pnlLoans.GradientEndColor = System.Drawing.Color.White;
            this.pnlLoans.GradientStartColor = System.Drawing.Color.White;
            this.pnlLoans.Location = new System.Drawing.Point(565, 40);
            this.pnlLoans.Name = "pnlLoans";
            this.pnlLoans.Size = new System.Drawing.Size(245, 100);
            this.pnlLoans.TabIndex = 20;
            this.pnlLoans.UseGradient = false;
            // 
            // lblTitleLoans
            // 
            this.lblTitleLoans.AutoSize = true;
            this.lblTitleLoans.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitleLoans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTitleLoans.Location = new System.Drawing.Point(20, 15);
            this.lblTitleLoans.Name = "lblTitleLoans";
            this.lblTitleLoans.Size = new System.Drawing.Size(196, 30);
            this.lblTitleLoans.TabIndex = 0;
            this.lblTitleLoans.Text = "Khoản vay của tôi";
            // 
            // lblLoansAmount
            // 
            this.lblLoansAmount.AutoSize = true;
            this.lblLoansAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblLoansAmount.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblLoansAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblLoansAmount.Location = new System.Drawing.Point(20, 45);
            this.lblLoansAmount.Name = "lblLoansAmount";
            this.lblLoansAmount.Size = new System.Drawing.Size(35, 38);
            this.lblLoansAmount.TabIndex = 1;
            this.lblLoansAmount.Text = "0";
            this.lblLoansAmount.Click += new System.EventHandler(this.lblLoansAmount_Click);
            // 
            // pnlBankCard
            // 
            this.pnlBankCard.BackColor = System.Drawing.Color.White;
            this.pnlBankCard.BorderRadius = 25;
            this.pnlBankCard.Controls.Add(this.lblBankName);
            this.pnlBankCard.Controls.Add(this.lblCardNumber);
            this.pnlBankCard.DrawBankCardPattern = true;
            this.pnlBankCard.GradientAngle = 45F;
            this.pnlBankCard.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(150)))), ((int)(((byte)(220)))));
            this.pnlBankCard.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(80)))), ((int)(((byte)(160)))));
            this.pnlBankCard.Location = new System.Drawing.Point(826, 40);
            this.pnlBankCard.Name = "pnlBankCard";
            this.pnlBankCard.Size = new System.Drawing.Size(322, 130);
            this.pnlBankCard.TabIndex = 21;
            this.pnlBankCard.UseGradient = true;
            this.pnlBankCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBankCard_Paint);
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.BackColor = System.Drawing.Color.Transparent;
            this.lblBankName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBankName.ForeColor = System.Drawing.Color.White;
            this.lblBankName.Location = new System.Drawing.Point(20, 15);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(150, 36);
            this.lblBankName.TabIndex = 0;
            this.lblBankName.Text = "HTTS Bank";
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblCardNumber.Font = new System.Drawing.Font("Times New Roman", 19.93846F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardNumber.ForeColor = System.Drawing.Color.White;
            this.lblCardNumber.Location = new System.Drawing.Point(20, 75);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(180, 41);
            this.lblCardNumber.TabIndex = 1;
            this.lblCardNumber.Text = "123220178";
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlChart.BorderRadius = 20;
            this.pnlChart.Controls.Add(this.chart1);
            this.pnlChart.DrawBankCardPattern = false;
            this.pnlChart.GradientAngle = 90F;
            this.pnlChart.GradientEndColor = System.Drawing.Color.White;
            this.pnlChart.GradientStartColor = System.Drawing.Color.White;
            this.pnlChart.Location = new System.Drawing.Point(27, 215);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(699, 220);
            this.pnlChart.TabIndex = 23;
            this.pnlChart.UseGradient = false;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(10, 10);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(679, 200);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // pnlTransHist
            // 
            this.pnlTransHist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlTransHist.BorderRadius = 20;
            this.pnlTransHist.Controls.Add(this.lblTitleTransHist);
            this.pnlTransHist.Controls.Add(this.LLHistory);
            this.pnlTransHist.Controls.Add(this.lstHistory);
            this.pnlTransHist.DrawBankCardPattern = false;
            this.pnlTransHist.GradientAngle = 90F;
            this.pnlTransHist.GradientEndColor = System.Drawing.Color.White;
            this.pnlTransHist.GradientStartColor = System.Drawing.Color.White;
            this.pnlTransHist.Location = new System.Drawing.Point(768, 215);
            this.pnlTransHist.Name = "pnlTransHist";
            this.pnlTransHist.Size = new System.Drawing.Size(380, 220);
            this.pnlTransHist.TabIndex = 24;
            this.pnlTransHist.UseGradient = false;
            // 
            // lblTitleTransHist
            // 
            this.lblTitleTransHist.AutoSize = true;
            this.lblTitleTransHist.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleTransHist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitleTransHist.Location = new System.Drawing.Point(20, 15);
            this.lblTitleTransHist.Name = "lblTitleTransHist";
            this.lblTitleTransHist.Size = new System.Drawing.Size(216, 36);
            this.lblTitleTransHist.TabIndex = 0;
            this.lblTitleTransHist.Text = "Lịch sử giao dịch";
            // 
            // LLHistory
            // 
            this.LLHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LLHistory.AutoSize = true;
            this.LLHistory.BackColor = System.Drawing.Color.Transparent;
            this.LLHistory.Font = new System.Drawing.Font("Times New Roman", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLHistory.Location = new System.Drawing.Point(280, 20);
            this.LLHistory.Name = "LLHistory";
            this.LLHistory.Size = new System.Drawing.Size(88, 20);
            this.LLHistory.TabIndex = 3;
            this.LLHistory.TabStop = true;
            this.LLHistory.Text = "Xem tất cả";
            // 
            // lstHistory
            // 
            this.lstHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.lstHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstHistory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstHistory.Font = new System.Drawing.Font("Times New Roman", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHistory.ItemHeight = 44;
            this.lstHistory.Location = new System.Drawing.Point(10, 50);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(360, 132);
            this.lstHistory.TabIndex = 0;
            // 
            // pnlPayment
            // 
            this.pnlPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlPayment.BorderRadius = 20;
            this.pnlPayment.Controls.Add(this.lblTitlePayment);
            this.pnlPayment.Controls.Add(this.LLPaySec);
            this.pnlPayment.Controls.Add(this.picDonutChart);
            this.pnlPayment.Controls.Add(this.LBTotalEx);
            this.pnlPayment.Controls.Add(this.lblTotalExpenseAmount);
            this.pnlPayment.Controls.Add(this.LBTotalIn);
            this.pnlPayment.Controls.Add(this.lblTotalIncomeAmount);
            this.pnlPayment.Controls.Add(this.lblSeparatorLine);
            this.pnlPayment.Controls.Add(this.picIncomeIndicator);
            this.pnlPayment.Controls.Add(this.LabelIcome);
            this.pnlPayment.Controls.Add(this.picExpenseIndicator);
            this.pnlPayment.Controls.Add(this.labelExpense);
            this.pnlPayment.DrawBankCardPattern = false;
            this.pnlPayment.GradientAngle = 90F;
            this.pnlPayment.GradientEndColor = System.Drawing.Color.White;
            this.pnlPayment.GradientStartColor = System.Drawing.Color.White;
            this.pnlPayment.Location = new System.Drawing.Point(27, 465);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(320, 214);
            this.pnlPayment.TabIndex = 25;
            this.pnlPayment.UseGradient = false;
            // 
            // lblTitlePayment
            // 
            this.lblTitlePayment.AutoSize = true;
            this.lblTitlePayment.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitlePayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitlePayment.Location = new System.Drawing.Point(20, 15);
            this.lblTitlePayment.Name = "lblTitlePayment";
            this.lblTitlePayment.Size = new System.Drawing.Size(155, 36);
            this.lblTitlePayment.TabIndex = 0;
            this.lblTitlePayment.Text = "Thanh toán";
            // 
            // LLPaySec
            // 
            this.LLPaySec.AutoSize = true;
            this.LLPaySec.BackColor = System.Drawing.Color.Transparent;
            this.LLPaySec.Font = new System.Drawing.Font("Times New Roman", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLPaySec.Location = new System.Drawing.Point(220, 20);
            this.LLPaySec.Name = "LLPaySec";
            this.LLPaySec.Size = new System.Drawing.Size(88, 20);
            this.LLPaySec.TabIndex = 16;
            this.LLPaySec.TabStop = true;
            this.LLPaySec.Text = "Xem tất cả";
            // 
            // picDonutChart
            // 
            this.picDonutChart.BackColor = System.Drawing.Color.Transparent;
            this.picDonutChart.Location = new System.Drawing.Point(20, 60);
            this.picDonutChart.Name = "picDonutChart";
            this.picDonutChart.Size = new System.Drawing.Size(120, 120);
            this.picDonutChart.TabIndex = 17;
            this.picDonutChart.TabStop = false;
            this.picDonutChart.Click += new System.EventHandler(this.picDonutChart_Click);
            // 
            // LBTotalEx
            // 
            this.LBTotalEx.AutoSize = true;
            this.LBTotalEx.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LBTotalEx.Location = new System.Drawing.Point(155, 51);
            this.LBTotalEx.Name = "LBTotalEx";
            this.LBTotalEx.Size = new System.Drawing.Size(110, 23);
            this.LBTotalEx.TabIndex = 9;
            this.LBTotalEx.Text = "Tổng chi tiêu";
            // 
            // lblTotalExpenseAmount
            // 
            this.lblTotalExpenseAmount.AutoSize = true;
            this.lblTotalExpenseAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalExpenseAmount.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalExpenseAmount.Location = new System.Drawing.Point(155, 74);
            this.lblTotalExpenseAmount.Name = "lblTotalExpenseAmount";
            this.lblTotalExpenseAmount.Size = new System.Drawing.Size(55, 22);
            this.lblTotalExpenseAmount.TabIndex = 1;
            this.lblTotalExpenseAmount.Text = "$0.00";
            // 
            // LBTotalIn
            // 
            this.LBTotalIn.AutoSize = true;
            this.LBTotalIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LBTotalIn.Location = new System.Drawing.Point(155, 98);
            this.LBTotalIn.Name = "LBTotalIn";
            this.LBTotalIn.Size = new System.Drawing.Size(124, 23);
            this.LBTotalIn.TabIndex = 9;
            this.LBTotalIn.Text = "Tổng thu nhập";
            // 
            // lblTotalIncomeAmount
            // 
            this.lblTotalIncomeAmount.AutoSize = true;
            this.lblTotalIncomeAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalIncomeAmount.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalIncomeAmount.Location = new System.Drawing.Point(155, 121);
            this.lblTotalIncomeAmount.Name = "lblTotalIncomeAmount";
            this.lblTotalIncomeAmount.Size = new System.Drawing.Size(55, 22);
            this.lblTotalIncomeAmount.TabIndex = 3;
            this.lblTotalIncomeAmount.Text = "$0.00";
            // 
            // lblSeparatorLine
            // 
            this.lblSeparatorLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblSeparatorLine.Location = new System.Drawing.Point(152, 148);
            this.lblSeparatorLine.Name = "lblSeparatorLine";
            this.lblSeparatorLine.Size = new System.Drawing.Size(150, 1);
            this.lblSeparatorLine.TabIndex = 28;
            // 
            // picIncomeIndicator
            // 
            this.picIncomeIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(250)))));
            this.picIncomeIndicator.Location = new System.Drawing.Point(155, 157);
            this.picIncomeIndicator.Name = "picIncomeIndicator";
            this.picIncomeIndicator.Size = new System.Drawing.Size(12, 12);
            this.picIncomeIndicator.TabIndex = 0;
            this.picIncomeIndicator.TabStop = false;
            // 
            // LabelIcome
            // 
            this.LabelIcome.AutoSize = true;
            this.LabelIcome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LabelIcome.Location = new System.Drawing.Point(175, 153);
            this.LabelIcome.Name = "LabelIcome";
            this.LabelIcome.Size = new System.Drawing.Size(85, 23);
            this.LabelIcome.TabIndex = 9;
            this.LabelIcome.Text = "Thu nhập";
            // 
            // picExpenseIndicator
            // 
            this.picExpenseIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))));
            this.picExpenseIndicator.Location = new System.Drawing.Point(155, 182);
            this.picExpenseIndicator.Name = "picExpenseIndicator";
            this.picExpenseIndicator.Size = new System.Drawing.Size(12, 12);
            this.picExpenseIndicator.TabIndex = 0;
            this.picExpenseIndicator.TabStop = false;
            // 
            // labelExpense
            // 
            this.labelExpense.AutoSize = true;
            this.labelExpense.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelExpense.Location = new System.Drawing.Point(175, 178);
            this.labelExpense.Name = "labelExpense";
            this.labelExpense.Size = new System.Drawing.Size(72, 23);
            this.labelExpense.TabIndex = 10;
            this.labelExpense.Text = "Chi tiêu";
            // 
            // pnlSavingsList
            // 
            this.pnlSavingsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlSavingsList.BorderRadius = 20;
            this.pnlSavingsList.Controls.Add(this.lblTitleSavingsList);
            this.pnlSavingsList.Controls.Add(this.LLSaving);
            this.pnlSavingsList.Controls.Add(this.lstSavingsItems);
            this.pnlSavingsList.DrawBankCardPattern = false;
            this.pnlSavingsList.GradientAngle = 90F;
            this.pnlSavingsList.GradientEndColor = System.Drawing.Color.White;
            this.pnlSavingsList.GradientStartColor = System.Drawing.Color.White;
            this.pnlSavingsList.Location = new System.Drawing.Point(396, 465);
            this.pnlSavingsList.Name = "pnlSavingsList";
            this.pnlSavingsList.Size = new System.Drawing.Size(320, 214);
            this.pnlSavingsList.TabIndex = 26;
            this.pnlSavingsList.UseGradient = false;
            // 
            // lblTitleSavingsList
            // 
            this.lblTitleSavingsList.AutoSize = true;
            this.lblTitleSavingsList.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleSavingsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitleSavingsList.Location = new System.Drawing.Point(7, 11);
            this.lblTitleSavingsList.Name = "lblTitleSavingsList";
            this.lblTitleSavingsList.Size = new System.Drawing.Size(217, 36);
            this.lblTitleSavingsList.TabIndex = 0;
            this.lblTitleSavingsList.Text = "Tiết kiệm của tôi";
            // 
            // LLSaving
            // 
            this.LLSaving.AutoSize = true;
            this.LLSaving.BackColor = System.Drawing.Color.Transparent;
            this.LLSaving.Font = new System.Drawing.Font("Times New Roman", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLSaving.Location = new System.Drawing.Point(220, 20);
            this.LLSaving.Name = "LLSaving";
            this.LLSaving.Size = new System.Drawing.Size(88, 20);
            this.LLSaving.TabIndex = 3;
            this.LLSaving.TabStop = true;
            this.LLSaving.Text = "Xem tất cả";
            // 
            // lstSavingsItems
            // 
            this.lstSavingsItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.lstSavingsItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSavingsItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstSavingsItems.Font = new System.Drawing.Font("Times New Roman", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSavingsItems.ItemHeight = 44;
            this.lstSavingsItems.Location = new System.Drawing.Point(10, 50);
            this.lstSavingsItems.Name = "lstSavingsItems";
            this.lstSavingsItems.Size = new System.Drawing.Size(300, 140);
            this.lstSavingsItems.TabIndex = 2;
            this.lstSavingsItems.SelectedIndexChanged += new System.EventHandler(this.lstSavingsItems_SelectedIndexChanged);
            // 
            // pnlTransfer
            // 
            this.pnlTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlTransfer.BorderRadius = 20;
            this.pnlTransfer.Controls.Add(this.lblTitleTransfer);
            this.pnlTransfer.Controls.Add(this.txtTransferAmount);
            this.pnlTransfer.Controls.Add(this.btnTransfer);
            this.pnlTransfer.DrawBankCardPattern = false;
            this.pnlTransfer.GradientAngle = 90F;
            this.pnlTransfer.GradientEndColor = System.Drawing.Color.White;
            this.pnlTransfer.GradientStartColor = System.Drawing.Color.White;
            this.pnlTransfer.Location = new System.Drawing.Point(758, 465);
            this.pnlTransfer.Name = "pnlTransfer";
            this.pnlTransfer.Size = new System.Drawing.Size(380, 200);
            this.pnlTransfer.TabIndex = 27;
            this.pnlTransfer.UseGradient = false;
            // 
            // lblTitleTransfer
            // 
            this.lblTitleTransfer.AutoSize = true;
            this.lblTitleTransfer.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleTransfer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitleTransfer.Location = new System.Drawing.Point(20, 15);
            this.lblTitleTransfer.Name = "lblTitleTransfer";
            this.lblTitleTransfer.Size = new System.Drawing.Size(276, 36);
            this.lblTitleTransfer.TabIndex = 0;
            this.lblTitleTransfer.Text = "Chuyển khoản nhanh";
            // 
            // txtTransferAmount
            // 
            this.txtTransferAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransferAmount.Font = new System.Drawing.Font("Times New Roman", 16.06154F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferAmount.ForeColor = System.Drawing.Color.Black;
            this.txtTransferAmount.Location = new System.Drawing.Point(20, 80);
            this.txtTransferAmount.Name = "txtTransferAmount";
            this.txtTransferAmount.Size = new System.Drawing.Size(340, 41);
            this.txtTransferAmount.TabIndex = 1;
            this.txtTransferAmount.Text = "Nhập số tiền...";
            this.txtTransferAmount.TextChanged += new System.EventHandler(this.txtTransferAmount_TextChanged);
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Times New Roman", 16.06154F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.Location = new System.Drawing.Point(20, 130);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(340, 45);
            this.btnTransfer.TabIndex = 1;
            this.btnTransfer.Text = "Chuyển khoản";
            this.btnTransfer.UseVisualStyleBackColor = false;
            // 
            // ucClientHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(130F, 130F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            // this.BackgroundImage = global::GUI.Properties.Resources.hhhhh1;
            // this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pnlBalance);
            this.Controls.Add(this.pnlSavings);
            this.Controls.Add(this.pnlLoans);
            this.Controls.Add(this.pnlBankCard);
            this.Controls.Add(this.lblTitleBalHist);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.pnlTransHist);
            this.Controls.Add(this.pnlPayment);
            this.Controls.Add(this.pnlSavingsList);
            this.Controls.Add(this.pnlTransfer);
            this.DoubleBuffered = true;
            this.Name = "ucClientHome";
            this.Size = new System.Drawing.Size(1202, 711);
            this.Load += new System.EventHandler(this.ucClientHome_Load);
            this.pnlTotals.ResumeLayout(false);
            this.pnlTotals.PerformLayout();
            this.pnlBalance.ResumeLayout(false);
            this.pnlBalance.PerformLayout();
            this.pnlSavings.ResumeLayout(false);
            this.pnlSavings.PerformLayout();
            this.pnlLoans.ResumeLayout(false);
            this.pnlLoans.PerformLayout();
            this.pnlBankCard.ResumeLayout(false);
            this.pnlBankCard.PerformLayout();
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnlTransHist.ResumeLayout(false);
            this.pnlTransHist.PerformLayout();
            this.pnlPayment.ResumeLayout(false);
            this.pnlPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDonutChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIncomeIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExpenseIndicator)).EndInit();
            this.pnlSavingsList.ResumeLayout(false);
            this.pnlSavingsList.PerformLayout();
            this.pnlTransfer.ResumeLayout(false);
            this.pnlTransfer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblBalanceAmount; 
        private System.Windows.Forms.Label lblSavingsAmount; 
        private System.Windows.Forms.Label lblLoansAmount;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.TextBox txtTransferAmount;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.ListBox lstSavingsItems; 
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblCardNumber; 
        private System.Windows.Forms.LinkLabel LLPayment;
        private System.Windows.Forms.LinkLabel LLSaving;
        private System.Windows.Forms.LinkLabel LLHistory;

                private System.Windows.Forms.Label LabelIcome;
                private System.Windows.Forms.Label labelExpense;
                private System.Windows.Forms.PictureBox picIncomeIndicator;
                private System.Windows.Forms.PictureBox picExpenseIndicator;
                private System.Windows.Forms.Label MoneyTotalIn;
                private System.Windows.Forms.Label LBTotalIn;
                private System.Windows.Forms.Label MoneyTotalEx;
                private System.Windows.Forms.Label LBTotalEx;
                private System.Windows.Forms.DataVisualization.Charting.Chart chart1; 
                private System.Windows.Forms.Label lblUserName;
                private System.Windows.Forms.Panel pnlLegend;
                private System.Windows.Forms.Panel pnlTotals;
        private System.Windows.Forms.LinkLabel LLPaySec; 
        private System.Windows.Forms.PictureBox picDonutChart; 
        private System.Windows.Forms.Label lblSeparatorLine;
        private System.Windows.Forms.Label lblTotalIncomeAmount; 
        private System.Windows.Forms.Label lblTotalExpenseAmount;
        private GUI.Client.RoundedPanel pnlBalance;
        private System.Windows.Forms.Label lblTitleBalance;
        private GUI.Client.RoundedPanel pnlSavings;
        private System.Windows.Forms.Label lblTitleSavings;
        private GUI.Client.RoundedPanel pnlLoans;
        private System.Windows.Forms.Label lblTitleLoans;
        private GUI.Client.RoundedPanel pnlBankCard;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Label lblTitleBalHist;
        private GUI.Client.RoundedPanel pnlChart;
        private GUI.Client.RoundedPanel pnlTransHist;
        private System.Windows.Forms.Label lblTitleTransHist;
        private GUI.Client.RoundedPanel pnlPayment;
        private System.Windows.Forms.Label lblTitlePayment;
        private GUI.Client.RoundedPanel pnlSavingsList;
        private System.Windows.Forms.Label lblTitleSavingsList;
        private GUI.Client.RoundedPanel pnlTransfer;
        private System.Windows.Forms.Label lblTitleTransfer;
    }
}
