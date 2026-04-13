namespace GUI.Client
{
    partial class ucTransfer
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnTransferInternal = new Krypton.Toolkit.KryptonButton();
            this.btnTransferInterbank = new Krypton.Toolkit.KryptonButton();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDNguoiNhan = new Krypton.Toolkit.KryptonTextBox();
            this.btnTim = new Krypton.Toolkit.KryptonButton();
            this.pnlFlow = new System.Windows.Forms.Panel();
            this.txtTenUser = new System.Windows.Forms.Label();
            this.txtTenNguoiNhan = new System.Windows.Forms.Label();
            this.txtIDUser = new System.Windows.Forms.Label();
            this.txtIDNguoiNhan1 = new System.Windows.Forms.Label();
            this.lblArrow = new System.Windows.Forms.Label();
            this.pnlAmount = new System.Windows.Forms.Panel();
            this.btnCK = new Krypton.Toolkit.KryptonButton();
            this.txtNDCK = new Krypton.Toolkit.KryptonRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn1000 = new Krypton.Toolkit.KryptonButton();
            this.btn500 = new Krypton.Toolkit.KryptonButton();
            this.btn200 = new Krypton.Toolkit.KryptonButton();
            this.btn100 = new Krypton.Toolkit.KryptonButton();
            this.txtSoTien = new Krypton.Toolkit.KryptonTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlRight1 = new System.Windows.Forms.Panel();
            this.txtSoDu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlRight2 = new System.Windows.Forms.Panel();
            this.pnlTabs.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlFlow.SuspendLayout();
            this.pnlAmount.SuspendLayout();
            this.pnlRight1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Location = new System.Drawing.Point(62, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(294, 55);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chuyển tiền";
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.Transparent;
            this.pnlTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTabs.Controls.Add(this.btnTransferInternal);
            this.pnlTabs.Controls.Add(this.btnTransferInterbank);
            this.pnlTabs.Location = new System.Drawing.Point(62, 85);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(560, 75);
            this.pnlTabs.TabIndex = 1;
            // 
            // btnTransferInternal
            // 
            this.btnTransferInternal.Location = new System.Drawing.Point(25, 18);
            this.btnTransferInternal.Name = "btnTransferInternal";
            this.btnTransferInternal.Size = new System.Drawing.Size(220, 40);
            this.btnTransferInternal.StateCommon.Border.Rounding = 15F;
            this.btnTransferInternal.TabIndex = 0;
            this.btnTransferInternal.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnTransferInternal.Values.Text = "Chuyển khoản nội bộ";
            // 
            // btnTransferInterbank
            // 
            this.btnTransferInterbank.Location = new System.Drawing.Point(315, 18);
            this.btnTransferInterbank.Name = "btnTransferInterbank";
            this.btnTransferInterbank.Size = new System.Drawing.Size(220, 40);
            this.btnTransferInterbank.StateCommon.Border.Rounding = 15F;
            this.btnTransferInterbank.TabIndex = 1;
            this.btnTransferInterbank.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnTransferInterbank.Values.Text = "Chuyển khoản liên ngân hàng";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.txtIDNguoiNhan);
            this.pnlSearch.Controls.Add(this.btnTim);
            this.pnlSearch.Location = new System.Drawing.Point(62, 170);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(560, 95);
            this.pnlSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F);
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập số tài khoản muốn chuyển";
            // 
            // txtIDNguoiNhan
            // 
            this.txtIDNguoiNhan.Location = new System.Drawing.Point(25, 48);
            this.txtIDNguoiNhan.Name = "txtIDNguoiNhan";
            this.txtIDNguoiNhan.Size = new System.Drawing.Size(375, 27);
            this.txtIDNguoiNhan.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(415, 48);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(120, 32);
            this.btnTim.StateCommon.Border.Rounding = 15F;
            this.btnTim.TabIndex = 2;
            this.btnTim.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnTim.Values.Text = "Find";
            // 
            // pnlFlow
            // 
            this.pnlFlow.BackColor = System.Drawing.Color.Transparent;
            this.pnlFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFlow.Controls.Add(this.txtTenUser);
            this.pnlFlow.Controls.Add(this.txtTenNguoiNhan);
            this.pnlFlow.Controls.Add(this.txtIDUser);
            this.pnlFlow.Controls.Add(this.txtIDNguoiNhan1);
            this.pnlFlow.Controls.Add(this.lblArrow);
            this.pnlFlow.Location = new System.Drawing.Point(62, 275);
            this.pnlFlow.Name = "pnlFlow";
            this.pnlFlow.Size = new System.Drawing.Size(560, 140);
            this.pnlFlow.TabIndex = 3;
            // 
            // txtTenUser
            // 
            this.txtTenUser.AutoSize = true;
            this.txtTenUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenUser.Location = new System.Drawing.Point(34, 81);
            this.txtTenUser.Name = "txtTenUser";
            this.txtTenUser.Size = new System.Drawing.Size(118, 24);
            this.txtTenUser.TabIndex = 2;
            this.txtTenUser.Text = "..................";
            // 
            // txtTenNguoiNhan
            // 
            this.txtTenNguoiNhan.AutoSize = true;
            this.txtTenNguoiNhan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNguoiNhan.Location = new System.Drawing.Point(360, 81);
            this.txtTenNguoiNhan.Name = "txtTenNguoiNhan";
            this.txtTenNguoiNhan.Size = new System.Drawing.Size(118, 24);
            this.txtTenNguoiNhan.TabIndex = 2;
            this.txtTenNguoiNhan.Text = "..................";
            // 
            // txtIDUser
            // 
            this.txtIDUser.AutoSize = true;
            this.txtIDUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDUser.Location = new System.Drawing.Point(34, 30);
            this.txtIDUser.Name = "txtIDUser";
            this.txtIDUser.Size = new System.Drawing.Size(118, 24);
            this.txtIDUser.TabIndex = 1;
            this.txtIDUser.Text = "..................";
            // 
            // txtIDNguoiNhan1
            // 
            this.txtIDNguoiNhan1.AutoSize = true;
            this.txtIDNguoiNhan1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDNguoiNhan1.Location = new System.Drawing.Point(360, 30);
            this.txtIDNguoiNhan1.Name = "txtIDNguoiNhan1";
            this.txtIDNguoiNhan1.Size = new System.Drawing.Size(118, 24);
            this.txtIDNguoiNhan1.TabIndex = 1;
            this.txtIDNguoiNhan1.Text = "..................";
            // 
            // lblArrow
            // 
            this.lblArrow.AutoSize = true;
            this.lblArrow.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.lblArrow.ForeColor = System.Drawing.Color.Black;
            this.lblArrow.Location = new System.Drawing.Point(232, 36);
            this.lblArrow.Name = "lblArrow";
            this.lblArrow.Size = new System.Drawing.Size(92, 63);
            this.lblArrow.TabIndex = 1;
            this.lblArrow.Text = "⟹";
            // 
            // pnlAmount
            // 
            this.pnlAmount.BackColor = System.Drawing.Color.Transparent;
            this.pnlAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAmount.Controls.Add(this.btnCK);
            this.pnlAmount.Controls.Add(this.txtNDCK);
            this.pnlAmount.Controls.Add(this.label8);
            this.pnlAmount.Controls.Add(this.btn1000);
            this.pnlAmount.Controls.Add(this.btn500);
            this.pnlAmount.Controls.Add(this.btn200);
            this.pnlAmount.Controls.Add(this.btn100);
            this.pnlAmount.Controls.Add(this.txtSoTien);
            this.pnlAmount.Controls.Add(this.label7);
            this.pnlAmount.Location = new System.Drawing.Point(62, 425);
            this.pnlAmount.Name = "pnlAmount";
            this.pnlAmount.Size = new System.Drawing.Size(560, 227);
            this.pnlAmount.TabIndex = 4;
            // 
            // btnCK
            // 
            this.btnCK.Location = new System.Drawing.Point(213, 181);
            this.btnCK.Name = "btnCK";
            this.btnCK.Size = new System.Drawing.Size(120, 32);
            this.btnCK.StateCommon.Border.Rounding = 10F;
            this.btnCK.TabIndex = 8;
            this.btnCK.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnCK.Values.Text = "Chuyển khoản";
            // 
            // txtNDCK
            // 
            this.txtNDCK.Location = new System.Drawing.Point(104, 129);
            this.txtNDCK.Name = "txtNDCK";
            this.txtNDCK.Size = new System.Drawing.Size(431, 34);
            this.txtNDCK.TabIndex = 7;
            this.txtNDCK.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11F);
            this.label8.Location = new System.Drawing.Point(18, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 22);
            this.label8.TabIndex = 6;
            this.label8.Text = "Ghi chú";
            // 
            // btn1000
            // 
            this.btn1000.Location = new System.Drawing.Point(400, 80);
            this.btn1000.Name = "btn1000";
            this.btn1000.Size = new System.Drawing.Size(135, 30);
            this.btn1000.StateCommon.Border.Rounding = 15F;
            this.btn1000.TabIndex = 5;
            this.btn1000.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btn1000.Values.Text = "1.000.000";
            // 
            // btn500
            // 
            this.btn500.Location = new System.Drawing.Point(275, 80);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(115, 30);
            this.btn500.StateCommon.Border.Rounding = 15F;
            this.btn500.TabIndex = 4;
            this.btn500.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btn500.Values.Text = "500.000";
            // 
            // btn200
            // 
            this.btn200.Location = new System.Drawing.Point(150, 80);
            this.btn200.Name = "btn200";
            this.btn200.Size = new System.Drawing.Size(115, 30);
            this.btn200.StateCommon.Border.Rounding = 15F;
            this.btn200.TabIndex = 3;
            this.btn200.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btn200.Values.Text = "200.000";
            // 
            // btn100
            // 
            this.btn100.Location = new System.Drawing.Point(25, 80);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(115, 30);
            this.btn100.StateCommon.Border.Rounding = 15F;
            this.btn100.TabIndex = 2;
            this.btn100.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btn100.Values.Text = "100.000";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(193, 35);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(342, 27);
            this.txtSoTien.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11F);
            this.label7.Location = new System.Drawing.Point(18, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Số tiền cần chuyển";
            // 
            // pnlRight1
            // 
            this.pnlRight1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.pnlRight1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight1.Controls.Add(this.txtSoDu);
            this.pnlRight1.Controls.Add(this.label3);
            this.pnlRight1.Location = new System.Drawing.Point(650, 85);
            this.pnlRight1.Name = "pnlRight1";
            this.pnlRight1.Size = new System.Drawing.Size(280, 245);
            this.pnlRight1.TabIndex = 5;
            // 
            // txtSoDu
            // 
            this.txtSoDu.AutoSize = true;
            this.txtSoDu.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSoDu.ForeColor = System.Drawing.Color.Black;
            this.txtSoDu.Location = new System.Drawing.Point(15, 55);
            this.txtSoDu.Name = "txtSoDu";
            this.txtSoDu.Size = new System.Drawing.Size(89, 23);
            this.txtSoDu.TabIndex = 1;
            this.txtSoDu.Text = "??? VND";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số dư:";
            // 
            // pnlRight2
            // 
            this.pnlRight2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.pnlRight2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight2.Location = new System.Drawing.Point(650, 357);
            this.pnlRight2.Name = "pnlRight2";
            this.pnlRight2.Size = new System.Drawing.Size(280, 295);
            this.pnlRight2.TabIndex = 6;
            // 
            // ucTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pnlRight2);
            this.Controls.Add(this.pnlRight1);
            this.Controls.Add(this.pnlAmount);
            this.Controls.Add(this.pnlFlow);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucTransfer";
            this.Size = new System.Drawing.Size(970, 673);
            this.pnlTabs.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlFlow.ResumeLayout(false);
            this.pnlFlow.PerformLayout();
            this.pnlAmount.ResumeLayout(false);
            this.pnlAmount.PerformLayout();
            this.pnlRight1.ResumeLayout(false);
            this.pnlRight1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTabs;
        private Krypton.Toolkit.KryptonButton btnTransferInternal;
        private Krypton.Toolkit.KryptonButton btnTransferInterbank;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label label1;
        private Krypton.Toolkit.KryptonTextBox txtIDNguoiNhan;
        private Krypton.Toolkit.KryptonButton btnTim;
        private System.Windows.Forms.Panel pnlFlow;
        private System.Windows.Forms.Label txtIDUser;
        private System.Windows.Forms.Label txtTenUser;
        private System.Windows.Forms.Label lblArrow;
        private System.Windows.Forms.Label txtIDNguoiNhan1;
        private System.Windows.Forms.Label txtTenNguoiNhan;
        private System.Windows.Forms.Panel pnlAmount;
        private System.Windows.Forms.Label label7;
        private Krypton.Toolkit.KryptonTextBox txtSoTien;
        private Krypton.Toolkit.KryptonButton btn100;
        private Krypton.Toolkit.KryptonButton btn200;
        private Krypton.Toolkit.KryptonButton btn500;
        private Krypton.Toolkit.KryptonButton btn1000;
        private System.Windows.Forms.Label label8;
        private Krypton.Toolkit.KryptonRichTextBox txtNDCK;
        private Krypton.Toolkit.KryptonButton btnCK;
        private System.Windows.Forms.Panel pnlRight1;
        private System.Windows.Forms.Panel pnlRight2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtSoDu;
    }
}
