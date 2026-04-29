namespace GUI
{
    partial class ucSavingTransactionCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSavingTransactionCard));
            this.lblDate = new Krypton.Toolkit.KryptonLabel();
            this.lblTransactionType = new Krypton.Toolkit.KryptonLabel();
            this.lblAmount = new Krypton.Toolkit.KryptonLabel();
            this.lblTransactionDate = new Krypton.Toolkit.KryptonLabel();
            this.lblnterestRate = new Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(103, 23);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(300, 28);
            this.lblDate.StateCommon.ShortText.Color1 = System.Drawing.Color.Gray;
            this.lblDate.StateCommon.ShortText.Color2 = System.Drawing.Color.Gray;
            this.lblDate.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.TabIndex = 0;
            this.lblDate.Values.Text = "kryptonLabel1";
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.Location = new System.Drawing.Point(30, 96);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(148, 28);
            this.lblTransactionType.StateCommon.ShortText.Color1 = System.Drawing.Color.Gray;
            this.lblTransactionType.StateCommon.ShortText.Color2 = System.Drawing.Color.Gray;
            this.lblTransactionType.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionType.TabIndex = 1;
            this.lblTransactionType.Values.Text = "kryptonLabel1";
            // 
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(310, 96);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(200, 28);
            this.lblAmount.StateCommon.ShortText.Color1 = System.Drawing.Color.SpringGreen;
            this.lblAmount.StateCommon.ShortText.Color2 = System.Drawing.Color.Chartreuse;
            this.lblAmount.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Values.Text = "kryptonLabel1";
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.Location = new System.Drawing.Point(30, 154);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(148, 28);
            this.lblTransactionDate.StateCommon.ShortText.Color1 = System.Drawing.Color.IndianRed;
            this.lblTransactionDate.StateCommon.ShortText.Color2 = System.Drawing.Color.IndianRed;
            this.lblTransactionDate.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionDate.TabIndex = 3;
            this.lblTransactionDate.Values.Text = "kryptonLabel1";
            // 
            // lblnterestRate
            // 
            this.lblnterestRate.Location = new System.Drawing.Point(310, 154);
            this.lblnterestRate.Name = "lblnterestRate";
            this.lblnterestRate.Size = new System.Drawing.Size(250, 28);
            this.lblnterestRate.StateCommon.ShortText.Color1 = System.Drawing.Color.IndianRed;
            this.lblnterestRate.StateCommon.ShortText.Color2 = System.Drawing.Color.IndianRed;
            this.lblnterestRate.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnterestRate.TabIndex = 4;
            this.lblnterestRate.Values.Text = "kryptonLabel1";
            // 
            // ucSavingTransactionCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblnterestRate);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.lblDate);
            this.Name = "ucSavingTransactionCard";
            this.Size = new System.Drawing.Size(560, 214);
            this.Load += new System.EventHandler(this.ucSavingTransactionCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel lblDate;
        private Krypton.Toolkit.KryptonLabel lblTransactionType;
        private Krypton.Toolkit.KryptonLabel lblAmount;
        private Krypton.Toolkit.KryptonLabel lblTransactionDate;
        private Krypton.Toolkit.KryptonLabel lblnterestRate;
    }
}
