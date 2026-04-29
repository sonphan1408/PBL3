namespace GUI
{
    partial class ucDeposit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDeposit));
            this.txtDeposit = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.lblAccountNumber = new Krypton.Toolkit.KryptonLabel();
            this.lblBalance = new Krypton.Toolkit.KryptonLabel();
            this.lblContractId = new Krypton.Toolkit.KryptonLabel();
            this.lblBalanceSaving = new Krypton.Toolkit.KryptonLabel();
            this.lblInterest = new Krypton.Toolkit.KryptonLabel();
            this.btnDeposit = new Krypton.Toolkit.KryptonButton();
            this.btnBack = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(449, 126);
            this.txtDeposit.Multiline = true;
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(458, 56);
            this.txtDeposit.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtDeposit.StateCommon.Border.Rounding = 15F;
            this.txtDeposit.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txtDeposit.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeposit.TabIndex = 2;
            this.txtDeposit.TextChanged += new System.EventHandler(this.txtDeposit_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(458, 206);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(200, 25);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Gray;
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Silver;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Tối thiểu 50,000 VNĐ";
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.Location = new System.Drawing.Point(492, 330);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(200, 25);
            this.lblAccountNumber.StateCommon.ShortText.Color1 = System.Drawing.Color.Coral;
            this.lblAccountNumber.StateCommon.ShortText.Color2 = System.Drawing.Color.Silver;
            this.lblAccountNumber.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNumber.TabIndex = 4;
            this.lblAccountNumber.Values.Text = "Tối thiểu 50,000 VNĐ";
            // 
            // lblBalance
            // 
            this.lblBalance.Location = new System.Drawing.Point(492, 370);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(200, 25);
            this.lblBalance.StateCommon.ShortText.Color1 = System.Drawing.Color.Gray;
            this.lblBalance.StateCommon.ShortText.Color2 = System.Drawing.Color.Silver;
            this.lblBalance.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.TabIndex = 5;
            this.lblBalance.Values.Text = "Tối thiểu 50,000 VNĐ";
            // 
            // lblContractId
            // 
            this.lblContractId.Location = new System.Drawing.Point(707, 502);
            this.lblContractId.Name = "lblContractId";
            this.lblContractId.Size = new System.Drawing.Size(200, 25);
            this.lblContractId.StateCommon.ShortText.Color1 = System.Drawing.Color.Gray;
            this.lblContractId.StateCommon.ShortText.Color2 = System.Drawing.Color.Silver;
            this.lblContractId.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContractId.TabIndex = 6;
            this.lblContractId.Values.Text = "Tối thiểu 50,000 VNĐ";
            this.lblContractId.Click += new System.EventHandler(this.lblContractId_Click);
            // 
            // lblBalanceSaving
            // 
            this.lblBalanceSaving.Location = new System.Drawing.Point(625, 546);
            this.lblBalanceSaving.Name = "lblBalanceSaving";
            this.lblBalanceSaving.Size = new System.Drawing.Size(200, 25);
            this.lblBalanceSaving.StateCommon.ShortText.Color1 = System.Drawing.Color.Gray;
            this.lblBalanceSaving.StateCommon.ShortText.Color2 = System.Drawing.Color.Silver;
            this.lblBalanceSaving.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceSaving.TabIndex = 7;
            this.lblBalanceSaving.Values.Text = "Tối thiểu 50,000 VNĐ";
            // 
            // lblInterest
            // 
            this.lblInterest.Location = new System.Drawing.Point(625, 591);
            this.lblInterest.Name = "lblInterest";
            this.lblInterest.Size = new System.Drawing.Size(200, 25);
            this.lblInterest.StateCommon.ShortText.Color1 = System.Drawing.Color.Gray;
            this.lblInterest.StateCommon.ShortText.Color2 = System.Drawing.Color.Silver;
            this.lblInterest.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterest.TabIndex = 8;
            this.lblInterest.Values.Text = "Tối thiểu 50,000 VNĐ";
            // 
            // btnDeposit
            // 
            this.btnDeposit.Location = new System.Drawing.Point(725, 693);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(170, 44);
            this.btnDeposit.StateCommon.Back.Color1 = System.Drawing.Color.Cyan;
            this.btnDeposit.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
            this.btnDeposit.StateCommon.Border.Rounding = 20F;
            this.btnDeposit.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnDeposit.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnDeposit.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeposit.TabIndex = 25;
            this.btnDeposit.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnDeposit.Values.Text = "Gửi thêm";
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(497, 693);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(170, 44);
            this.btnBack.StateCommon.Back.Color1 = System.Drawing.Color.Cyan;
            this.btnBack.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
            this.btnBack.StateCommon.Border.Rounding = 20F;
            this.btnBack.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnBack.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnBack.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.TabIndex = 26;
            this.btnBack.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnBack.Values.Text = "Quay lại";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ucDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.lblInterest);
            this.Controls.Add(this.lblBalanceSaving);
            this.Controls.Add(this.lblContractId);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblAccountNumber);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.txtDeposit);
            this.Name = "ucDeposit";
            this.Size = new System.Drawing.Size(1387, 791);
            this.Load += new System.EventHandler(this.ucDeposit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox txtDeposit;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel lblAccountNumber;
        private Krypton.Toolkit.KryptonLabel lblBalance;
        private Krypton.Toolkit.KryptonLabel lblContractId;
        private Krypton.Toolkit.KryptonLabel lblBalanceSaving;
        private Krypton.Toolkit.KryptonLabel lblInterest;
        private Krypton.Toolkit.KryptonButton btnDeposit;
        private Krypton.Toolkit.KryptonButton btnBack;
    }
}
