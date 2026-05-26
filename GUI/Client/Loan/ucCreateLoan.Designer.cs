namespace GUI.Client.Loan
{
    partial class ucCreateLoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCreateLoan));
            this.txtLoanAmount = new Krypton.Toolkit.KryptonTextBox();
            this.btn1000 = new Krypton.Toolkit.KryptonButton();
            this.btn500 = new Krypton.Toolkit.KryptonButton();
            this.btn200 = new Krypton.Toolkit.KryptonButton();
            this.btn100 = new Krypton.Toolkit.KryptonButton();
            this.cbTermMonths = new Krypton.Toolkit.KryptonComboBox();
            this.btnBack = new Krypton.Toolkit.KryptonButton();
            this.btnContinue = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbTermMonths)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLoanAmount
            // 
            this.txtLoanAmount.Location = new System.Drawing.Point(755, 196);
            this.txtLoanAmount.Multiline = true;
            this.txtLoanAmount.Name = "txtLoanAmount";
            this.txtLoanAmount.Size = new System.Drawing.Size(458, 56);
            this.txtLoanAmount.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtLoanAmount.StateCommon.Border.Rounding = 15F;
            this.txtLoanAmount.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txtLoanAmount.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanAmount.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.txtLoanAmount.TabIndex = 3;
            this.txtLoanAmount.TextChanged += new System.EventHandler(this.txtLoanAmount_TextChanged);
            // 
            // btn1000
            // 
            this.btn1000.Location = new System.Drawing.Point(1117, 285);
            this.btn1000.Name = "btn1000";
            this.btn1000.Size = new System.Drawing.Size(96, 33);
            this.btn1000.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btn1000.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btn1000.StateCommon.Border.Rounding = 15F;
            this.btn1000.TabIndex = 9;
            this.btn1000.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btn1000.Values.Text = "1.000.000";
            this.btn1000.Click += new System.EventHandler(this.btn1000_Click);
            // 
            // btn500
            // 
            this.btn500.Location = new System.Drawing.Point(992, 285);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(95, 33);
            this.btn500.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btn500.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btn500.StateCommon.Border.Rounding = 15F;
            this.btn500.TabIndex = 8;
            this.btn500.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btn500.Values.Text = "500.000";
            this.btn500.Click += new System.EventHandler(this.btn500_Click);
            // 
            // btn200
            // 
            this.btn200.Location = new System.Drawing.Point(867, 285);
            this.btn200.Name = "btn200";
            this.btn200.Size = new System.Drawing.Size(95, 33);
            this.btn200.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btn200.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btn200.StateCommon.Border.Rounding = 15F;
            this.btn200.TabIndex = 7;
            this.btn200.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btn200.Values.Text = "200.000";
            this.btn200.Click += new System.EventHandler(this.btn200_Click);
            // 
            // btn100
            // 
            this.btn100.Location = new System.Drawing.Point(742, 285);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(95, 33);
            this.btn100.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btn100.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btn100.StateCommon.Border.Rounding = 15F;
            this.btn100.TabIndex = 6;
            this.btn100.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btn100.Values.Text = "100.000";
            this.btn100.Click += new System.EventHandler(this.btn100_Click);
            // 
            // cbTermMonths
            // 
            this.cbTermMonths.DropDownWidth = 471;
            this.cbTermMonths.Location = new System.Drawing.Point(755, 404);
            this.cbTermMonths.Name = "cbTermMonths";
            this.cbTermMonths.Size = new System.Drawing.Size(432, 35);
            this.cbTermMonths.StateCommon.ComboBox.Border.Rounding = 10F;
            this.cbTermMonths.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTermMonths.StateCommon.ComboBox.Content.Padding = new System.Windows.Forms.Padding(0);
            this.cbTermMonths.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cbTermMonths.TabIndex = 10;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(797, 684);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(170, 44);
            this.btnBack.StateCommon.Back.Color1 = System.Drawing.Color.Cyan;
            this.btnBack.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
            this.btnBack.StateCommon.Border.Rounding = 20F;
            this.btnBack.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnBack.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnBack.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.TabIndex = 28;
            this.btnBack.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnBack.Values.Text = "Quay lại";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(1025, 684);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(170, 44);
            this.btnContinue.StateCommon.Back.Color1 = System.Drawing.Color.Cyan;
            this.btnContinue.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
            this.btnContinue.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnContinue.StateCommon.Back.Image")));
            this.btnContinue.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnContinue.StateCommon.Border.Rounding = 20F;
            this.btnContinue.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnContinue.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnContinue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.TabIndex = 27;
            this.btnContinue.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnContinue.Values.Text = "";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // ucCreateLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.cbTermMonths);
            this.Controls.Add(this.btn1000);
            this.Controls.Add(this.btn500);
            this.Controls.Add(this.btn200);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.txtLoanAmount);
            this.Name = "ucCreateLoan";
            this.Size = new System.Drawing.Size(1387, 791);
            this.Load += new System.EventHandler(this.ucCreateLoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbTermMonths)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox txtLoanAmount;
        private Krypton.Toolkit.KryptonButton btn1000;
        private Krypton.Toolkit.KryptonButton btn500;
        private Krypton.Toolkit.KryptonButton btn200;
        private Krypton.Toolkit.KryptonButton btn100;
        private Krypton.Toolkit.KryptonComboBox cbTermMonths;
        private Krypton.Toolkit.KryptonButton btnBack;
        private Krypton.Toolkit.KryptonButton btnContinue;
    }
}
