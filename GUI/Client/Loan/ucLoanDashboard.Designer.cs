namespace GUI.Client.Loan
{
    partial class ucLoanDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLoanDashboard));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnCreateLoan = new Krypton.Toolkit.KryptonButton();
            this.chartAmount = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutListLoan = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAmountRepayment = new System.Windows.Forms.Label();
            this.lblll = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblTotalExpectedAmount = new System.Windows.Forms.Label();
            this.btnPayment = new Krypton.Toolkit.KryptonButton();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.panelPaidAmount = new Krypton.Toolkit.KryptonGroup();
            this.btnConfirm = new Krypton.Toolkit.KryptonButton();
            this.lblExpectedTotalAmount = new Krypton.Toolkit.KryptonLabel();
            this.txtCheckPassword = new Krypton.Toolkit.KryptonTextBox();
            this.btnExitCheckPassword = new Krypton.Toolkit.KryptonButton();
            this.btnPassword = new Krypton.Toolkit.KryptonButton();
            this.txtAmount = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.btnRepayment = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPaidAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPaidAmount.Panel)).BeginInit();
            this.panelPaidAmount.Panel.SuspendLayout();
            this.panelPaidAmount.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateLoan
            // 
            this.btnCreateLoan.Location = new System.Drawing.Point(1084, 414);
            this.btnCreateLoan.Name = "btnCreateLoan";
            this.btnCreateLoan.Size = new System.Drawing.Size(245, 167);
            this.btnCreateLoan.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnCreateLoan.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnCreateLoan.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateLoan.StateCommon.Back.Image")));
            this.btnCreateLoan.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnCreateLoan.StateCommon.Border.Rounding = 25F;
            this.btnCreateLoan.TabIndex = 0;
            this.btnCreateLoan.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnCreateLoan.Values.Text = "";
            this.btnCreateLoan.Click += new System.EventHandler(this.btnCreateLoan_Click);
            // 
            // chartAmount
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAmount.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartAmount.Legends.Add(legend1);
            this.chartAmount.Location = new System.Drawing.Point(392, 128);
            this.chartAmount.Name = "chartAmount";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartAmount.Series.Add(series1);
            this.chartAmount.Size = new System.Drawing.Size(901, 245);
            this.chartAmount.TabIndex = 1;
            this.chartAmount.Text = "chart1";
            this.chartAmount.Click += new System.EventHandler(this.chartAmount_Click);
            // 
            // flowLayoutListLoan
            // 
            this.flowLayoutListLoan.AutoScroll = true;
            this.flowLayoutListLoan.BackColor = System.Drawing.Color.White;
            this.flowLayoutListLoan.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutListLoan.Location = new System.Drawing.Point(26, 426);
            this.flowLayoutListLoan.Name = "flowLayoutListLoan";
            this.flowLayoutListLoan.Size = new System.Drawing.Size(776, 296);
            this.flowLayoutListLoan.TabIndex = 2;
            this.flowLayoutListLoan.WrapContents = false;
            // 
            // lblAmountRepayment
            // 
            this.lblAmountRepayment.AutoSize = true;
            this.lblAmountRepayment.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountRepayment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountRepayment.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblAmountRepayment.Location = new System.Drawing.Point(867, 63);
            this.lblAmountRepayment.Name = "lblAmountRepayment";
            this.lblAmountRepayment.Size = new System.Drawing.Size(36, 28);
            this.lblAmountRepayment.TabIndex = 10;
            this.lblAmountRepayment.Text = "---";
            // 
            // lblll
            // 
            this.lblll.AutoSize = true;
            this.lblll.BackColor = System.Drawing.Color.Transparent;
            this.lblll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblll.ForeColor = System.Drawing.Color.Black;
            this.lblll.Location = new System.Drawing.Point(609, 63);
            this.lblll.Name = "lblll";
            this.lblll.Size = new System.Drawing.Size(193, 28);
            this.lblll.TabIndex = 11;
            this.lblll.Text = "Tổng số tiền đã trả";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.Black;
            this.lblDueDate.Location = new System.Drawing.Point(51, 336);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(36, 28);
            this.lblDueDate.TabIndex = 12;
            this.lblDueDate.Text = "---";
            // 
            // lblTotalExpectedAmount
            // 
            this.lblTotalExpectedAmount.AutoSize = true;
            this.lblTotalExpectedAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalExpectedAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExpectedAmount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalExpectedAmount.Location = new System.Drawing.Point(51, 281);
            this.lblTotalExpectedAmount.Name = "lblTotalExpectedAmount";
            this.lblTotalExpectedAmount.Size = new System.Drawing.Size(36, 28);
            this.lblTotalExpectedAmount.TabIndex = 13;
            this.lblTotalExpectedAmount.Text = "---";
            // 
            // btnPayment
            // 
            this.btnPayment.Location = new System.Drawing.Point(818, 414);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(245, 167);
            this.btnPayment.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
            this.btnPayment.StateCommon.Back.Color2 = System.Drawing.Color.Gray;
            this.btnPayment.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnPayment.StateCommon.Back.Image")));
            this.btnPayment.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnPayment.StateCommon.Border.Rounding = 20F;
            this.btnPayment.TabIndex = 18;
            this.btnPayment.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnPayment.Values.Text = "";
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(51, 93);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(36, 28);
            this.lblTotalAmount.TabIndex = 19;
            this.lblTotalAmount.Text = "---";
            // 
            // panelPaidAmount
            // 
            this.panelPaidAmount.Location = new System.Drawing.Point(417, 118);
            // 
            // panelPaidAmount.Panel
            // 
            this.panelPaidAmount.Panel.Controls.Add(this.btnConfirm);
            this.panelPaidAmount.Panel.Controls.Add(this.lblExpectedTotalAmount);
            this.panelPaidAmount.Panel.Controls.Add(this.txtCheckPassword);
            this.panelPaidAmount.Panel.Controls.Add(this.btnExitCheckPassword);
            this.panelPaidAmount.Panel.Controls.Add(this.btnPassword);
            this.panelPaidAmount.Panel.Controls.Add(this.txtAmount);
            this.panelPaidAmount.Panel.Controls.Add(this.kryptonLabel1);
            this.panelPaidAmount.Size = new System.Drawing.Size(601, 423);
            this.panelPaidAmount.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.panelPaidAmount.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.panelPaidAmount.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("panelPaidAmount.StateCommon.Back.Image")));
            this.panelPaidAmount.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.panelPaidAmount.StateCommon.Border.Color1 = System.Drawing.Color.Cyan;
            this.panelPaidAmount.StateCommon.Border.Rounding = 15F;
            this.panelPaidAmount.TabIndex = 20;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(189, 343);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(190, 55);
            this.btnConfirm.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
            this.btnConfirm.StateCommon.Back.Color2 = System.Drawing.Color.Gray;
            this.btnConfirm.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.StateCommon.Back.Image")));
            this.btnConfirm.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnConfirm.StateCommon.Border.Rounding = 20F;
            this.btnConfirm.TabIndex = 15;
            this.btnConfirm.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnConfirm.Values.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnConfirm.Values.Text = "";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblExpectedTotalAmount
            // 
            this.lblExpectedTotalAmount.Location = new System.Drawing.Point(133, 99);
            this.lblExpectedTotalAmount.Name = "lblExpectedTotalAmount";
            this.lblExpectedTotalAmount.Size = new System.Drawing.Size(109, 25);
            this.lblExpectedTotalAmount.TabIndex = 14;
            this.lblExpectedTotalAmount.Values.Text = "kryptonLabel2";
            // 
            // txtCheckPassword
            // 
            this.txtCheckPassword.Location = new System.Drawing.Point(85, 290);
            this.txtCheckPassword.Name = "txtCheckPassword";
            this.txtCheckPassword.PasswordChar = '●';
            this.txtCheckPassword.Size = new System.Drawing.Size(395, 37);
            this.txtCheckPassword.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtCheckPassword.StateCommon.Border.Rounding = 15F;
            this.txtCheckPassword.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txtCheckPassword.TabIndex = 13;
            this.txtCheckPassword.UseSystemPasswordChar = true;
            // 
            // btnExitCheckPassword
            // 
            this.btnExitCheckPassword.Location = new System.Drawing.Point(547, 3);
            this.btnExitCheckPassword.Name = "btnExitCheckPassword";
            this.btnExitCheckPassword.Size = new System.Drawing.Size(35, 35);
            this.btnExitCheckPassword.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.btnExitCheckPassword.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.btnExitCheckPassword.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnExitCheckPassword.StateCommon.Border.Width = 0;
            this.btnExitCheckPassword.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnExitCheckPassword.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnExitCheckPassword.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitCheckPassword.TabIndex = 12;
            this.btnExitCheckPassword.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnExitCheckPassword.Values.Text = "X";
            this.btnExitCheckPassword.Click += new System.EventHandler(this.btnExitCheckPassword_Click);
            // 
            // btnPassword
            // 
            this.btnPassword.Location = new System.Drawing.Point(189, 343);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(190, 55);
            this.btnPassword.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
            this.btnPassword.StateCommon.Back.Color2 = System.Drawing.Color.Gray;
            this.btnPassword.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnPassword.StateCommon.Back.Image")));
            this.btnPassword.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnPassword.StateCommon.Border.Rounding = 20F;
            this.btnPassword.TabIndex = 11;
            this.btnPassword.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnPassword.Values.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnPassword.Values.Text = "";
            this.btnPassword.Click += new System.EventHandler(this.btnPassword_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(85, 200);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(395, 37);
            this.txtAmount.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtAmount.StateCommon.Border.Rounding = 15F;
            this.txtAmount.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txtAmount.TabIndex = 4;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(43, 130);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(500, 31);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Lưu ý: Bạn có thể nộp dư để khấu trừ vào nợ gốc";
            // 
            // btnRepayment
            // 
            this.btnRepayment.Location = new System.Drawing.Point(1084, 587);
            this.btnRepayment.Name = "btnRepayment";
            this.btnRepayment.Size = new System.Drawing.Size(245, 167);
            this.btnRepayment.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnRepayment.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnRepayment.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnRepayment.StateCommon.Back.Image")));
            this.btnRepayment.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnRepayment.StateCommon.Border.Rounding = 25F;
            this.btnRepayment.TabIndex = 1;
            this.btnRepayment.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnRepayment.Values.Text = "";
            this.btnRepayment.Click += new System.EventHandler(this.btnRepayment_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(818, 587);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(245, 167);
            this.kryptonButton2.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton2.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton2.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton2.StateCommon.Back.Image")));
            this.kryptonButton2.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.kryptonButton2.StateCommon.Border.Rounding = 25F;
            this.kryptonButton2.TabIndex = 2;
            this.kryptonButton2.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton2.Values.Text = "";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // ucLoanDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.btnRepayment);
            this.Controls.Add(this.btnCreateLoan);
            this.Controls.Add(this.panelPaidAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.lblTotalExpectedAmount);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblll);
            this.Controls.Add(this.lblAmountRepayment);
            this.Controls.Add(this.flowLayoutListLoan);
            this.Controls.Add(this.chartAmount);
            this.Name = "ucLoanDashboard";
            this.Size = new System.Drawing.Size(1387, 791);
            this.Load += new System.EventHandler(this.ucLoanDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPaidAmount.Panel)).EndInit();
            this.panelPaidAmount.Panel.ResumeLayout(false);
            this.panelPaidAmount.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelPaidAmount)).EndInit();
            this.panelPaidAmount.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonButton btnCreateLoan;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAmount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutListLoan;
        private System.Windows.Forms.Label lblAmountRepayment;
        private System.Windows.Forms.Label lblll;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblTotalExpectedAmount;
        private Krypton.Toolkit.KryptonButton btnPayment;
        private System.Windows.Forms.Label lblTotalAmount;
        private Krypton.Toolkit.KryptonGroup panelPaidAmount;
        private Krypton.Toolkit.KryptonButton btnConfirm;
        private Krypton.Toolkit.KryptonLabel lblExpectedTotalAmount;
        private Krypton.Toolkit.KryptonTextBox txtCheckPassword;
        private Krypton.Toolkit.KryptonButton btnExitCheckPassword;
        private Krypton.Toolkit.KryptonButton btnPassword;
        private Krypton.Toolkit.KryptonTextBox txtAmount;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonButton btnRepayment;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
    }
}
