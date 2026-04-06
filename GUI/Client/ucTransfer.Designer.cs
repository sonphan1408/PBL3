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
        /// the contents of this method by the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDNguoiNhan = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCK = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNDCK = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn500 = new System.Windows.Forms.Button();
            this.btn200 = new System.Windows.Forms.Button();
            this.btn100 = new System.Windows.Forms.Button();
            this.btn1000 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.txtTenNguoiNhan = new System.Windows.Forms.Label();
            this.txtIDNguoiNhan1 = new System.Windows.Forms.Label();
            this.txtTenUser = new System.Windows.Forms.Label();
            this.txtIDUser = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoDu = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(45, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(255, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Chuyển Khoản";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tài Khoản Người Nhận";
            // 
            // txtIDNguoiNhan
            // 
            this.txtIDNguoiNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDNguoiNhan.Location = new System.Drawing.Point(17, 57);
            this.txtIDNguoiNhan.Name = "txtIDNguoiNhan";
            this.txtIDNguoiNhan.Size = new System.Drawing.Size(512, 27);
            this.txtIDNguoiNhan.TabIndex = 4;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(548, 61);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 5;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtIDNguoiNhan);
            this.panel1.Controls.Add(this.btnTim);
            this.panel1.Location = new System.Drawing.Point(52, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 107);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnCK);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.txtNDCK);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btn500);
            this.panel2.Controls.Add(this.btn200);
            this.panel2.Controls.Add(this.btn100);
            this.panel2.Controls.Add(this.btn1000);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtSoTien);
            this.panel2.Controls.Add(this.txtTenNguoiNhan);
            this.panel2.Controls.Add(this.txtIDNguoiNhan1);
            this.panel2.Controls.Add(this.txtTenUser);
            this.panel2.Controls.Add(this.txtIDUser);
            this.panel2.Location = new System.Drawing.Point(52, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 416);
            this.panel2.TabIndex = 9;
            // 
            // btnCK
            // 
            this.btnCK.Location = new System.Drawing.Point(277, 368);
            this.btnCK.Name = "btnCK";
            this.btnCK.Size = new System.Drawing.Size(100, 35);
            this.btnCK.TabIndex = 17;
            this.btnCK.Text = "Xác Nhận";
            this.btnCK.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::GUI.Properties.Resources.bro;
            this.pictureBox1.Location = new System.Drawing.Point(277, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // txtNDCK
            // 
            this.txtNDCK.Location = new System.Drawing.Point(37, 282);
            this.txtNDCK.Name = "txtNDCK";
            this.txtNDCK.Size = new System.Drawing.Size(586, 67);
            this.txtNDCK.TabIndex = 14;
            this.txtNDCK.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 22);
            this.label8.TabIndex = 13;
            this.label8.Text = "Nội dung";
            // 
            // btn500
            // 
            this.btn500.Location = new System.Drawing.Point(380, 195);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(106, 23);
            this.btn500.TabIndex = 12;
            this.btn500.Text = "500.000";
            this.btn500.UseVisualStyleBackColor = true;
            // 
            // btn200
            // 
            this.btn200.Location = new System.Drawing.Point(247, 195);
            this.btn200.Name = "btn200";
            this.btn200.Size = new System.Drawing.Size(106, 23);
            this.btn200.TabIndex = 11;
            this.btn200.Text = "200.000";
            this.btn200.UseVisualStyleBackColor = true;
            // 
            // btn100
            // 
            this.btn100.Location = new System.Drawing.Point(111, 195);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(106, 23);
            this.btn100.TabIndex = 10;
            this.btn100.Text = "100.000";
            this.btn100.UseVisualStyleBackColor = true;
            // 
            // btn1000
            // 
            this.btn1000.Location = new System.Drawing.Point(517, 195);
            this.btn1000.Name = "btn1000";
            this.btn1000.Size = new System.Drawing.Size(106, 23);
            this.btn1000.TabIndex = 9;
            this.btn1000.Text = "1.000.000";
            this.btn1000.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 22);
            this.label7.TabIndex = 6;
            this.label7.Text = "Số Tiền";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTien.Location = new System.Drawing.Point(112, 138);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(511, 30);
            this.txtSoTien.TabIndex = 5;
            // 
            // txtTenNguoiNhan
            // 
            this.txtTenNguoiNhan.AutoSize = true;
            this.txtTenNguoiNhan.Location = new System.Drawing.Point(425, 76);
            this.txtTenNguoiNhan.Name = "txtTenNguoiNhan";
            this.txtTenNguoiNhan.Size = new System.Drawing.Size(91, 16);
            this.txtTenNguoiNhan.TabIndex = 3;
            this.txtTenNguoiNhan.Text = "????????????";
            // 
            // txtIDNguoiNhan1
            // 
            this.txtIDNguoiNhan1.AutoSize = true;
            this.txtIDNguoiNhan1.Location = new System.Drawing.Point(425, 22);
            this.txtIDNguoiNhan1.Name = "txtIDNguoiNhan1";
            this.txtIDNguoiNhan1.Size = new System.Drawing.Size(91, 16);
            this.txtIDNguoiNhan1.TabIndex = 2;
            this.txtIDNguoiNhan1.Text = "????????????";
            // 
            // txtTenUser
            // 
            this.txtTenUser.AutoSize = true;
            this.txtTenUser.Location = new System.Drawing.Point(135, 76);
            this.txtTenUser.Name = "txtTenUser";
            this.txtTenUser.Size = new System.Drawing.Size(91, 16);
            this.txtTenUser.TabIndex = 1;
            this.txtTenUser.Text = "????????????";
            // 
            // txtIDUser
            // 
            this.txtIDUser.AutoSize = true;
            this.txtIDUser.Location = new System.Drawing.Point(135, 22);
            this.txtIDUser.Name = "txtIDUser";
            this.txtIDUser.Size = new System.Drawing.Size(91, 16);
            this.txtIDUser.TabIndex = 0;
            this.txtIDUser.Text = "????????????";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txtSoDu);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(729, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(253, 529);
            this.panel3.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số dư:";
            // 
            // txtSoDu
            // 
            this.txtSoDu.AutoSize = true;
            this.txtSoDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDu.Location = new System.Drawing.Point(18, 61);
            this.txtSoDu.Name = "txtSoDu";
            this.txtSoDu.Size = new System.Drawing.Size(105, 29);
            this.txtSoDu.TabIndex = 1;
            this.txtSoDu.Text = "??? VND";
            // 
            // ucTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucTransfer";
            this.Size = new System.Drawing.Size(1020, 626);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDNguoiNhan;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtTenNguoiNhan;
        private System.Windows.Forms.Label txtIDNguoiNhan1;
        private System.Windows.Forms.Label txtTenUser;
        private System.Windows.Forms.Label txtIDUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Button btn500;
        private System.Windows.Forms.Button btn200;
        private System.Windows.Forms.Button btn100;
        private System.Windows.Forms.Button btn1000;
        private System.Windows.Forms.RichTextBox txtNDCK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtSoDu;
    }
}
