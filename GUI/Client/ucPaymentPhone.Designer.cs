namespace GUI.Client
{
    partial class ucPaymentPhone
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
            this.txtPhoneNumber = new Krypton.Toolkit.KryptonTextBox();
            this.lbPhoneNumber = new Krypton.Toolkit.KryptonLabel();
            this.lbProvider = new Krypton.Toolkit.KryptonLabel();
            this.cboProvider = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonContextMenu1 = new Krypton.Toolkit.KryptonContextMenu();
            this.Confirm = new System.Windows.Forms.Button();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.Exit = new System.Windows.Forms.Button();
            this.pnlUnpaidList = new Krypton.Toolkit.KryptonPanel();
            this.txtPassword = new Krypton.Toolkit.KryptonTextBox();
            this.lblPassword = new Krypton.Toolkit.KryptonLabel();
            this.txtAmount = new Krypton.Toolkit.KryptonTextBox();
            this.lblAmount = new Krypton.Toolkit.KryptonLabel();
            this.pnlAmountSelection = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUnpaidList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAmountSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(110, 443);
            this.txtPhoneNumber.Multiline = true;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(569, 40);
            this.txtPhoneNumber.StateCommon.Border.Rounding = 8F;
            this.txtPhoneNumber.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.TabIndex = 28;
            this.txtPhoneNumber.UseSystemPasswordChar = true;
            this.txtPhoneNumber.WordWrap = false;
            this.txtPhoneNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerCode_KeyDown);
            // 
            // lbPhoneNumber
            // 
            this.lbPhoneNumber.LabelStyle = Krypton.Toolkit.LabelStyle.SuperTip;
            this.lbPhoneNumber.Location = new System.Drawing.Point(100, 399);
            this.lbPhoneNumber.Name = "lbPhoneNumber";
            this.lbPhoneNumber.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007BlueLightMode;
            this.lbPhoneNumber.Size = new System.Drawing.Size(262, 38);
            this.lbPhoneNumber.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhoneNumber.TabIndex = 27;
            this.lbPhoneNumber.Values.Text = "Số điện thoại";
            // 
            // lbProvider
            // 
            this.lbProvider.LabelStyle = Krypton.Toolkit.LabelStyle.SuperTip;
            this.lbProvider.Location = new System.Drawing.Point(100, 305);
            this.lbProvider.Name = "lbProvider";
            this.lbProvider.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007BlueLightMode;
            this.lbProvider.Size = new System.Drawing.Size(262, 38);
            this.lbProvider.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProvider.TabIndex = 26;
            this.lbProvider.Values.Text = "Chọn nhà cung cấp dịch vụ";
            // 
            // cboProvider
            // 
            this.cboProvider.DropDownWidth = 535;
            this.cboProvider.Location = new System.Drawing.Point(110, 348);
            this.cboProvider.Name = "cboProvider";
            this.cboProvider.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007Black;
            this.cboProvider.Size = new System.Drawing.Size(569, 43);
            this.cboProvider.StateCommon.ComboBox.Border.Rounding = 8F;
            this.cboProvider.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvider.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cboProvider.TabIndex = 25;
            // 
            // Confirm
            // 
            this.Confirm.BackColor = System.Drawing.Color.Transparent;
            this.Confirm.FlatAppearance.BorderColor = System.Drawing.Color.MediumBlue;
            this.Confirm.FlatAppearance.BorderSize = 0;
            this.Confirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Confirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Confirm.Location = new System.Drawing.Point(398, 694);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(194, 26);
            this.Confirm.TabIndex = 36;
            this.Confirm.UseVisualStyleBackColor = false;
            this.Confirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.KeyTip;
            this.kryptonLabel1.Location = new System.Drawing.Point(188, 181);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(300, 30);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 35;
            this.kryptonLabel1.Values.Text = "";
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Location = new System.Drawing.Point(145, 691);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(194, 32);
            this.Exit.TabIndex = 34;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlUnpaidList
            // 
            this.pnlUnpaidList.Location = new System.Drawing.Point(764, 348);
            this.pnlUnpaidList.Name = "pnlUnpaidList";
            this.pnlUnpaidList.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.ContextMenuInner;
            this.pnlUnpaidList.Size = new System.Drawing.Size(549, 392);
            this.pnlUnpaidList.TabIndex = 33;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(110, 620);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(569, 40);
            this.txtPassword.StateCommon.Border.Rounding = 8F;
            this.txtPassword.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.TabIndex = 32;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Visible = false;
            this.txtPassword.WordWrap = false;
            // 
            // lblPassword
            // 
            this.lblPassword.LabelStyle = Krypton.Toolkit.LabelStyle.SuperTip;
            this.lblPassword.Location = new System.Drawing.Point(100, 576);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007BlueLightMode;
            this.lblPassword.Size = new System.Drawing.Size(262, 38);
            this.lblPassword.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.TabIndex = 31;
            this.lblPassword.Values.Text = "Mật khẩu";
            this.lblPassword.Visible = false;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(110, 528);
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(569, 40);
            this.txtAmount.StateCommon.Border.Rounding = 8F;
            this.txtAmount.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.TabIndex = 30;
            this.txtAmount.UseSystemPasswordChar = true;
            this.txtAmount.Visible = false;
            this.txtAmount.WordWrap = false;
            // 
            // lblAmount
            // 
            this.lblAmount.LabelStyle = Krypton.Toolkit.LabelStyle.SuperTip;
            this.lblAmount.Location = new System.Drawing.Point(100, 485);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007BlueLightMode;
            this.lblAmount.Size = new System.Drawing.Size(262, 38);
            this.lblAmount.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.TabIndex = 29;
            this.lblAmount.Values.Text = "Số tiền";
            this.lblAmount.Visible = false;
            // 
            // pnlAmountSelection
            // 
            this.pnlAmountSelection.Location = new System.Drawing.Point(100, 518);
            this.pnlAmountSelection.Name = "pnlAmountSelection";
            this.pnlAmountSelection.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.ContextMenuInner;
            this.pnlAmountSelection.Size = new System.Drawing.Size(604, 167);
            this.pnlAmountSelection.TabIndex = 34;
            // 
            // ucPaymentPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Properties.Resources.PaymentPhoneNew;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pnlAmountSelection);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.lbPhoneNumber);
            this.Controls.Add(this.lbProvider);
            this.Controls.Add(this.cboProvider);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.pnlUnpaidList);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.DoubleBuffered = true;
            this.Name = "ucPaymentPhone";
            this.Size = new System.Drawing.Size(1387, 791);
            ((System.ComponentModel.ISupportInitialize)(this.cboProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUnpaidList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAmountSelection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox txtPhoneNumber;
        private Krypton.Toolkit.KryptonLabel lbPhoneNumber;
        private Krypton.Toolkit.KryptonLabel lbProvider;
        private Krypton.Toolkit.KryptonComboBox cboProvider;
        private Krypton.Toolkit.KryptonContextMenu kryptonContextMenu1;
        private System.Windows.Forms.Button Confirm;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.Button Exit;
        private Krypton.Toolkit.KryptonPanel pnlUnpaidList;
        private Krypton.Toolkit.KryptonTextBox txtPassword;
        private Krypton.Toolkit.KryptonLabel lblPassword;
        private Krypton.Toolkit.KryptonTextBox txtAmount;
        private Krypton.Toolkit.KryptonLabel lblAmount;
        private Krypton.Toolkit.KryptonPanel pnlAmountSelection;
    }
}
