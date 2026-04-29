namespace GUI
{
    partial class ucSavingCardTerm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSavingCardTerm));
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.panelTotalDay = new Krypton.Toolkit.KryptonGroup();
            this.panelPassedDay = new Krypton.Toolkit.KryptonGroup();
            this.lblAccruedInterest = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblContractId = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblInterestRate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelTotalDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTotalDay.Panel)).BeginInit();
            this.panelTotalDay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelPassedDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPassedDay.Panel)).BeginInit();
            this.panelPassedDay.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(145, 239);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(330, 34);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.Gold;
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.Crimson;
            this.kryptonButton1.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.kryptonButton1.StateCommon.Border.Rounding = 15F;
            this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 3;
            this.kryptonButton1.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton1.Values.Text = "Truy vấn và tất toán ";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // panelTotalDay
            // 
            this.panelTotalDay.Location = new System.Drawing.Point(32, 163);
            this.panelTotalDay.Size = new System.Drawing.Size(535, 10);
            this.panelTotalDay.StateCommon.Back.Color1 = System.Drawing.Color.LightGray;
            this.panelTotalDay.StateCommon.Border.Rounding = 15F;
            this.panelTotalDay.StateDisabled.Border.Rounding = 15F;
            this.panelTotalDay.TabIndex = 5;
            // 
            // panelPassedDay
            // 
            this.panelPassedDay.Location = new System.Drawing.Point(32, 163);
            this.panelPassedDay.Size = new System.Drawing.Size(386, 10);
            this.panelPassedDay.StateCommon.Back.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.panelPassedDay.StateCommon.Border.Rounding = 15F;
            this.panelPassedDay.TabIndex = 6;
            this.panelPassedDay.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonGroup2_Paint);
            // 
            // lblAccruedInterest
            // 
            this.lblAccruedInterest.AutoSize = true;
            this.lblAccruedInterest.BackColor = System.Drawing.Color.White;
            this.lblAccruedInterest.ForeColor = System.Drawing.Color.Lime;
            this.lblAccruedInterest.Location = new System.Drawing.Point(125, 132);
            this.lblAccruedInterest.Name = "lblAccruedInterest";
            this.lblAccruedInterest.Size = new System.Drawing.Size(71, 16);
            this.lblAccruedInterest.TabIndex = 2;
            this.lblAccruedInterest.Text = "Lãi dự kiến";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.BackColor = System.Drawing.Color.White;
            this.lblStartDate.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblStartDate.Location = new System.Drawing.Point(20, 186);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(71, 16);
            this.lblStartDate.TabIndex = 7;
            this.lblStartDate.Text = "Lãi dự kiến";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.BackColor = System.Drawing.Color.White;
            this.lblEndDate.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblEndDate.Location = new System.Drawing.Point(484, 186);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(71, 16);
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "Lãi dự kiến";
            // 
            // lblContractId
            // 
            this.lblContractId.AutoSize = true;
            this.lblContractId.BackColor = System.Drawing.Color.White;
            this.lblContractId.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblContractId.Location = new System.Drawing.Point(196, 52);
            this.lblContractId.Name = "lblContractId";
            this.lblContractId.Size = new System.Drawing.Size(71, 16);
            this.lblContractId.TabIndex = 9;
            this.lblContractId.Text = "Lãi dự kiến";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Gold;
            this.lblBalance.Location = new System.Drawing.Point(27, 93);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(90, 25);
            this.lblBalance.TabIndex = 10;
            this.lblBalance.Text = "Tiền gửi";
            // 
            // lblInterestRate
            // 
            this.lblInterestRate.AutoSize = true;
            this.lblInterestRate.BackColor = System.Drawing.Color.White;
            this.lblInterestRate.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblInterestRate.Location = new System.Drawing.Point(224, 132);
            this.lblInterestRate.Name = "lblInterestRate";
            this.lblInterestRate.Size = new System.Drawing.Size(71, 16);
            this.lblInterestRate.TabIndex = 12;
            this.lblInterestRate.Text = "Lãi dự kiến";
            // 
            // ucSavingCardTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblInterestRate);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblContractId);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.panelPassedDay);
            this.Controls.Add(this.panelTotalDay);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.lblAccruedInterest);
            this.Name = "ucSavingCardTerm";
            this.Size = new System.Drawing.Size(653, 300);
            this.Load += new System.EventHandler(this.ucSavingCardInstallment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTotalDay.Panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTotalDay)).EndInit();
            this.panelTotalDay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelPassedDay.Panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPassedDay)).EndInit();
            this.panelPassedDay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonGroup panelTotalDay;
        private Krypton.Toolkit.KryptonGroup panelPassedDay;
        private System.Windows.Forms.Label lblAccruedInterest;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblContractId;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblInterestRate;
    }
}
