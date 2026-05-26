namespace GUI.Client
{
    partial class frmClientDashboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientDashboard));
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnLoan = new System.Windows.Forms.Button();
            this.btnSaving = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnAccountInfo = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.btnAccountInfo);
            this.pnlSidebar.Controls.Add(this.button9);
            this.pnlSidebar.Controls.Add(this.button8);
            this.pnlSidebar.Controls.Add(this.button7);
            this.pnlSidebar.Controls.Add(this.button6);
            this.pnlSidebar.Controls.Add(this.btnLoan);
            this.pnlSidebar.Controls.Add(this.btnSaving);
            this.pnlSidebar.Controls.Add(this.button3);
            this.pnlSidebar.Controls.Add(this.button2);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Controls.Add(this.button1);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(219, 853);
            this.pnlSidebar.TabIndex = 0;
            this.pnlSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSidebar_Paint);
            // 
            // button9
            // 
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.Color.DimGray;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(0, 349);
            this.button9.Name = "button9";
            this.button9.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button9.Size = new System.Drawing.Size(188, 32);
            this.button9.TabIndex = 11;
            this.button9.Text = "- Transaction History";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.DimGray;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(0, 317);
            this.button8.Name = "button8";
            this.button8.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button8.Size = new System.Drawing.Size(188, 32);
            this.button8.TabIndex = 10;
            this.button8.Text = "- Balance Changes";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.DimGray;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(0, 285);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button7.Size = new System.Drawing.Size(188, 32);
            this.button7.TabIndex = 9;
            this.button7.Text = "- Payment History";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(0, 253);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(188, 32);
            this.button6.TabIndex = 8;
            this.button6.Text = "History";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnLoan
            // 
            this.btnLoan.FlatAppearance.BorderSize = 0;
            this.btnLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoan.ForeColor = System.Drawing.Color.Black;
            this.btnLoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoan.Location = new System.Drawing.Point(0, 215);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLoan.Size = new System.Drawing.Size(167, 32);
            this.btnLoan.TabIndex = 7;
            this.btnLoan.Text = "Loan";
            this.btnLoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoan.UseVisualStyleBackColor = true;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // btnSaving
            // 
            this.btnSaving.FlatAppearance.BorderSize = 0;
            this.btnSaving.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaving.ForeColor = System.Drawing.Color.Black;
            this.btnSaving.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaving.Location = new System.Drawing.Point(0, 177);
            this.btnSaving.Name = "btnSaving";
            this.btnSaving.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnSaving.Size = new System.Drawing.Size(188, 32);
            this.btnSaving.TabIndex = 6;
            this.btnSaving.Text = "Saving";
            this.btnSaving.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaving.UseVisualStyleBackColor = true;
            this.btnSaving.Click += new System.EventHandler(this.btnSaving_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 139);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(188, 32);
            this.button3.TabIndex = 5;
            this.button3.Text = "Payments";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 101);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(188, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "Chuyển Khoản";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.White;
            this.pnlLogo.Controls.Add(this.pictureBox1);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(219, 62);
            this.pnlLogo.TabIndex = 0;
            this.pnlLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLogo_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 63);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(188, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Dashboard\r\n";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlHeader.Controls.Add(this.panel1);
            this.pnlHeader.Controls.Add(this.pnlSearch);
            this.pnlHeader.Controls.Add(this.panel4);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(219, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1561, 62);
            this.pnlHeader.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPageTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 51);
            this.panel1.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Location = new System.Drawing.Point(19, 19);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(45, 16);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Home";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlSearch.Location = new System.Drawing.Point(258, 3);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.pnlSearch.Size = new System.Drawing.Size(436, 51);
            this.pnlSearch.TabIndex = 1;
            this.pnlSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSearch_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblUserName);
            this.panel4.Location = new System.Drawing.Point(700, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 51);
            this.panel4.TabIndex = 3;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(80, 16);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(110, 22);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "User Name";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(219, 62);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1561, 791);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // btnAccountInfo
            // 
            this.btnAccountInfo.FlatAppearance.BorderSize = 0;
            this.btnAccountInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountInfo.ForeColor = System.Drawing.Color.Black;
            this.btnAccountInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountInfo.Location = new System.Drawing.Point(0, 291);
            this.btnAccountInfo.Name = "btnAccountInfo";
            this.btnAccountInfo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAccountInfo.Size = new System.Drawing.Size(167, 32);
            this.btnAccountInfo.TabIndex = 9;
            this.btnAccountInfo.Text = "Thông tin tài khoản";
            this.btnAccountInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountInfo.UseVisualStyleBackColor = true;
            this.btnAccountInfo.Click += new System.EventHandler(this.btnAccountInfo_Click);
            // 
            // frmClientDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1780, 853);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmClientDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giao diện chính";
            this.Load += new System.EventHandler(this.frmClientDashboard_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.FlowLayoutPanel pnlHeader;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSaving;
        private System.Windows.Forms.Button btnLoan;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnAccountInfo;
    }
}