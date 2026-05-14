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
            this.lblBalanceAmount = new System.Windows.Forms.Label();
            this.lblSavingsAmount = new System.Windows.Forms.Label();
            this.lblLoansAmount = new System.Windows.Forms.Label();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.LabelIcome = new System.Windows.Forms.Label();
            this.labelExpense = new System.Windows.Forms.Label();
            this.picIncomeIndicator = new System.Windows.Forms.PictureBox();
            this.picExpenseIndicator = new System.Windows.Forms.PictureBox();
            this.LLPayment = new System.Windows.Forms.LinkLabel();
            this.pnlTotals = new System.Windows.Forms.Panel();
            this.MoneyTotalIn = new System.Windows.Forms.Label();
            this.LBTotalIn = new System.Windows.Forms.Label();
            this.MoneyTotalEx = new System.Windows.Forms.Label();
            this.LBTotalEx = new System.Windows.Forms.Label();
            this.LLHistory = new System.Windows.Forms.LinkLabel();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.txtTransferAmount = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.LLSaving = new System.Windows.Forms.LinkLabel();
            this.lstSavingsItems = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblTotalIncomeAmount = new System.Windows.Forms.Label();
            this.lblTotalExpenseAmount = new System.Windows.Forms.Label();
            this.picDonutChart = new System.Windows.Forms.PictureBox();
            this.LLPaySec = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnlLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIncomeIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExpenseIndicator)).BeginInit();
            this.pnlTotals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDonutChart)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBalanceAmount
            // 
            this.lblBalanceAmount.AutoSize = true;
            this.lblBalanceAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblBalanceAmount.Font = new System.Drawing.Font("Times New Roman", 18.27692F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblBalanceAmount.Location = new System.Drawing.Point(46, 82);
            this.lblBalanceAmount.Name = "lblBalanceAmount";
            this.lblBalanceAmount.Size = new System.Drawing.Size(127, 37);
            this.lblBalanceAmount.TabIndex = 1;
            this.lblBalanceAmount.Text = "$424.38";
            // 
            // lblSavingsAmount
            // 
            this.lblSavingsAmount.AutoSize = true;
            this.lblSavingsAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblSavingsAmount.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblSavingsAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblSavingsAmount.Location = new System.Drawing.Point(351, 81);
            this.lblSavingsAmount.Name = "lblSavingsAmount";
            this.lblSavingsAmount.Size = new System.Drawing.Size(35, 38);
            this.lblSavingsAmount.TabIndex = 1;
            this.lblSavingsAmount.Text = "1";
            // 
            // lblLoansAmount
            // 
            this.lblLoansAmount.AutoSize = true;
            this.lblLoansAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblLoansAmount.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblLoansAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblLoansAmount.Location = new System.Drawing.Point(641, 82);
            this.lblLoansAmount.Name = "lblLoansAmount";
            this.lblLoansAmount.Size = new System.Drawing.Size(35, 38);
            this.lblLoansAmount.TabIndex = 1;
            this.lblLoansAmount.Text = "0";
            this.lblLoansAmount.Click += new System.EventHandler(this.lblLoansAmount_Click);
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblCardNumber.Font = new System.Drawing.Font("Times New Roman", 19.93846F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardNumber.ForeColor = System.Drawing.Color.White;
            this.lblCardNumber.Location = new System.Drawing.Point(923, 117);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(180, 41);
            this.lblCardNumber.TabIndex = 1;
            this.lblCardNumber.Text = "123220178";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Blue;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(53, 250);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(751, 207);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // pnlLegend
            // 
            this.pnlLegend.Controls.Add(this.LabelIcome);
            this.pnlLegend.Controls.Add(this.labelExpense);
            this.pnlLegend.Controls.Add(this.picIncomeIndicator);
            this.pnlLegend.Controls.Add(this.picExpenseIndicator);
            this.pnlLegend.Location = new System.Drawing.Point(236, 147);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(129, 62);
            this.pnlLegend.TabIndex = 8;
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
            // picIncomeIndicator
            // 
            this.picIncomeIndicator.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.picIncomeIndicator.Location = new System.Drawing.Point(15, 15);
            this.picIncomeIndicator.Name = "picIncomeIndicator";
            this.picIncomeIndicator.Size = new System.Drawing.Size(23, 17);
            this.picIncomeIndicator.TabIndex = 0;
            this.picIncomeIndicator.TabStop = false;
            // 
            // picExpenseIndicator
            // 
            this.picExpenseIndicator.BackColor = System.Drawing.Color.Red;
            this.picExpenseIndicator.Location = new System.Drawing.Point(15, 38);
            this.picExpenseIndicator.Name = "picExpenseIndicator";
            this.picExpenseIndicator.Size = new System.Drawing.Size(23, 17);
            this.picExpenseIndicator.TabIndex = 0;
            this.picExpenseIndicator.TabStop = false;
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
            this.pnlTotals.Controls.Add(this.LBTotalIn);
            this.pnlTotals.Controls.Add(this.MoneyTotalEx);
            this.pnlTotals.Controls.Add(this.LBTotalEx);
            this.pnlTotals.Location = new System.Drawing.Point(236, 32);
            this.pnlTotals.Name = "pnlTotals";
            this.pnlTotals.Size = new System.Drawing.Size(129, 100);
            this.pnlTotals.TabIndex = 8;
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
            // LLHistory
            // 
            this.LLHistory.AutoSize = true;
            this.LLHistory.BackColor = System.Drawing.Color.Transparent;
            this.LLHistory.Font = new System.Drawing.Font("Times New Roman", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLHistory.Location = new System.Drawing.Point(1118, 240);
            this.LLHistory.Name = "LLHistory";
            this.LLHistory.Size = new System.Drawing.Size(88, 20);
            this.LLHistory.TabIndex = 3;
            this.LLHistory.TabStop = true;
            this.LLHistory.Text = "Xem tất cả";
            // 
            // lstHistory
            // 
            this.lstHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.lstHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstHistory.Font = new System.Drawing.Font("Times New Roman", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHistory.ItemHeight = 20;
            this.lstHistory.Location = new System.Drawing.Point(874, 295);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(292, 180);
            this.lstHistory.TabIndex = 0;
            // 
            // txtTransferAmount
            // 
            this.txtTransferAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransferAmount.Font = new System.Drawing.Font("Times New Roman", 16.06154F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferAmount.ForeColor = System.Drawing.Color.Black;
            this.txtTransferAmount.Location = new System.Drawing.Point(874, 601);
            this.txtTransferAmount.Name = "txtTransferAmount";
            this.txtTransferAmount.Size = new System.Drawing.Size(278, 41);
            this.txtTransferAmount.TabIndex = 1;
            this.txtTransferAmount.Text = "Enter amount...";
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Times New Roman", 16.06154F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.Location = new System.Drawing.Point(874, 648);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(278, 41);
            this.btnTransfer.TabIndex = 1;
            this.btnTransfer.Text = "Chuyển khoản";
            this.btnTransfer.UseVisualStyleBackColor = false;
            // 
            // LLSaving
            // 
            this.LLSaving.AutoSize = true;
            this.LLSaving.BackColor = System.Drawing.Color.Transparent;
            this.LLSaving.Font = new System.Drawing.Font("Times New Roman", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLSaving.Location = new System.Drawing.Point(708, 537);
            this.LLSaving.Name = "LLSaving";
            this.LLSaving.Size = new System.Drawing.Size(88, 20);
            this.LLSaving.TabIndex = 3;
            this.LLSaving.TabStop = true;
            this.LLSaving.Text = "Xem tất cả";
            // 
            // lstSavingsItems
            // 
            this.lstSavingsItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.lstSavingsItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSavingsItems.Font = new System.Drawing.Font("Times New Roman", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSavingsItems.ItemHeight = 20;
            this.lstSavingsItems.Location = new System.Drawing.Point(470, 574);
            this.lstSavingsItems.Name = "lstSavingsItems";
            this.lstSavingsItems.Size = new System.Drawing.Size(326, 120);
            this.lstSavingsItems.TabIndex = 2;
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
            // lblTotalIncomeAmount
            // 
            this.lblTotalIncomeAmount.AutoSize = true;
            this.lblTotalIncomeAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalIncomeAmount.Font = new System.Drawing.Font("Times New Roman", 8.861538F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIncomeAmount.Location = new System.Drawing.Point(273, 639);
            this.lblTotalIncomeAmount.Name = "lblTotalIncomeAmount";
            this.lblTotalIncomeAmount.Size = new System.Drawing.Size(45, 19);
            this.lblTotalIncomeAmount.TabIndex = 3;
            this.lblTotalIncomeAmount.Text = "$0.00";
            // 
            // lblTotalExpenseAmount
            // 
            this.lblTotalExpenseAmount.AutoSize = true;
            this.lblTotalExpenseAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalExpenseAmount.Font = new System.Drawing.Font("Times New Roman", 8.861538F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExpenseAmount.Location = new System.Drawing.Point(273, 601);
            this.lblTotalExpenseAmount.Name = "lblTotalExpenseAmount";
            this.lblTotalExpenseAmount.Size = new System.Drawing.Size(45, 19);
            this.lblTotalExpenseAmount.TabIndex = 1;
            this.lblTotalExpenseAmount.Text = "$0.00";
            // 
            // picDonutChart
            // 
            this.picDonutChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.picDonutChart.Location = new System.Drawing.Point(53, 574);
            this.picDonutChart.Name = "picDonutChart";
            this.picDonutChart.Size = new System.Drawing.Size(182, 125);
            this.picDonutChart.TabIndex = 17;
            this.picDonutChart.TabStop = false;
            // 
            // LLPaySec
            // 
            this.LLPaySec.AutoSize = true;
            this.LLPaySec.BackColor = System.Drawing.Color.Transparent;
            this.LLPaySec.Font = new System.Drawing.Font("Times New Roman", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLPaySec.Location = new System.Drawing.Point(299, 537);
            this.LLPaySec.Name = "LLPaySec";
            this.LLPaySec.Size = new System.Drawing.Size(88, 20);
            this.LLPaySec.TabIndex = 16;
            this.LLPaySec.TabStop = true;
            this.LLPaySec.Text = "Xem tất cả";
            // 
            // ucClientHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(130F, 130F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::GUI.Properties.Resources.Nội_dung_đoạn_văn_bản_của_bạn1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblTotalIncomeAmount);
            this.Controls.Add(this.LLPaySec);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.LLSaving);
            this.Controls.Add(this.lblTotalExpenseAmount);
            this.Controls.Add(this.picDonutChart);
            this.Controls.Add(this.txtTransferAmount);
            this.Controls.Add(this.lstSavingsItems);
            this.Controls.Add(this.LLHistory);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.lblBalanceAmount);
            this.Controls.Add(this.lblSavingsAmount);
            this.Controls.Add(this.lblLoansAmount);
            this.Controls.Add(this.lblCardNumber);
            this.DoubleBuffered = true;
            this.Name = "ucClientHome";
            this.Size = new System.Drawing.Size(1248, 758);
            this.Load += new System.EventHandler(this.ucClientHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnlLegend.ResumeLayout(false);
            this.pnlLegend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIncomeIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExpenseIndicator)).EndInit();
            this.pnlTotals.ResumeLayout(false);
            this.pnlTotals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDonutChart)).EndInit();
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
        private System.Windows.Forms.Label lblTotalIncomeAmount; 
        private System.Windows.Forms.Label lblTotalExpenseAmount;
    }
        }
