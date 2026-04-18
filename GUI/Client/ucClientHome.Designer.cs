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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlMyBalance = new System.Windows.Forms.Panel();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblBalanceAmount = new System.Windows.Forms.Label();
            this.pnlMySavings = new System.Windows.Forms.Panel();
            this.lblSavings = new System.Windows.Forms.Label();
            this.lblSavingsAmount = new System.Windows.Forms.Label();
            this.pnlMyLoans = new System.Windows.Forms.Panel();
            this.lblLoans = new System.Windows.Forms.Label();
            this.lblLoansAmount = new System.Windows.Forms.Label();
            this.pnlCreditCard = new System.Windows.Forms.Panel();
            this.lblCardHolder = new System.Windows.Forms.Label();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.lblBalanceHistoryTitle = new System.Windows.Forms.Label();
            this.pnlBalanceChart = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlPaymentSection = new System.Windows.Forms.Panel();
           
            this.LabelIcome = new System.Windows.Forms.Label();
            this.labelExpense = new System.Windows.Forms.Label();
            
            this.LLPayment = new System.Windows.Forms.LinkLabel();
            
            this.MoneyTotalIn = new System.Windows.Forms.Label();
            this.LBTotalIn = new System.Windows.Forms.Label();
            this.MoneyTotalEx = new System.Windows.Forms.Label();
            this.LBTotalEx = new System.Windows.Forms.Label();
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.pnlPaymentPie = new System.Windows.Forms.Panel();
            this.pnlHistoryTransactions = new System.Windows.Forms.Panel();
            this.LLHistory = new System.Windows.Forms.LinkLabel();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.pnlQuickTransfer = new System.Windows.Forms.Panel();
            this.lblTransferTitle = new System.Windows.Forms.Label();
            this.pnlTransferIcons = new System.Windows.Forms.Panel();
            this.txtTransferAmount = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.pnlMySavingsDetails = new System.Windows.Forms.Panel();
            this.lblSavingsDetailsTitle = new System.Windows.Forms.Label();
            this.LLSaving = new System.Windows.Forms.LinkLabel();
            this.lstSavingsItems = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
          
            this.pnlMyBalance.SuspendLayout();
            this.pnlMySavings.SuspendLayout();
            this.pnlMyLoans.SuspendLayout();
            this.pnlCreditCard.SuspendLayout();
            this.pnlBalanceChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnlPaymentSection.SuspendLayout();
            this.pnlHistoryTransactions.SuspendLayout();
            this.pnlQuickTransfer.SuspendLayout();
            this.pnlMySavingsDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMyBalance
            // 
            this.pnlMyBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlMyBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMyBalance.Controls.Add(this.lblBalance);
            this.pnlMyBalance.Controls.Add(this.lblBalanceAmount);
            this.pnlMyBalance.Location = new System.Drawing.Point(52, 29);
            this.pnlMyBalance.Name = "pnlMyBalance";
            this.pnlMyBalance.Size = new System.Drawing.Size(275, 131);
            this.pnlMyBalance.TabIndex = 0;
            this.pnlMyBalance.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMyBalance_Paint);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Times New Roman", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Gray;
            this.lblBalance.Location = new System.Drawing.Point(34, 14);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(151, 29);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "Số dư của tôi";
            // 
            // lblBalanceAmount
            // 
            this.lblBalanceAmount.AutoSize = true;
            this.lblBalanceAmount.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblBalanceAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblBalanceAmount.Location = new System.Drawing.Point(32, 61);
            this.lblBalanceAmount.Name = "lblBalanceAmount";
            this.lblBalanceAmount.Size = new System.Drawing.Size(134, 38);
            this.lblBalanceAmount.TabIndex = 1;
            this.lblBalanceAmount.Text = "$424.38";
            // 
            // pnlMySavings
            // 
            this.pnlMySavings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlMySavings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMySavings.Controls.Add(this.lblSavings);
            this.pnlMySavings.Controls.Add(this.lblSavingsAmount);
            this.pnlMySavings.Location = new System.Drawing.Point(350, 29);
            this.pnlMySavings.Name = "pnlMySavings";
            this.pnlMySavings.Size = new System.Drawing.Size(281, 131);
            this.pnlMySavings.TabIndex = 1;
            // 
            // lblSavings
            // 
            this.lblSavings.AutoSize = true;
            this.lblSavings.Font = new System.Drawing.Font("Times New Roman", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavings.ForeColor = System.Drawing.Color.Gray;
            this.lblSavings.Location = new System.Drawing.Point(31, 11);
            this.lblSavings.Name = "lblSavings";
            this.lblSavings.Size = new System.Drawing.Size(191, 29);
            this.lblSavings.TabIndex = 0;
            this.lblSavings.Text = "Tiết kiệm của tôi";
            // 
            // lblSavingsAmount
            // 
            this.lblSavingsAmount.AutoSize = true;
            this.lblSavingsAmount.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblSavingsAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblSavingsAmount.Location = new System.Drawing.Point(87, 57);
            this.lblSavingsAmount.Name = "lblSavingsAmount";
            this.lblSavingsAmount.Size = new System.Drawing.Size(35, 38);
            this.lblSavingsAmount.TabIndex = 1;
            this.lblSavingsAmount.Text = "1";
            // 
            // pnlMyLoans
            // 
            this.pnlMyLoans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlMyLoans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMyLoans.Controls.Add(this.lblLoans);
            this.pnlMyLoans.Controls.Add(this.lblLoansAmount);
            this.pnlMyLoans.Location = new System.Drawing.Point(648, 29);
            this.pnlMyLoans.Name = "pnlMyLoans";
            this.pnlMyLoans.Size = new System.Drawing.Size(276, 131);
            this.pnlMyLoans.TabIndex = 2;
            this.pnlMyLoans.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMyLoans_Paint);
            // 
            // lblLoans
            // 
            this.lblLoans.AutoSize = true;
            this.lblLoans.Font = new System.Drawing.Font("Times New Roman", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoans.ForeColor = System.Drawing.Color.Gray;
            this.lblLoans.Location = new System.Drawing.Point(13, 14);
            this.lblLoans.Name = "lblLoans";
            this.lblLoans.Size = new System.Drawing.Size(205, 29);
            this.lblLoans.TabIndex = 0;
            this.lblLoans.Text = "Khoản vay của tôi";
            // 
            // lblLoansAmount
            // 
            this.lblLoansAmount.AutoSize = true;
            this.lblLoansAmount.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblLoansAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblLoansAmount.Location = new System.Drawing.Point(87, 61);
            this.lblLoansAmount.Name = "lblLoansAmount";
            this.lblLoansAmount.Size = new System.Drawing.Size(35, 38);
            this.lblLoansAmount.TabIndex = 1;
            this.lblLoansAmount.Text = "0";
            // 
            // pnlCreditCard
            // 
            this.pnlCreditCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.pnlCreditCard.Controls.Add(this.lblCardHolder);
            this.pnlCreditCard.Controls.Add(this.lblCardNumber);
            this.pnlCreditCard.Location = new System.Drawing.Point(948, 29);
            this.pnlCreditCard.Name = "pnlCreditCard";
            this.pnlCreditCard.Size = new System.Drawing.Size(283, 157);
            this.pnlCreditCard.TabIndex = 3;
            // 
            // lblCardHolder
            // 
            this.lblCardHolder.AutoSize = true;
            this.lblCardHolder.Font = new System.Drawing.Font("Times New Roman", 16.06154F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardHolder.ForeColor = System.Drawing.Color.White;
            this.lblCardHolder.Location = new System.Drawing.Point(17, 18);
            this.lblCardHolder.Name = "lblCardHolder";
            this.lblCardHolder.Size = new System.Drawing.Size(169, 35);
            this.lblCardHolder.TabIndex = 0;
            this.lblCardHolder.Text = "HTTS Bank";
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardNumber.ForeColor = System.Drawing.Color.White;
            this.lblCardNumber.Location = new System.Drawing.Point(17, 100);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(159, 34);
            this.lblCardNumber.TabIndex = 1;
            this.lblCardNumber.Text = "123220178";
            // 
            // lblBalanceHistoryTitle
            // 
            this.lblBalanceHistoryTitle.AutoSize = true;
            this.lblBalanceHistoryTitle.Font = new System.Drawing.Font("Times New Roman", 16.06154F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceHistoryTitle.Location = new System.Drawing.Point(46, 206);
            this.lblBalanceHistoryTitle.Name = "lblBalanceHistoryTitle";
            this.lblBalanceHistoryTitle.Size = new System.Drawing.Size(188, 35);
            this.lblBalanceHistoryTitle.TabIndex = 7;
            this.lblBalanceHistoryTitle.Text = "Lịch sử số dư";
            this.lblBalanceHistoryTitle.Click += new System.EventHandler(this.lblBalanceHistoryTitle_Click);
            // 
            // pnlBalanceChart
            // 
            this.pnlBalanceChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlBalanceChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBalanceChart.Controls.Add(this.chart1);
            this.pnlBalanceChart.Location = new System.Drawing.Point(52, 261);
            this.pnlBalanceChart.Name = "pnlBalanceChart";
            this.pnlBalanceChart.Size = new System.Drawing.Size(757, 220);
            this.pnlBalanceChart.TabIndex = 2;
            this.pnlBalanceChart.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBalanceChart_Paint);
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(15, 11);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(701, 189);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // pnlPaymentSection
            // 
            this.pnlPaymentSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlPaymentSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          
            this.pnlPaymentSection.Controls.Add(this.lblPaymentTitle);
            this.pnlPaymentSection.Controls.Add(this.pnlPaymentPie);
            this.pnlPaymentSection.Location = new System.Drawing.Point(52, 519);
            this.pnlPaymentSection.Name = "pnlPaymentSection";
            this.pnlPaymentSection.Size = new System.Drawing.Size(384, 223);
            this.pnlPaymentSection.TabIndex = 3;
            // 
            // guna2Panel2
            // 
           
            // 
            // LabelIcome
            // 
            this.LabelIcome.AutoSize = true;
            this.LabelIcome.Location = new System.Drawing.Point(58, 15);
            this.LabelIcome.Name = "LabelIcome";
            this.LabelIcome.Size = new System.Drawing.Size(55, 16);
            this.LabelIcome.TabIndex = 9;
            this.LabelIcome.Text = "Income";
            // 
            // labelExpense
            // 
            this.labelExpense.AutoSize = true;
            this.labelExpense.Location = new System.Drawing.Point(58, 39);
            this.labelExpense.Name = "labelExpense";
            this.labelExpense.Size = new System.Drawing.Size(62, 16);
            this.labelExpense.TabIndex = 10;
            this.labelExpense.Text = "Expense";
            // 
            // guna2CirclePictureBox2
            // 
           
            // 
            // guna2CirclePictureBox1
            // 
            
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
            // guna2Panel1
            // 
            
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
            // LBTotalIn
            // 
            this.LBTotalIn.AutoSize = true;
            this.LBTotalIn.Location = new System.Drawing.Point(22, 45);
            this.LBTotalIn.Name = "LBTotalIn";
            this.LBTotalIn.Size = new System.Drawing.Size(94, 16);
            this.LBTotalIn.TabIndex = 9;
            this.LBTotalIn.Text = "Total Income";
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
            // LBTotalEx
            // 
            this.LBTotalEx.AutoSize = true;
            this.LBTotalEx.Location = new System.Drawing.Point(14, 7);
            this.LBTotalEx.Name = "LBTotalEx";
            this.LBTotalEx.Size = new System.Drawing.Size(101, 16);
            this.LBTotalEx.TabIndex = 9;
            this.LBTotalEx.Text = "Total Expense";
            // 
            // lblPaymentTitle
            // 
            this.lblPaymentTitle.AutoSize = true;
            this.lblPaymentTitle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPaymentTitle.Location = new System.Drawing.Point(11, 10);
            this.lblPaymentTitle.Name = "lblPaymentTitle";
            this.lblPaymentTitle.Size = new System.Drawing.Size(116, 22);
            this.lblPaymentTitle.TabIndex = 0;
            this.lblPaymentTitle.Text = "Thanh toán";
            // 
            // pnlPaymentPie
            // 
            this.pnlPaymentPie.BackColor = System.Drawing.Color.White;
            this.pnlPaymentPie.Location = new System.Drawing.Point(11, 40);
            this.pnlPaymentPie.Name = "pnlPaymentPie";
            this.pnlPaymentPie.Size = new System.Drawing.Size(202, 170);
            this.pnlPaymentPie.TabIndex = 0;
            // 
            // pnlHistoryTransactions
            // 
            this.pnlHistoryTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlHistoryTransactions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHistoryTransactions.Controls.Add(this.LLHistory);
            this.pnlHistoryTransactions.Controls.Add(this.lblHistoryTitle);
            this.pnlHistoryTransactions.Controls.Add(this.lstHistory);
            this.pnlHistoryTransactions.Location = new System.Drawing.Point(855, 226);
            this.pnlHistoryTransactions.Name = "pnlHistoryTransactions";
            this.pnlHistoryTransactions.Size = new System.Drawing.Size(376, 255);
            this.pnlHistoryTransactions.TabIndex = 4;
            this.pnlHistoryTransactions.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHistoryTransactions_Paint);
            // 
            // LLHistory
            // 
            this.LLHistory.AutoSize = true;
            this.LLHistory.Location = new System.Drawing.Point(275, 20);
            this.LLHistory.Name = "LLHistory";
            this.LLHistory.Size = new System.Drawing.Size(81, 16);
            this.LLHistory.TabIndex = 3;
            this.LLHistory.TabStop = true;
            this.LLHistory.Text = "Xem tất cả";
            this.LLHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLHistory_LinkClicked);
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Times New Roman", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoryTitle.Location = new System.Drawing.Point(17, 11);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(196, 29);
            this.lblHistoryTitle.TabIndex = 0;
            this.lblHistoryTitle.Text = "Lịch sử giao dịch";
            // 
            // lstHistory
            // 
            this.lstHistory.BackColor = System.Drawing.Color.White;
            this.lstHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstHistory.ItemHeight = 16;
            this.lstHistory.Location = new System.Drawing.Point(22, 59);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(334, 176);
            this.lstHistory.TabIndex = 0;
            // 
            // pnlQuickTransfer
            // 
            this.pnlQuickTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlQuickTransfer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuickTransfer.Controls.Add(this.lblTransferTitle);
            this.pnlQuickTransfer.Controls.Add(this.pnlTransferIcons);
            this.pnlQuickTransfer.Controls.Add(this.txtTransferAmount);
            this.pnlQuickTransfer.Controls.Add(this.btnTransfer);
            this.pnlQuickTransfer.Location = new System.Drawing.Point(855, 519);
            this.pnlQuickTransfer.Name = "pnlQuickTransfer";
            this.pnlQuickTransfer.Size = new System.Drawing.Size(376, 200);
            this.pnlQuickTransfer.TabIndex = 5;
            // 
            // lblTransferTitle
            // 
            this.lblTransferTitle.AutoSize = true;
            this.lblTransferTitle.Font = new System.Drawing.Font("Times New Roman", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferTitle.Location = new System.Drawing.Point(10, 9);
            this.lblTransferTitle.Name = "lblTransferTitle";
            this.lblTransferTitle.Size = new System.Drawing.Size(241, 29);
            this.lblTransferTitle.TabIndex = 0;
            this.lblTransferTitle.Text = "Chuyển khoản nhanh";
            // 
            // pnlTransferIcons
            // 
            this.pnlTransferIcons.BackColor = System.Drawing.Color.White;
            this.pnlTransferIcons.Location = new System.Drawing.Point(22, 41);
            this.pnlTransferIcons.Name = "pnlTransferIcons";
            this.pnlTransferIcons.Size = new System.Drawing.Size(334, 50);
            this.pnlTransferIcons.TabIndex = 0;
            // 
            // txtTransferAmount
            // 
            this.txtTransferAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransferAmount.Font = new System.Drawing.Font("Times New Roman", 16.06154F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferAmount.Location = new System.Drawing.Point(22, 97);
            this.txtTransferAmount.Name = "txtTransferAmount";
            this.txtTransferAmount.Size = new System.Drawing.Size(334, 41);
            this.txtTransferAmount.TabIndex = 1;
            this.txtTransferAmount.Text = "Enter amount...";
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.Location = new System.Drawing.Point(16, 148);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(334, 41);
            this.btnTransfer.TabIndex = 1;
            this.btnTransfer.Text = "Chuyển khoản";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click_1);
            // 
            // pnlMySavingsDetails
            // 
            this.pnlMySavingsDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlMySavingsDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMySavingsDetails.Controls.Add(this.lblSavingsDetailsTitle);
            this.pnlMySavingsDetails.Controls.Add(this.LLSaving);
            this.pnlMySavingsDetails.Controls.Add(this.lstSavingsItems);
            this.pnlMySavingsDetails.Location = new System.Drawing.Point(473, 519);
            this.pnlMySavingsDetails.Name = "pnlMySavingsDetails";
            this.pnlMySavingsDetails.Size = new System.Drawing.Size(336, 200);
            this.pnlMySavingsDetails.TabIndex = 4;
            // 
            // lblSavingsDetailsTitle
            // 
            this.lblSavingsDetailsTitle.AutoSize = true;
            this.lblSavingsDetailsTitle.Font = new System.Drawing.Font("Times New Roman", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavingsDetailsTitle.Location = new System.Drawing.Point(11, 10);
            this.lblSavingsDetailsTitle.Name = "lblSavingsDetailsTitle";
            this.lblSavingsDetailsTitle.Size = new System.Drawing.Size(191, 29);
            this.lblSavingsDetailsTitle.TabIndex = 0;
            this.lblSavingsDetailsTitle.Text = "Tiết kiệm của tôi";
            // 
            // LLSaving
            // 
            this.LLSaving.AutoSize = true;
            this.LLSaving.Location = new System.Drawing.Point(241, 16);
            this.LLSaving.Name = "LLSaving";
            this.LLSaving.Size = new System.Drawing.Size(81, 16);
            this.LLSaving.TabIndex = 3;
            this.LLSaving.TabStop = true;
            this.LLSaving.Text = "Xem tất cả";
            // 
            // lstSavingsItems
            // 
            this.lstSavingsItems.BackColor = System.Drawing.Color.White;
            this.lstSavingsItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSavingsItems.ItemHeight = 16;
            this.lstSavingsItems.Location = new System.Drawing.Point(16, 49);
            this.lstSavingsItems.Name = "lstSavingsItems";
            this.lstSavingsItems.Size = new System.Drawing.Size(306, 160);
            this.lstSavingsItems.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ucClientHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblBalanceHistoryTitle);
            this.Controls.Add(this.pnlMyBalance);
            this.Controls.Add(this.pnlMySavings);
            this.Controls.Add(this.pnlMyLoans);
            this.Controls.Add(this.pnlCreditCard);
            this.Controls.Add(this.pnlQuickTransfer);
            this.Controls.Add(this.pnlMySavingsDetails);
            this.Controls.Add(this.pnlPaymentSection);
            this.Controls.Add(this.pnlHistoryTransactions);
            this.Controls.Add(this.pnlBalanceChart);
            this.Name = "ucClientHome";
            this.Size = new System.Drawing.Size(1255, 763);
            this.Load += new System.EventHandler(this.ucClientHome_Load);
            this.pnlMyBalance.ResumeLayout(false);
            this.pnlMyBalance.PerformLayout();
            this.pnlMySavings.ResumeLayout(false);
            this.pnlMySavings.PerformLayout();
            this.pnlMyLoans.ResumeLayout(false);
            this.pnlMyLoans.PerformLayout();
            this.pnlCreditCard.ResumeLayout(false);
            this.pnlCreditCard.PerformLayout();
            this.pnlBalanceChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnlPaymentSection.ResumeLayout(false);
            this.pnlPaymentSection.PerformLayout();
           
            
          
            this.pnlHistoryTransactions.ResumeLayout(false);
            this.pnlHistoryTransactions.PerformLayout();
            this.pnlQuickTransfer.ResumeLayout(false);
            this.pnlQuickTransfer.PerformLayout();
            this.pnlMySavingsDetails.ResumeLayout(false);
            this.pnlMySavingsDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlMyBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblBalanceAmount;
        private System.Windows.Forms.Panel pnlMySavings;
        private System.Windows.Forms.Label lblSavings;
        private System.Windows.Forms.Label lblSavingsAmount;
        private System.Windows.Forms.Panel pnlMyLoans;
        private System.Windows.Forms.Label lblLoans;
        private System.Windows.Forms.Label lblLoansAmount;
        private System.Windows.Forms.Panel pnlCreditCard;
        private System.Windows.Forms.Label lblCardHolder;
        private System.Windows.Forms.Label lblBalanceHistoryTitle;
        private System.Windows.Forms.Panel pnlBalanceChart;
        private System.Windows.Forms.Panel pnlPaymentSection;
        private System.Windows.Forms.Label lblPaymentTitle;
        private System.Windows.Forms.Panel pnlPaymentPie;
        private System.Windows.Forms.Panel pnlHistoryTransactions;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Panel pnlQuickTransfer;
        private System.Windows.Forms.Label lblTransferTitle;
        private System.Windows.Forms.Panel pnlTransferIcons;
        private System.Windows.Forms.TextBox txtTransferAmount;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Panel pnlMySavingsDetails;
        private System.Windows.Forms.Label lblSavingsDetailsTitle;
        private System.Windows.Forms.ListBox lstSavingsItems;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.LinkLabel LLPayment;
        private System.Windows.Forms.LinkLabel LLSaving;
        private System.Windows.Forms.LinkLabel LLHistory;
       
        private System.Windows.Forms.Label LabelIcome;
        private System.Windows.Forms.Label labelExpense;

        private System.Windows.Forms.Label MoneyTotalIn;
        private System.Windows.Forms.Label LBTotalIn;
        private System.Windows.Forms.Label MoneyTotalEx;
        private System.Windows.Forms.Label LBTotalEx;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
