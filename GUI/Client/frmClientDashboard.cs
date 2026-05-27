using System;
using System.Drawing;
using System.Drawing.Drawing2D; 
using System.Windows.Forms;
using GUI.Session;
using GUI.Client.Loan;
namespace GUI.Client
{
    public partial class frmClientDashboard : Form, IMessageFilter
    {

        ucClientHome home;
        ucSaving saving;
        ucHistory history;
        ucInvoicePayment invoice;
        ucPaymentHistory paymentHistory;
        ucBalanceChanges balanceChanges;
        ucNotifications notifications;
        ucTransfer transfer;
        ucConfirmLoan confirmSaving;
        uccreateSaving createSaving;
        ucListSaving listSaving;
        ucLoanDashboard loanDashboard;
        
        public string CurrentUsername { get; private set; }

        
        ucAccountInfo accountinfo;

        public frmClientDashboard()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);

            // Hiển thị Full Name từ database
            string fullName = BLL.Services.AccountService.GetFullNameByCustomerId(UserSession.CurrentUser.CustomerID);
            lblUserName.Text = !string.IsNullOrEmpty(fullName) ? fullName : UserSession.CurrentUser.Username;

            home = new ucClientHome();
            listSaving = new ucListSaving();

            listSaving.NavigateTo = addUserControl;
            listSaving.NavigateTo1 = addUserControl1;

            loanDashboard = new ucLoanDashboard();
            loanDashboard.NavigateTo = addUserControl;
            loanDashboard.NavigateTo1 = addUserControl1;



            // Truyền hàm điều hướng vào ucSaving
            //createSaving = new uccreateSaving();
            //createSaving.NavigateTo = addUserControl;
            //confirmSaving = new ucConfirmSaving();
            invoice = new ucInvoicePayment();
            invoice.NavigateTo = addUserControl;

            accountinfo = new ucAccountInfo();
            accountinfo.NavigateTo = addUserControl;


            history = new ucHistory();
            invoice = new ucInvoicePayment();
            paymentHistory = new ucPaymentHistory();
            balanceChanges = new ucBalanceChanges();
            notifications = new ucNotifications();
            transfer = new ucTransfer();
            
            // Subscribe to balance change events - refresh UI when balance changes
            UserSession.BalanceChanged += () => 
            {
                System.Diagnostics.Debug.WriteLine("[frmClientDashboard] BalanceChanged event - triggering UI refresh");
                if (history != null)
                    history.RefreshData();
                if (balanceChanges != null)
                    balanceChanges.RefreshData();
                if (home != null)
                    home.RefreshData();
                if (paymentHistory != null)
                    paymentHistory.RefreshData();
            };
            
            // Set initial state
            pnlNav.Height = button1.Height;
            pnlNav.Top = button1.Top;
            pnlNav.Left = 0;
            SetActiveButton(button1);

            addUserControl(home);
        }

        private void SetActiveButton(Button btn)
        {
            // 1. Reset ALL buttons in the sidebar to default state (White background, Black/Gray text)
            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Button sidebarBtn)
                {
                    sidebarBtn.BackColor = Color.White;
                    sidebarBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 250, 255); // Subtle hover
                    
                    // Reset text color based on button type
                    if (sidebarBtn.Height == 45) // Main buttons
                        sidebarBtn.ForeColor = Color.Black;
                    else // Sub buttons (dots)
                        sidebarBtn.ForeColor = Color.DimGray;
                }
            }

            // 2. Highlight ONLY the selected button
            // Using a slightly more professional light blue for the background (closer to your theme)
            btn.BackColor = Color.FromArgb(230, 240, 255); 
            btn.ForeColor = Color.DodgerBlue;
            
            // 3. Update the vertical indicator (pnlNav)
            pnlNav.Height = btn.Height;
            pnlNav.Top = btn.Top;
            pnlNav.BackColor = Color.DodgerBlue;
            pnlNav.Visible = true;
            pnlNav.BringToFront();
        }

        // Hàm tráo đổi UserControl của bạn (Đã chuẩn)
        public void addUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }
        public void addUserControl1(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
          
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }


        // Khai báo Panel Dropdown cho thông báo (Vẫn giữ ở đây vì nó là động)
        private Panel pnlNotificationDropdown; 

        private void SetupNotificationIcon()
        {
            // Thiết lập Bo tròn Badge (Vì designer không hỗ trợ bo tròn label)
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, lblNotificationBadge.Width, lblNotificationBadge.Height);
            lblNotificationBadge.Region = new Region(path);

            SetupNotificationDropdown();
            UpdateNotificationBadge();
        }

        private void SetupNotificationDropdown()
        {
            pnlNotificationDropdown = new Panel();
            pnlNotificationDropdown.Size = new Size(350, 400); // Kích thước dropdown theo ảnh mockup
            pnlNotificationDropdown.BackColor = Color.White;
            pnlNotificationDropdown.BorderStyle = BorderStyle.FixedSingle;
            pnlNotificationDropdown.Visible = false; // Mặc định ẩn
            pnlNotificationDropdown.AutoScroll = false; // Tắt AutoScroll ở Panel cha
            
            // Xử lý góc bo tròn hoặc shadow nếu cần (để đơn giản ta dùng viền cơ bản)

            // Thêm Dropdown vào pnlMain thay vì Controls của Form để dễ quản lý Z-Order
            // Hoặc thêm trực tiếp vào Controls của frmClientDashboard để nổi trên mọi thứ
            this.Controls.Add(pnlNotificationDropdown);
            pnlNotificationDropdown.BringToFront();
            
            // Vì pnlHeader có height 62, panel4 có width 300.
            // Chọn location phù hợp dựa vao vi trí của btnNotification
            pnlNotificationDropdown.Location = new Point(this.Width - pnlNotificationDropdown.Width - 20, 62); 
        }

        private void BtnNotification_Click(object sender, EventArgs e)
        {
            // Toggle hiển thị dropdown
            if (pnlNotificationDropdown.Visible)
            {
                pnlNotificationDropdown.Visible = false;
            }
            else
            {
                LoadNotificationsToDropdown();
                pnlNotificationDropdown.Visible = true;
                pnlNotificationDropdown.BringToFront();

                // Đánh dấu đã đọc
                BLL.Services.NotificationService.MarkAllAsRead(UserSession.CurrentUser.Username);
                UpdateNotificationBadge(); // Ẩn badge
            }
        }

        private void LoadNotificationsToDropdown()
        {
            pnlNotificationDropdown.Controls.Clear();
            pnlNotificationDropdown.AutoScroll = false;

            // 1. Tiêu đề (Cố định trên cùng)
            Panel pnlTop = new Panel();
            pnlTop.Size = new Size(pnlNotificationDropdown.Width, 40);
            pnlTop.Location = new Point(0, 0);
            pnlTop.BackColor = Color.White;

            Label lblTitle = new Label();
            lblTitle.Text = "Thông báo";
            lblTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 10);
            lblTitle.AutoSize = true;
            pnlTop.Controls.Add(lblTitle);
            pnlNotificationDropdown.Controls.Add(pnlTop);

            // 2. Nút Xem tất cả (Cố định dưới cùng)
            Button btnViewAll = new Button();
            btnViewAll.Text = "Xem tất cả";
            btnViewAll.Size = new Size(pnlNotificationDropdown.Width, 40);
            btnViewAll.Location = new Point(0, pnlNotificationDropdown.Height - 40);
            btnViewAll.FlatStyle = FlatStyle.Flat;
            btnViewAll.FlatAppearance.BorderSize = 0;
            btnViewAll.ForeColor = Color.Red;
            btnViewAll.BackColor = Color.White;
            btnViewAll.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnViewAll.Cursor = Cursors.Hand;
            btnViewAll.Click += (s, e) => {
                pnlNotificationDropdown.Visible = false;
                btnNotifications_Click(null, null); // Chuyển hướng sang màn hình Thông báo
            };
            pnlNotificationDropdown.Controls.Add(btnViewAll);

            // 3. Vùng chứa danh sách thông báo (Cuộn được)
            Panel pnlScroll = new Panel();
            pnlScroll.Size = new Size(pnlNotificationDropdown.Width, pnlNotificationDropdown.Height - 80);
            pnlScroll.Location = new Point(0, 40);
            pnlScroll.AutoScroll = true;
            pnlScroll.BackColor = Color.White;
            pnlNotificationDropdown.Controls.Add(pnlScroll);

            // Fetch notifications
            var notifications = BLL.Services.NotificationService.GetRecentNotifications(UserSession.CurrentUser.Username);
            
            if (notifications.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Không có thông báo nào.";
                lblEmpty.Font = new Font("Arial", 10F);
                lblEmpty.Location = new Point(10, 10);
                lblEmpty.AutoSize = true;
                pnlScroll.Controls.Add(lblEmpty);
                return;
            }

            int yPos = 0; // Bắt đầu từ 0 bên trong pnlScroll
            foreach (var noti in notifications)
            {
                Panel pnlItem = new Panel();
                pnlItem.Size = new Size(pnlNotificationDropdown.Width - 25, 70);
                pnlItem.Location = new Point(10, yPos);
                pnlItem.BackColor = noti.IsRead ? Color.White : Color.AliceBlue; // Nổi bật thông báo chưa đọc

                string displayType = noti.Type;
                if (displayType.ToLower().Contains("transaction")) displayType = "Giao dịch";
                else if (displayType.ToLower().Contains("deposit")) displayType = "Nạp tiền";
                else if (displayType.ToLower().Contains("withdraw")) displayType = "Rút tiền";
                else if (displayType.ToLower().Contains("saving")) displayType = "Tiết kiệm";
                
                Label lblType = new Label();
                lblType.Text = displayType;
                lblType.Font = new Font("Arial", 10F, FontStyle.Bold);
                lblType.Location = new Point(50, 5);
                lblType.AutoSize = true;
                pnlItem.Controls.Add(lblType);

                Label lblMessage = new Label();
                lblMessage.Text = noti.Message;
                lblMessage.Font = new Font("Arial", 9F);
                lblMessage.Location = new Point(50, 25);
                lblMessage.Size = new Size(270, 40);
                pnlItem.Controls.Add(lblMessage);

                Label lblTime = new Label();
                lblTime.Text = GetTimeAgo(noti.CreatedAt);
                lblTime.Font = new Font("Arial", 8F, FontStyle.Italic);
                lblTime.ForeColor = Color.Gray;
                lblTime.Location = new Point(pnlItem.Width - 100, 5);
                lblTime.Size = new Size(95, 15);
                lblTime.TextAlign = ContentAlignment.TopRight;
                pnlItem.Controls.Add(lblTime);

                PictureBox picIcon = new PictureBox();
                picIcon.Size = new Size(30, 30);
                picIcon.Location = new Point(10, 15);
                picIcon.SizeMode = PictureBoxSizeMode.Zoom;
                
                Label lblIcon = new Label();
                lblIcon.Font = new Font("Segoe UI Emoji", 14F);
                lblIcon.Size = new Size(30, 30);
                lblIcon.Location = new Point(10, 15);
                lblIcon.Text = GetIconForType(noti.Type);
                pnlItem.Controls.Add(lblIcon);

                pnlScroll.Controls.Add(pnlItem);
                yPos += 75;
            }
        }

        private string GetTimeAgo(DateTime dt)
        {
            TimeSpan ts = DateTime.Now - dt;
            if (ts.TotalMinutes < 60) return $"{(int)ts.TotalMinutes} phút trước";
            if (ts.TotalHours < 24) return $"{(int)ts.TotalHours} giờ trước";
            return $"{(int)ts.TotalDays} ngày trước";
        }

        private string GetIconForType(string type)
        {
            if (type.Contains("Saving")) return "📅"; // Calendar/Savings icon
            if (type.Contains("Withdraw")) return "✅"; // Checkout icon
            if (type.Contains("Deposit")) return "💰"; // Deposit icon
            return "🔔"; // Default
        }

        private void UpdateNotificationBadge()
        {
            try
            {
                int count = BLL.Services.NotificationService.GetUnreadCount(UserSession.CurrentUser.Username);
                if (count > 0)
                {
                    lblNotificationBadge.Text = count > 99 ? "99+" : count.ToString();
                    lblNotificationBadge.Visible = true;
                }
                else
                {
                    lblNotificationBadge.Visible = false;
                }
            }
            catch
            {
                lblNotificationBadge.Visible = false;
            }
        }

        private void HideHistorySubMenu()
        {
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            // Dịch btnNotifications lên ngay dưới Lịch sử
            btnNotifications.Top = button6.Bottom;
            btnAccountInfo.Top = btnNotifications.Bottom;
        }

        // --- CÁC SỰ KIỆN NÚT BẤM ---
        private void btnHome_Click(object sender, EventArgs e)
        {
            // Cập nhật lại số dư trước khi lôi nó ra hiển thị
            home.ReloadBalance();

            // Đưa ucClientHome ra màn hình chính
            HideHistorySubMenu();
            lblPageTitle.Text = "Trang chủ";
            SetActiveButton(button1);
            addUserControl(home);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.RemoveMessageFilter(this);
            base.OnFormClosed(e);
        }

        public bool PreFilterMessage(ref Message m)
        {
            const int WM_LBUTTONDOWN = 0x0201;
            const int WM_RBUTTONDOWN = 0x0204;
            const int WM_MBUTTONDOWN = 0x0207;

            if (m.Msg == WM_LBUTTONDOWN || m.Msg == WM_RBUTTONDOWN || m.Msg == WM_MBUTTONDOWN)
            {
                if (pnlNotificationDropdown != null && pnlNotificationDropdown.Visible)
                {
                    // Lấy vị trí chuột trên màn hình
                    Point mousePos = Control.MousePosition;

                    // Kiểm tra xem chuột có nằm trong Dropdown hay Nút chuông không
                    bool isInsideDropdown = pnlNotificationDropdown.ClientRectangle.Contains(pnlNotificationDropdown.PointToClient(mousePos));
                    bool isInsideBtn = false;
                    if (btnNotification != null)
                    {
                        isInsideBtn = btnNotification.ClientRectangle.Contains(btnNotification.PointToClient(mousePos));
                    }

                    if (!isInsideDropdown && !isInsideBtn)
                    {
                        pnlNotificationDropdown.Visible = false;
                    }
                }
            }
            return false;
        }

        private void btnSaving_Click(object sender, EventArgs e)
        {
            HideHistorySubMenu();
            lblPageTitle.Text = "Tiết kiệm";
            SetActiveButton(btnSaving);
            addUserControl(listSaving);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            // Toggle hiện/ẩn sub-menu, KHÔNG tự load giao diện
            bool isExpanded = button7.Visible;
            button7.Visible = !isExpanded;
            button8.Visible = !isExpanded;
            button9.Visible = !isExpanded;

            // Dịch btnNotifications theo trạng thái sub-menu
            if (!isExpanded)
            {
                // Sub-menu vừa mở → đẩy Thông báo xuống dưới button9
                btnNotifications.Top = button9.Bottom;
            }
            else
            {
                // Sub-menu vừa đóng → kéo Thông báo lên ngay dưới Lịch sử
                btnNotifications.Top = button6.Bottom;
            }
            
            // Dịch btnAccountInfo theo btnNotifications
            btnAccountInfo.Top = btnNotifications.Bottom;

            // Chỉ highlight nút, không thay đổi nội dung bên phải
            SetActiveButton(button6);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            HideHistorySubMenu();
            lblPageTitle.Text = "Chuyển khoản";
            SetActiveButton(button2);
            addUserControl(transfer);
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            HideHistorySubMenu();
            lblPageTitle.Text = "Thanh toán";
            SetActiveButton(button3);
            invoice.NavigateTo = addUserControl;
            addUserControl(invoice);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void frmClientDashboard_Load(object sender, EventArgs e) 
        { 
            SetupNotificationIcon();

            // Make avatar circular if it exists
            if (picAvatar != null)
            {
                GraphicsPath pAvt = new GraphicsPath();
                pAvt.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height);
                picAvatar.Region = new Region(pAvt);
            }

            // Make notification button circular
            if (btnNotification != null)
            {
                GraphicsPath pBtn = new GraphicsPath();
                pBtn.AddEllipse(0, 0, btnNotification.Width, btnNotification.Height);
                btnNotification.Region = new Region(pBtn);
            }
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;

            // ✅ Subscribe vào event từ UserSession
            UserSession.OnNotification += UserSession_OnNotification;
        }

        // ✅ Handler khi có notification event
        private void UserSession_OnNotification(string message, string type)
        {
            // Đảm bảo chạy trên UI thread
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UserSession_OnNotification(message, type)));
                return;
            }

            try
            {
                // Luôn cập nhật badge trước
                UpdateNotificationBadge();

                // Load lại danh sách notification từ DB (đã được lưu trước đó)
                LoadNotificationsToDropdown();

                // Hiển thị panel notification
                pnlNotificationDropdown.Visible = true;
                pnlNotificationDropdown.BringToFront();

                System.Diagnostics.Debug.WriteLine($"[Dashboard] Notification panel refreshed: {message}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in UserSession_OnNotification: " + ex.Message);
            }
        }

        // ✅ Refresh notifications (gọi khi cần)
        private void RefreshNotifications()
        {
            try
            {
                UpdateNotificationBadge();
                LoadNotificationsToDropdown();
                pnlNotificationDropdown.Visible = true;
                pnlNotificationDropdown.BringToFront();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error refreshing notifications: " + ex.Message);
            }
        }

        public void ShowPaymentScreen()
        {
            addUserControl(invoice);
        }

        public void ShowHistoryScreen()
        {
            addUserControl(history);
        }

        // ✅ New public methods for navigation from UserControls
        public void NavigateToTransactionHistory()
        {
            lblPageTitle.Text = "Lịch sử giao dịch";
            addUserControl(history);
        }

        public void NavigateToPaymentHistory()
        {
            lblPageTitle.Text = "Lịch sử thanh toán";
            addUserControl(paymentHistory);
        }

        public void RefreshDashboardBalance()
        {
            // Kích hoạt hàm làm mới số tiền của trang Home đang nằm ẩn bên dưới
            if (home != null)
            {
                home.ReloadBalance();
            }
        }

        private void pnlLogo_Paint(object sender, PaintEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void pnlMain_Paint(object sender, PaintEventArgs e) { }
        private void pnlSidebar_Paint(object sender, PaintEventArgs e) { }

        // Code bo góc thanh tìm kiếm của bạn (Đã chuẩn)
        private void pnlSearch_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            addUserControl(loanDashboard);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Lịch sử thanh toán";
            SetActiveButton(button7);
            addUserControl(paymentHistory);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Biến động số dư";
            SetActiveButton(button8);
            addUserControl(balanceChanges);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Lịch sử giao dịch";
            SetActiveButton(button9);
            addUserControl(history);
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            HideHistorySubMenu();
            lblPageTitle.Text = "Thông báo";
            SetActiveButton(btnNotifications);
            notifications.LoadNotifications();
            addUserControl(notifications);
        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            
            int radius = 20; 
            Rectangle rect = new Rectangle(5, 2, panel4.Width - 10, panel4.Height - 6);
            
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            
            using (Pen pen = new Pen(Color.FromArgb(150, 255, 255, 255), 1.5f)) 
            {
                g.DrawPath(pen, path);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            HideHistorySubMenu();
            lblPageTitle.Text = "Thông tin tài khoản";
            SetActiveButton(btnAccountInfo);

            accountinfo = new ucAccountInfo();
            accountinfo.NavigateTo = addUserControl;
            
            pnlMain.Controls.Clear();
            accountinfo.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(accountinfo);
        }
    }
}