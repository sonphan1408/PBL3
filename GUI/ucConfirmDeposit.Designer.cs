namespace GUI
{
    partial class ucConfirmDeposit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucConfirmDeposit));
            this.lblDepositAmount = new Krypton.Toolkit.KryptonLabel();
            this.lblContracId = new Krypton.Toolkit.KryptonLabel();
            this.lblAccountNumber = new Krypton.Toolkit.KryptonLabel();
            this.lblFullName = new Krypton.Toolkit.KryptonLabel();
            this.btnConfirm = new Krypton.Toolkit.KryptonButton();
            this.btnBack = new Krypton.Toolkit.KryptonButton();
            this.panelCheckPassword = new Krypton.Toolkit.KryptonGroup();
            this.btnExitCheckPassword = new Krypton.Toolkit.KryptonButton();
            this.btnPassword = new Krypton.Toolkit.KryptonButton();
            this.txtCheckPassword = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelCheckPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCheckPassword.Panel)).BeginInit();
            this.panelCheckPassword.Panel.SuspendLayout();
            this.panelCheckPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDepositAmount
            // 
            this.lblDepositAmount.Location = new System.Drawing.Point(607, 309);
            this.lblDepositAmount.Name = "lblDepositAmount";
            this.lblDepositAmount.Size = new System.Drawing.Size(200, 25);
            this.lblDepositAmount.StateCommon.ShortText.Color1 = System.Drawing.Color.Gray;
            this.lblDepositAmount.StateCommon.ShortText.Color2 = System.Drawing.Color.Silver;
            this.lblDepositAmount.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepositAmount.TabIndex = 5;
            this.lblDepositAmount.Values.Text = "Tối thiểu 50,000 VNĐ";
            // 
            // lblContracId
            // 
            this.lblContracId.Location = new System.Drawing.Point(824, 436);
            this.lblContracId.Name = "lblContracId";
            this.lblContracId.Size = new System.Drawing.Size(200, 25);
            this.lblContracId.StateCommon.ShortText.Color1 = System.Drawing.Color.Gray;
            this.lblContracId.StateCommon.ShortText.Color2 = System.Drawing.Color.Silver;
            this.lblContracId.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContracId.TabIndex = 6;
            this.lblContracId.Values.Text = "Tối thiểu 50,000 VNĐ";
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.Location = new System.Drawing.Point(620, 521);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(200, 25);
            this.lblAccountNumber.StateCommon.ShortText.Color1 = System.Drawing.Color.Gray;
            this.lblAccountNumber.StateCommon.ShortText.Color2 = System.Drawing.Color.Silver;
            this.lblAccountNumber.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNumber.TabIndex = 7;
            this.lblAccountNumber.Values.Text = "Tối thiểu 50,000 VNĐ";
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(620, 561);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(200, 25);
            this.lblFullName.StateCommon.ShortText.Color1 = System.Drawing.Color.Gray;
            this.lblFullName.StateCommon.ShortText.Color2 = System.Drawing.Color.Silver;
            this.lblFullName.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.TabIndex = 8;
            this.lblFullName.Values.Text = "Tối thiểu 50,000 VNĐ";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(867, 650);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(170, 44);
            this.btnConfirm.StateCommon.Back.Color1 = System.Drawing.Color.Cyan;
            this.btnConfirm.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
            this.btnConfirm.StateCommon.Border.Rounding = 20F;
            this.btnConfirm.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnConfirm.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnConfirm.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.TabIndex = 26;
            this.btnConfirm.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnConfirm.Values.Text = "Xác nhận";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(620, 650);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(170, 44);
            this.btnBack.StateCommon.Back.Color1 = System.Drawing.Color.Cyan;
            this.btnBack.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
            this.btnBack.StateCommon.Border.Rounding = 20F;
            this.btnBack.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnBack.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnBack.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.TabIndex = 27;
            this.btnBack.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnBack.Values.Text = "Quay lại";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panelCheckPassword
            // 
            this.panelCheckPassword.Location = new System.Drawing.Point(282, 502);
            // 
            // panelCheckPassword.Panel
            // 
            this.panelCheckPassword.Panel.Controls.Add(this.btnExitCheckPassword);
            this.panelCheckPassword.Panel.Controls.Add(this.btnPassword);
            this.panelCheckPassword.Panel.Controls.Add(this.txtCheckPassword);
            this.panelCheckPassword.Panel.Controls.Add(this.kryptonLabel1);
            this.panelCheckPassword.Size = new System.Drawing.Size(966, 214);
            this.panelCheckPassword.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.panelCheckPassword.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.panelCheckPassword.StateCommon.Border.Color1 = System.Drawing.Color.Cyan;
            this.panelCheckPassword.StateCommon.Border.Rounding = 15F;
            this.panelCheckPassword.TabIndex = 28;
            // 
            // btnExitCheckPassword
            // 
            this.btnExitCheckPassword.Location = new System.Drawing.Point(893, 12);
            this.btnExitCheckPassword.Name = "btnExitCheckPassword";
            this.btnExitCheckPassword.Size = new System.Drawing.Size(35, 35);
            this.btnExitCheckPassword.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnExitCheckPassword.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnExitCheckPassword.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnExitCheckPassword.StateCommon.Back.Image")));
            this.btnExitCheckPassword.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnExitCheckPassword.TabIndex = 12;
            this.btnExitCheckPassword.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnExitCheckPassword.Values.Text = "";
            this.btnExitCheckPassword.Click += new System.EventHandler(this.btnExitCheckPassword_Click);
            // 
            // btnPassword
            // 
            this.btnPassword.Location = new System.Drawing.Point(363, 128);
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
            // txtCheckPassword
            // 
            this.txtCheckPassword.Location = new System.Drawing.Point(270, 66);
            this.txtCheckPassword.Name = "txtCheckPassword";
            this.txtCheckPassword.PasswordChar = '●';
            this.txtCheckPassword.Size = new System.Drawing.Size(395, 37);
            this.txtCheckPassword.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtCheckPassword.StateCommon.Border.Rounding = 15F;
            this.txtCheckPassword.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txtCheckPassword.TabIndex = 4;
            this.txtCheckPassword.UseSystemPasswordChar = true;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(315, 16);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(350, 31);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Vui lòng nhập mật khẩu";
            // 
            // ucConfirmDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panelCheckPassword);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblAccountNumber);
            this.Controls.Add(this.lblContracId);
            this.Controls.Add(this.lblDepositAmount);
            this.Name = "ucConfirmDeposit";
            this.Size = new System.Drawing.Size(1387, 791);
            this.Load += new System.EventHandler(this.ucConfirmDeposit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelCheckPassword.Panel)).EndInit();
            this.panelCheckPassword.Panel.ResumeLayout(false);
            this.panelCheckPassword.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelCheckPassword)).EndInit();
            this.panelCheckPassword.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel lblDepositAmount;
        private Krypton.Toolkit.KryptonLabel lblContracId;
        private Krypton.Toolkit.KryptonLabel lblAccountNumber;
        private Krypton.Toolkit.KryptonLabel lblFullName;
        private Krypton.Toolkit.KryptonButton btnConfirm;
        private Krypton.Toolkit.KryptonButton btnBack;
        private Krypton.Toolkit.KryptonGroup panelCheckPassword;
        private Krypton.Toolkit.KryptonButton btnExitCheckPassword;
        private Krypton.Toolkit.KryptonButton btnPassword;
        private Krypton.Toolkit.KryptonTextBox txtCheckPassword;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
