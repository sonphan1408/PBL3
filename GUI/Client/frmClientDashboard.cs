using System;
using System.Drawing;
using System.Drawing.Drawing2D; // Bổ sung thêm thư viện này để dùng được GraphicsPath
using System.Windows.Forms;

namespace GUI.Client
{
    public partial class frmClientDashboard : Form
    {
       
        ucClientHome home;
        ucSaving saving;
        ucHistory history;
        ucInvoicePayment invoice;
        ucNotifications notifications;
        ucTransfer transfer;
        
        public string CurrentUsername { get; private set; }

        
        public frmClientDashboard()
        {
            InitializeComponent(); 

            home = new ucClientHome();
            saving = new ucSaving();
            history = new ucHistory();
            invoice = new ucInvoicePayment();
            notifications = new ucNotifications();
            transfer = new ucTransfer();
        }

        // Constructor that accepts username; chains to parameterless to reuse initialization
        public frmClientDashboard(string username) : this()
        {
            CurrentUsername = username;
            
            home.Dispose();
            home = new ucClientHome(username);
            transfer.SetUsername(username);

            // Load home page by default
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
                BLL.Services.NotificationService.MarkAllAsRead(CurrentUsername);
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
            var notifications = BLL.Services.NotificationService.GetRecentNotifications(CurrentUsername);
            
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
                int count = BLL.Services.NotificationService.GetUnreadCount(CurrentUsername);
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
            addUserControl(home);
        }

       
        private void btnSaving_Click(object sender, EventArgs e)
        {
            addUserControl(saving);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            addUserControl(history);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            addUserControl(transfer);
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            addUserControl(invoice);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void frmClientDashboard_Load(object sender, EventArgs e) 
        { 
            SetupNotificationIcon();
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
        private void pnlLogo_Paint(object sender, PaintEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void pnlMain_Paint(object sender, PaintEventArgs e) { }
        private void pnlSidebar_Paint(object sender, PaintEventArgs e) { }

        // Code bo góc thanh tìm kiếm của bạn (Đã chuẩn)
        private void pnlSearch_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 25;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnlSearch.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnlSearch.Width - radius, pnlSearch.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnlSearch.Height - radius, radius, radius, 90, 90);
            pnlSearch.Region = new Region(path);
        }

        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void button8_Click(object sender, EventArgs e) { }
    }
}