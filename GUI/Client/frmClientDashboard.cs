using System;
using System.Drawing;
using System.Drawing.Drawing2D; 
using System.Windows.Forms;
using GUI.Session;
using GUI.Client.Loan;
namespace GUI.Client
{
    public partial class frmClientDashboard : Form
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

        
        public frmClientDashboard()
        {
            InitializeComponent();

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
            
            addUserControl(home);
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


        // Khai báo các biến cho Icon thông báo
        private Button btnNotification;
        private Label lblNotificationBadge;
        private Panel pnlNotificationDropdown; // Panel Dropdown cho thông báo

        private void SetupNotificationIcon()
        {
            // Thiết lập Nút thông báo
            btnNotification = new Button();
            btnNotification.Text = "🔔"; // Icon chuông bằng Unicode
            btnNotification.Font = new Font("Segoe UI Emoji", 16F);
            btnNotification.Size = new Size(40, 40);
            btnNotification.Location = new Point(10, 5); // Đặt bên trái panel4
            btnNotification.FlatStyle = FlatStyle.Flat;
            btnNotification.FlatAppearance.BorderSize = 0;
            btnNotification.BackColor = Color.Transparent;
            btnNotification.ForeColor = Color.White;
            btnNotification.Cursor = Cursors.Hand;
            btnNotification.Click += BtnNotification_Click;

            
            lblNotificationBadge = new Label();
            lblNotificationBadge.AutoSize = false;
            lblNotificationBadge.Size = new Size(20, 20);
            lblNotificationBadge.Location = new Point(32, 5);
            lblNotificationBadge.BackColor = Color.Red;
            lblNotificationBadge.ForeColor = Color.White;
            lblNotificationBadge.Font = new Font("Arial", 8F, FontStyle.Bold);
            lblNotificationBadge.TextAlign = ContentAlignment.MiddleCenter;

            // Bo tròn Badge
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, lblNotificationBadge.Width, lblNotificationBadge.Height);
            lblNotificationBadge.Region = new Region(path);

            // Thêm vào panel4
            panel4.Controls.Add(lblNotificationBadge);
            panel4.Controls.Add(btnNotification);
            lblNotificationBadge.BringToFront();

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

            Label lblTitle = new Label();
            lblTitle.Text = "Notifications";
            lblTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 10);
            lblTitle.AutoSize = true;
            pnlNotificationDropdown.Controls.Add(lblTitle);

            // Fetch notifications
            var notifications = BLL.Services.NotificationService.GetRecentNotifications(UserSession.CurrentUser.Username);
            
            if (notifications.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Không có thông báo nào.";
                lblEmpty.Font = new Font("Arial", 10F);
                lblEmpty.Location = new Point(10, 40);
                lblEmpty.AutoSize = true;
                pnlNotificationDropdown.Controls.Add(lblEmpty);
                return;
            }

            int yPos = 40;
            foreach (var noti in notifications)
            {
                Panel pnlItem = new Panel();
                pnlItem.Size = new Size(pnlNotificationDropdown.Width - 20, 70);
                pnlItem.Location = new Point(10, yPos);
                pnlItem.BackColor = noti.IsRead ? Color.White : Color.AliceBlue; // Nổi bật thông báo chưa đọc

                Label lblType = new Label();
                lblType.Text = noti.Type;
                lblType.Font = new Font("Arial", 10F, FontStyle.Bold);
                lblType.Location = new Point(50, 5);
                lblType.AutoSize = true;
                pnlItem.Controls.Add(lblType);

                Label lblMessage = new Label();
                lblMessage.Text = noti.Message;
                lblMessage.Font = new Font("Arial", 9F);
                lblMessage.Location = new Point(50, 25);
                lblMessage.Size = new Size(270, 40);
                // Tự động xuống dòng
                pnlItem.Controls.Add(lblMessage);

                Label lblTime = new Label();
                lblTime.Text = GetTimeAgo(noti.CreatedAt);
                lblTime.Font = new Font("Arial", 8F, FontStyle.Italic);
                lblTime.ForeColor = Color.Gray;
                lblTime.Location = new Point(pnlItem.Width - 100, 5);
                lblTime.Size = new Size(95, 15);
                lblTime.TextAlign = ContentAlignment.TopRight;
                pnlItem.Controls.Add(lblTime);

                // Icon theo Type
                PictureBox picIcon = new PictureBox();
                picIcon.Size = new Size(30, 30);
                picIcon.Location = new Point(10, 15);
                picIcon.SizeMode = PictureBoxSizeMode.Zoom;
                
                // Set default icon color or image 
                // Using Label as dummy icon (hoặc dùng ký tự emoji)
                Label lblIcon = new Label();
                lblIcon.Font = new Font("Segoe UI Emoji", 14F);
                lblIcon.Size = new Size(30, 30);
                lblIcon.Location = new Point(10, 15);
                lblIcon.Text = GetIconForType(noti.Type);
                pnlItem.Controls.Add(lblIcon);

                pnlNotificationDropdown.Controls.Add(pnlItem);
                yPos += 75;
            }

            // Nút Xem tất cả
            Button btnViewAll = new Button();
            btnViewAll.Text = "View All";
            btnViewAll.Dock = DockStyle.Bottom;
            btnViewAll.FlatStyle = FlatStyle.Flat;
            btnViewAll.FlatAppearance.BorderSize = 0;
            btnViewAll.ForeColor = Color.Red;
            btnViewAll.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnViewAll.Height = 40;
            btnViewAll.Cursor = Cursors.Hand;
            btnViewAll.Click += (s, e) => {
                pnlNotificationDropdown.Visible = false;
                // addUserControl(notifications);
                MessageBox.Show("Mở màn hình tất cả thông báo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            pnlNotificationDropdown.Controls.Add(btnViewAll);
        }

        private string GetTimeAgo(DateTime dt)
        {
            TimeSpan ts = DateTime.Now - dt;
            if (ts.TotalMinutes < 60) return $"{(int)ts.TotalMinutes} minutes ago";
            if (ts.TotalHours < 24) return $"{(int)ts.TotalHours} hours ago";
            return $"{(int)ts.TotalDays} days ago";
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

        // --- CÁC SỰ KIỆN NÚT BẤM ---
        private void btnHome_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Home";
            addUserControl(home);
        }


        private void btnSaving_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Saving";
            addUserControl(listSaving);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "History";
            addUserControl(history);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Transfer";
            addUserControl(transfer);
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Payment";
            addUserControl(invoice);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void frmClientDashboard_Load(object sender, EventArgs e) 
        { 
            SetupNotificationIcon();

            // ✅ Subscribe vào event từ UserSession
            UserSession.OnNotification += UserSession_OnNotification;

            //// Lấy tên người dùng hiện tại từ Database nếu có
            //try
            //{
            //    DTO.Models.AccountDTO account = BLL.Services.AccountService.GetAccountByUsername(CurrentUsername);
            //    if (account != null)
            //    {
            //        DTO.Models.CustomerDTO customer = BLL.Services.AccountService.GetCustomerInfo(account.CustomerID);
            //        if (customer != null)
            //        {
            //            lblUserName.Text = customer.FullName;
            //        }
            //        else
            //        {
            //            lblUserName.Text = CurrentUsername;
            //        }
            //    }
            //}
            //catch
            //{
            //    lblUserName.Text = CurrentUsername;
            //}
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
            lblPageTitle.Text = "Transaction History";
            addUserControl(history);
        }

        public void NavigateToPaymentHistory()
        {
            lblPageTitle.Text = "Payment History";
            addUserControl(paymentHistory);
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
        private void button8_Click(object sender, EventArgs e) { }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            addUserControl(loanDashboard);
        }
    }
}