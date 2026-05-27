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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnNotifications = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnLoan = new System.Windows.Forms.Button();
            this.btnSaving = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.pnlSubtitles = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSubtitle1 = new System.Windows.Forms.Label();
            this.lblSubtitle2 = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblWelcomeText = new System.Windows.Forms.Label();
            this.lblNotificationBadge = new System.Windows.Forms.Label();
            this.btnNotification = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnAccountInfo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlSubtitles.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.pnlNav);
            this.pnlSidebar.Controls.Add(this.btnNotifications);
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
            this.pnlSidebar.Size = new System.Drawing.Size(280, 853);
            this.pnlSidebar.TabIndex = 0;
            this.pnlSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSidebar_Paint);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlNav.Location = new System.Drawing.Point(0, 193);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(3, 100);
            this.pnlNav.TabIndex = 1;
            // 
            // btnNotifications
            // 
            this.btnNotifications.FlatAppearance.BorderSize = 0;
            this.btnNotifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotifications.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNotifications.ForeColor = System.Drawing.Color.Black;
            this.btnNotifications.Location = new System.Drawing.Point(0, 332);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNotifications.Size = new System.Drawing.Size(280, 45);
            this.btnNotifications.TabIndex = 12;
            this.btnNotifications.Text = "  🔔   Thông báo";
            this.btnNotifications.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNotifications.UseVisualStyleBackColor = true;
            this.btnNotifications.Click += new System.EventHandler(this.btnNotifications_Click);
            // 
            // button9
            // 
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button9.ForeColor = System.Drawing.Color.DimGray;
            this.button9.Location = new System.Drawing.Point(0, 402);
            this.button9.Name = "button9";
            this.button9.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.button9.Size = new System.Drawing.Size(280, 35);
            this.button9.TabIndex = 11;
            this.button9.Text = "• Lịch sử giao dịch";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button8.ForeColor = System.Drawing.Color.DimGray;
            this.button8.Location = new System.Drawing.Point(0, 367);
            this.button8.Name = "button8";
            this.button8.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.button8.Size = new System.Drawing.Size(280, 35);
            this.button8.TabIndex = 10;
            this.button8.Text = "• Biến động số dư";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button7.ForeColor = System.Drawing.Color.DimGray;
            this.button7.Location = new System.Drawing.Point(0, 332);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.button7.Size = new System.Drawing.Size(280, 35);
            this.button7.TabIndex = 9;
            this.button7.Text = "• Lịch sử thanh toán";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(0, 287);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(280, 45);
            this.button6.TabIndex = 8;
            this.button6.Text = "  🕒   Lịch sử";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnLoan
            // 
            this.btnLoan.FlatAppearance.BorderSize = 0;
            this.btnLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLoan.ForeColor = System.Drawing.Color.Black;
            this.btnLoan.Location = new System.Drawing.Point(0, 242);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLoan.Size = new System.Drawing.Size(280, 45);
            this.btnLoan.TabIndex = 7;
            this.btnLoan.Text = "  🏦   Khoản vay";
            this.btnLoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoan.UseVisualStyleBackColor = true;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // btnSaving
            // 
            this.btnSaving.FlatAppearance.BorderSize = 0;
            this.btnSaving.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaving.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSaving.ForeColor = System.Drawing.Color.Black;
            this.btnSaving.Location = new System.Drawing.Point(0, 197);
            this.btnSaving.Name = "btnSaving";
            this.btnSaving.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSaving.Size = new System.Drawing.Size(280, 45);
            this.btnSaving.TabIndex = 6;
            this.btnSaving.Text = "  🐷   Tiết kiệm";
            this.btnSaving.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaving.UseVisualStyleBackColor = true;
            this.btnSaving.Click += new System.EventHandler(this.btnSaving_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(0, 152);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(280, 45);
            this.button3.TabIndex = 5;
            this.button3.Text = "  💳   Thanh toán";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(0, 107);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(280, 45);
            this.button2.TabIndex = 4;
            this.button2.Text = "  💸   Chuyển Khoản";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackgroundImage = global::GUI.Properties.Resources._647600484_930136546239914_1486468665117018077_n;
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlLogo.Location = new System.Drawing.Point(12, 3);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(222, 59);
            this.pnlLogo.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(0, 62);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(280, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "  🏠   Trang chủ";
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
            this.pnlHeader.Location = new System.Drawing.Point(280, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1500, 62);
            this.pnlHeader.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.lblPageTitle);
            this.panel1.Controls.Add(this.pnlSeparator);
            this.panel1.Controls.Add(this.pnlSubtitles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 62);
            this.panel1.TabIndex = 0;
            this.panel1.WrapContents = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 11.07692F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.Location = new System.Drawing.Point(10, 10);
            this.lblPageTitle.Margin = new System.Windows.Forms.Padding(10, 10, 5, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(105, 28);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Trang chủ";
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.White;
            this.pnlSeparator.Location = new System.Drawing.Point(120, 10);
            this.pnlSeparator.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(2, 28);
            this.pnlSeparator.TabIndex = 1;
            // 
            // pnlSubtitles
            // 
            this.pnlSubtitles.AutoSize = true;
            this.pnlSubtitles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSubtitles.Controls.Add(this.lblSubtitle1);
            this.pnlSubtitles.Controls.Add(this.lblSubtitle2);
            this.pnlSubtitles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlSubtitles.Location = new System.Drawing.Point(135, 0);
            this.pnlSubtitles.Margin = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.pnlSubtitles.Name = "pnlSubtitles";
            this.pnlSubtitles.Size = new System.Drawing.Size(368, 48);
            this.pnlSubtitles.TabIndex = 2;
            this.pnlSubtitles.WrapContents = false;
            // 
            // lblSubtitle1
            // 
            this.lblSubtitle1.AutoSize = true;
            this.lblSubtitle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle1.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle1.Location = new System.Drawing.Point(0, 0);
            this.lblSubtitle1.Margin = new System.Windows.Forms.Padding(0);
            this.lblSubtitle1.Name = "lblSubtitle1";
            this.lblSubtitle1.Size = new System.Drawing.Size(173, 25);
            this.lblSubtitle1.TabIndex = 0;
            this.lblSubtitle1.Text = "More than banking";
            // 
            // lblSubtitle2
            // 
            this.lblSubtitle2.AutoSize = true;
            this.lblSubtitle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle2.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle2.Location = new System.Drawing.Point(0, 25);
            this.lblSubtitle2.Margin = new System.Windows.Forms.Padding(0);
            this.lblSubtitle2.Name = "lblSubtitle2";
            this.lblSubtitle2.Size = new System.Drawing.Size(368, 23);
            this.lblSubtitle2.TabIndex = 1;
            this.lblSubtitle2.Text = "A smarter way to manage your financial future.";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlSearch.Location = new System.Drawing.Point(549, 3);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.pnlSearch.Size = new System.Drawing.Size(153, 51);
            this.pnlSearch.TabIndex = 1;
            this.pnlSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSearch_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.picAvatar);
            this.panel4.Controls.Add(this.lblWelcomeText);
            this.panel4.Controls.Add(this.lblNotificationBadge);
            this.panel4.Controls.Add(this.btnNotification);
            this.panel4.Controls.Add(this.lblUserName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1156, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(350, 62);
            this.panel4.TabIndex = 3;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint_1);
            // 
            // picAvatar
            // 
            this.picAvatar.Image = global::GUI.Properties.Resources.pngtree_user_icon_png_image_1796659;
            this.picAvatar.Location = new System.Drawing.Point(295, 11);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(40, 40);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 9;
            this.picAvatar.TabStop = false;
            // 
            // lblWelcomeText
            // 
            this.lblWelcomeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeText.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeText.Location = new System.Drawing.Point(55, 10);
            this.lblWelcomeText.Name = "lblWelcomeText";
            this.lblWelcomeText.Size = new System.Drawing.Size(235, 20);
            this.lblWelcomeText.TabIndex = 8;
            this.lblWelcomeText.Text = "Welcome";
            this.lblWelcomeText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNotificationBadge
            // 
            this.lblNotificationBadge.BackColor = System.Drawing.Color.Red;
            this.lblNotificationBadge.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblNotificationBadge.ForeColor = System.Drawing.Color.White;
            this.lblNotificationBadge.Location = new System.Drawing.Point(32, 5);
            this.lblNotificationBadge.Name = "lblNotificationBadge";
            this.lblNotificationBadge.Size = new System.Drawing.Size(20, 20);
            this.lblNotificationBadge.TabIndex = 3;
            this.lblNotificationBadge.Text = "0";
            this.lblNotificationBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNotificationBadge.Visible = false;
            // 
            // btnNotification
            // 
            this.btnNotification.BackColor = System.Drawing.Color.White;
            this.btnNotification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotification.FlatAppearance.BorderSize = 0;
            this.btnNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotification.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.btnNotification.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnNotification.Location = new System.Drawing.Point(12, 10);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(40, 40);
            this.btnNotification.TabIndex = 2;
            this.btnNotification.Text = "🔔";
            this.btnNotification.UseVisualStyleBackColor = false;
            this.btnNotification.Click += new System.EventHandler(this.BtnNotification_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(55, 30);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(235, 25);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "User Name";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(280, 62);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1500, 791);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnAccountInfo
            // 
            this.btnAccountInfo.FlatAppearance.BorderSize = 0;
            this.btnAccountInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAccountInfo.ForeColor = System.Drawing.Color.Black;
            this.btnAccountInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountInfo.Location = new System.Drawing.Point(0, 377);
            this.btnAccountInfo.Name = "btnAccountInfo";
            this.btnAccountInfo.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAccountInfo.Size = new System.Drawing.Size(280, 45);
            this.btnAccountInfo.TabIndex = 9;
            this.btnAccountInfo.Text = "  👤   Thông tin tài khoản";
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
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSubtitles.ResumeLayout(false);
            this.pnlSubtitles.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel panel1;
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
        private System.Windows.Forms.Button btnNotification;
        private System.Windows.Forms.Label lblNotificationBadge;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.FlowLayoutPanel pnlSubtitles;
        private System.Windows.Forms.Label lblSubtitle1;
        private System.Windows.Forms.Label lblSubtitle2;
        private System.Windows.Forms.Label lblWelcomeText;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnAccountInfo;
    }
}