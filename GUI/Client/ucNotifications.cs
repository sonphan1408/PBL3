using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BLL.Services;
using GUI.Session;

namespace GUI.Client
{
    public partial class ucNotifications : UserControl
    {
        private List<NotificationInfo> notifications = new List<NotificationInfo>();
        private NotificationInfo selectedNotification = null;

        // ─── Màu chủ đề (khớp với HTTS Bank - DodgerBlue) ────────────────
        private static readonly Color BlueMain    = Color.DodgerBlue;                        // #1E90FF - màu chủ đạo
        private static readonly Color BlueDark     = Color.FromArgb(10, 90, 190);             // xanh đậm hơn cho gradient
        private static readonly Color BlueLight    = Color.FromArgb(230, 242, 255);           // nền nhạt xanh
        private static readonly Color GreenIcon    = Color.FromArgb(40, 167, 69);
        private static readonly Color LightGreen   = Color.FromArgb(220, 255, 220);
        private static readonly Color LightOrange  = Color.FromArgb(255, 243, 220);
        private static readonly Color LightBlue    = Color.FromArgb(230, 242, 255);
        private static readonly Color BorderGray   = Color.FromArgb(220, 220, 220);
        private static readonly Color UnreadAccent = Color.DodgerBlue;                        // viền trái thông báo chưa đọc

        public ucNotifications()
        {
            InitializeComponent();
            this.Resize += (s, e) => LayoutPanels();
        }

        // ─── Load ─────────────────────────────────────────────────────
        private void ucNotifications_Load(object sender, EventArgs e)
        {
            try
            {
                UserSession.OnNotification += UserSession_OnNotification;
                LoadNotifications();
                LayoutPanels();
                StyleDetailCard();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in ucNotifications_Load: " + ex.Message);
            }
        }

        // ─── Reset khi quay lại trang ─────────────────────────────────
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                selectedNotification = null;
                LoadNotifications();
                LayoutPanels();
            }
        }

        // Canh lại kích thước khi resize và khi trạng thái chọn thay đổi
        private void LayoutPanels()
        {
            if (selectedNotification == null)
            {
                pnlRight.Visible = false;
                pnlLeft.Width = this.Width;
            }
            else
            {
                pnlRight.Visible = true;
                pnlLeft.Width = (int)(this.Width * 0.60);
            }

            pnlScrollList.Width  = pnlListArea.Width - 40;
            pnlScrollList.Height = pnlListArea.Height - 75;

            // Cập nhật lại chiều rộng các thẻ thông báo (cards) nếu đã được tạo
            foreach (Control ctrl in pnlScrollList.Controls)
            {
                if (ctrl.Tag != null) // Tag lưu index, xác định đây là card
                {
                    ctrl.Width = pnlScrollList.Width - 18;
                    // Cập nhật vị trí nút X và nhãn thời gian
                    foreach (Control child in ctrl.Controls)
                    {
                        if (child is Button btn && btn.Text == "×")
                            btn.Location = new Point(ctrl.Width - 30, 10);
                        else if (child is Label lbl && lbl.ForeColor == Color.FromArgb(140, 140, 140)) // lblTime
                            lbl.Location = new Point(ctrl.Width - 105, 14);
                        else if (child is Label lblMsg && lblMsg.ForeColor == Color.FromArgb(90, 90, 90)) // lblMsg
                            lblMsg.Width = ctrl.Width - 170;
                    }
                    ctrl.Invalidate();
                }
            }

            // Căn giữa detail card theo chiều dọc của pnlRight
            if (pnlRight.Visible)
            {
                int cardW = Math.Min(340, pnlRight.Width - 40);
                int cardH = 370;
                pnlDetailCard.Size = new Size(cardW, cardH);
                pnlDetailCard.Location = new Point(
                    (pnlRight.Width - cardW) / 2,
                    (pnlRight.Height - cardH) / 2
                );
                lblDetailContent.Size = new Size(cardW - 40, 150);
            }
        }

        // ─── Style detail card (bo góc) ───────────────────────────────
        private void StyleDetailCard()
        {
            pnlDetailCard.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, pnlDetailCard.Width - 1, pnlDetailCard.Height - 1);
                var path = RoundedRect(rect, 14);
                g.FillPath(new SolidBrush(Color.White), path);
                using (var pen = new Pen(BorderGray, 1)) g.DrawPath(pen, path);
            };

            // Bo góc picDetailIcon – vẽ động theo loại
            picDetailIcon.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, picDetailIcon.Width - 1, picDetailIcon.Height - 1);
                var path = RoundedRect(rect, 12);
                Color bg  = selectedNotification != null ? GetIconBgColor(selectedNotification.Type) : LightGreen;
                Color fg  = selectedNotification != null ? GetIconFgColor(selectedNotification.Type) : GreenIcon;
                g.FillPath(new SolidBrush(bg), path);
                DrawIconOnPanel(g, selectedNotification?.Type, fg, picDetailIcon.Width, picDetailIcon.Height);
            };

            // Cho phép lblDetailContent wrap text
            lblDetailContent.AutoSize  = false;
            lblDetailContent.MaximumSize = new Size(lblDetailContent.Width, 0);
        }

        // ─── Notification events ──────────────────────────────────────
        private void UserSession_OnNotification(string message, string type)
        {
            if (this.InvokeRequired) { this.Invoke(new Action(() => UserSession_OnNotification(message, type))); return; }
            LoadNotifications();
        }

        // ─── Load data ────────────────────────────────────────────────
        public void LoadNotifications()
        {
            try
            {
                pnlScrollList.Controls.Clear();
                notifications.Clear();

                if (UserSession.CurrentUser == null)
                {
                    lblEmpty.Visible = true;
                    lblEmpty.Parent  = pnlScrollList;
                    return;
                }

                var dbNotifications = NotificationService.GetRecentNotifications(UserSession.CurrentUser.Username);
                if (dbNotifications != null)
                {
                    foreach (var notif in dbNotifications)
                    {
                        notifications.Add(new NotificationInfo
                        {
                            Message   = notif.Message,
                            Type      = notif.Type,
                            CreatedAt = notif.CreatedAt,
                            IsRead    = notif.IsRead
                        });
                    }
                }

                if (notifications.Count == 0)
                {
                    lblEmpty.Visible = true;
                    lblEmpty.Parent  = pnlScrollList;
                }
                else
                {
                    lblEmpty.Visible = false;
                    BuildNotificationCards();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading notifications: " + ex.Message);
            }
        }

        // ─── Build card list ──────────────────────────────────────────
        private void BuildNotificationCards()
        {
            pnlScrollList.Controls.Clear();
            int yPos = 5;

            for (int i = 0; i < notifications.Count; i++)
            {
                var notif = notifications[i];
                Panel card = CreateNotificationCard(notif, i);
                card.Location = new Point(0, yPos);
                pnlScrollList.Controls.Add(card);
                yPos += card.Height + 10;
            }
        }

        private Panel CreateNotificationCard(NotificationInfo notif, int index)
        {
            // ── Màu theo loại ─────────────────────────────────────────
            Color  iconBg    = LightGreen;
            Color  iconFg    = GreenIcon;
            string typeLabel = GetTypeLabel(notif.Type);
            string iconChar  = GetIconChar(notif.Type);

            if (notif.Type?.ToLower().Contains("deposit") == true)
            { iconBg = LightBlue;   iconFg = Color.FromArgb(30, 100, 200); }
            else if (notif.Type?.ToLower().Contains("withdraw") == true)
            { iconBg = LightGreen;  iconFg = GreenIcon; }
            else if (notif.Type?.ToLower().Contains("saving") == true)
            { iconBg = LightOrange; iconFg = Color.FromArgb(200, 120, 20); }

            // ── Card panel ────────────────────────────────────────────
            Panel card = new Panel();
            card.Size      = new Size(pnlScrollList.Width - 18, 80);
            card.BackColor = notif.IsRead ? Color.White : Color.FromArgb(235, 245, 255);  // xanh nhạt cho chưa đọc
            card.Cursor    = Cursors.Hand;
            card.Tag       = index;

            // Bo góc + shadow light via Paint
            card.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                var path = RoundedRect(rect, 12);
                g.FillPath(new SolidBrush(card.BackColor), path);
                using (var pen = new Pen(BorderGray, 1)) g.DrawPath(pen, path);

                // Đường viền trái DodgerBlue nếu chưa đọc
                if (!notif.IsRead)
                {
                    using (var pen = new Pen(UnreadAccent, 4))
                        g.DrawLine(pen, 2, 8, 2, card.Height - 8);
                }
            };

            // ── Icon label (bo tròn) ──────────────────────────────────
            Label lblIcon = new Label();
            lblIcon.Size      = new Size(44, 44);
            lblIcon.Location  = new Point(14, 18);
            lblIcon.Text      = iconChar;
            lblIcon.Font      = new Font("Segoe UI Emoji", 16F);
            lblIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblIcon.BackColor = Color.Transparent;
            lblIcon.ForeColor = iconFg;

            // Bo tròn icon background
            Panel iconBg2 = new Panel();
            iconBg2.Size      = new Size(44, 44);
            iconBg2.Location  = new Point(14, 18);
            iconBg2.BackColor = iconBg;
            iconBg2.Paint     += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                var path = RoundedRect(new Rectangle(0, 0, iconBg2.Width - 1, iconBg2.Height - 1), 10);
                g.FillPath(new SolidBrush(iconBg), path);
                // Draw check or calendar
                DrawIconOnPanel(g, notif.Type, iconFg, iconBg2.Width, iconBg2.Height);
            };
            card.Controls.Add(iconBg2);

            // ── Type label ────────────────────────────────────────────
            Label lblType = new Label();
            lblType.AutoSize  = true;
            lblType.Location  = new Point(68, 14);
            lblType.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblType.ForeColor = Color.FromArgb(30, 30, 30);
            lblType.Text      = typeLabel;
            lblType.BackColor = Color.Transparent;
            card.Controls.Add(lblType);

            // ── Message label ─────────────────────────────────────────
            Label lblMsg = new Label();
            lblMsg.Location  = new Point(68, 36);
            lblMsg.Size      = new Size(card.Width - 170, 36);
            lblMsg.Font      = new Font("Segoe UI", 9F);
            lblMsg.ForeColor = Color.FromArgb(90, 90, 90);
            lblMsg.Text      = notif.Message;
            lblMsg.BackColor = Color.Transparent;
            card.Controls.Add(lblMsg);

            // ── Time label ────────────────────────────────────────────
            Label lblTime = new Label();
            lblTime.AutoSize  = true;
            lblTime.Location  = new Point(card.Width - 105, 14);
            lblTime.Font      = new Font("Segoe UI", 8.5F);
            lblTime.ForeColor = Color.FromArgb(140, 140, 140);
            lblTime.Text      = GetTimeAgo(notif.CreatedAt);
            lblTime.BackColor = Color.Transparent;
            card.Controls.Add(lblTime);

            // ── X button ─────────────────────────────────────────────
            Button btnDismiss = new Button();
            btnDismiss.Size      = new Size(22, 22);
            btnDismiss.Location  = new Point(card.Width - 30, 10);
            btnDismiss.Text      = "×";
            btnDismiss.Font      = new Font("Segoe UI", 11F);
            btnDismiss.FlatStyle = FlatStyle.Flat;
            btnDismiss.FlatAppearance.BorderSize = 0;
            btnDismiss.BackColor = Color.Transparent;
            btnDismiss.ForeColor = Color.Gray;
            btnDismiss.Cursor    = Cursors.Hand;
            btnDismiss.Tag       = index;
            btnDismiss.Click    += BtnDismiss_Click;
            card.Controls.Add(btnDismiss);

            // Hover effect - dùng xanh nhạt DodgerBlue
            card.MouseEnter += (s, e) => { card.BackColor = Color.FromArgb(220, 237, 255); card.Invalidate(); };
            card.MouseLeave += (s, e) => { card.BackColor = notif.IsRead ? Color.White : Color.FromArgb(235, 245, 255); card.Invalidate(); };

            // Click → show detail
            Action showDetail = () => ShowDetail(notif);
            card.Click += (s, e) => showDetail();
            foreach (Control c in card.Controls)
                if (!(c is Button)) c.Click += (s, e) => showDetail();

            // Propagate mouse events từ children lên card để hover hoạt động
            foreach (Control c in card.Controls)
            {
                c.MouseEnter += (s, e) => { card.BackColor = Color.FromArgb(220, 237, 255); card.Invalidate(); };
                c.MouseLeave += (s, e) => { card.BackColor = notif.IsRead ? Color.White : Color.FromArgb(235, 245, 255); card.Invalidate(); };
            }

            return card;
        }

        // ─── Draw icon bên trong panel bo tròn ───────────────────────
        private void DrawIconOnPanel(Graphics g, string type, Color color, int w, int h)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var pen = new Pen(color, 2.5f))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap   = LineCap.Round;

                if (type?.ToLower().Contains("saving") == true)
                {
                    // Calendar icon
                    g.DrawRectangle(pen, 8, 10, 28, 24);
                    g.DrawLine(pen, 14, 8,  14, 14);
                    g.DrawLine(pen, 30, 8,  30, 14);
                    g.DrawLine(pen, 8,  20, 36, 20);
                }
                else
                {
                    // Check icon
                    g.DrawLines(pen, new Point[]
                    {
                        new Point(10, 22), new Point(19, 32), new Point(34, 12)
                    });
                }
            }
        }

        // ─── Show detail ──────────────────────────────────────────────
        private void ShowDetail(NotificationInfo notif)
        {
            selectedNotification = notif;

            lblDetailTitle.Text   = GetTypeLabel(notif.Type);
            lblDetailTime.Text    = notif.CreatedAt.ToString("dd/MM/yyyy  HH:mm");
            lblDetailContent.Text = notif.Message;

            // Cập nhật màu nền icon theo loại, buộc repaint
            picDetailIcon.BackColor = Color.Transparent;
            picDetailIcon.Invalidate();
            pnlDetailCard.Invalidate();

            // Hiện panel chi tiết và canh lại layout
            pnlDetailCard.Visible = true;
            lblNoDetail.Visible   = false;
            LayoutPanels();

            // Đánh dấu đã đọc
            notif.IsRead = true;
            try { NotificationService.MarkAllAsRead(UserSession.CurrentUser.Username); } catch { }
            BuildNotificationCards();
        }

        // ─── Dismiss ─────────────────────────────────────────────────
        private void BtnDismiss_Click(object sender, EventArgs e)
        {
            // Hiện tại chỉ reload list (có thể mở rộng xóa DB sau)
            LoadNotifications();
        }

        // ─── Helper: Detail card icon paint ──────────────────────────
        // Được gọi qua picDetailIcon.Paint (đã gắn trong StyleDetailCard)

        // ─── Helpers ──────────────────────────────────────────────────
        private string GetTypeLabel(string type)
        {
            if (string.IsNullOrEmpty(type)) return "Thông báo";
            if (type.ToLower().Contains("saving"))   return "Tiết kiệm";
            if (type.ToLower().Contains("deposit"))  return "Nạp tiền";
            if (type.ToLower().Contains("withdraw")) return "Rút tiền";
            if (type.ToLower().Contains("transfer")) return "Chuyển khoản";
            if (type.ToLower().Contains("transaction")) return "Giao dịch";
            return type;
        }

        private string GetIconChar(string type)
        {
            if (string.IsNullOrEmpty(type)) return "🔔";
            if (type.ToLower().Contains("saving"))   return "📅";
            if (type.ToLower().Contains("deposit"))  return "💰";
            if (type.ToLower().Contains("withdraw")) return "✅";
            return "🔔";
        }

        private Color GetIconBgColor(string type)
        {
            if (type?.ToLower().Contains("deposit")  == true) return LightBlue;
            if (type?.ToLower().Contains("saving")   == true) return LightOrange;
            return LightGreen;
        }

        private Color GetIconFgColor(string type)
        {
            if (type?.ToLower().Contains("deposit")  == true) return Color.FromArgb(30, 100, 200);
            if (type?.ToLower().Contains("saving")   == true) return Color.FromArgb(200, 120, 20);
            return GreenIcon;
        }

        private string GetTimeAgo(DateTime dt)
        {
            var ts = DateTime.Now - dt;
            if (ts.TotalSeconds < 60)  return $"{(int)ts.TotalSeconds} giây trước";
            if (ts.TotalMinutes < 60)  return $"{(int)ts.TotalMinutes} phút trước";
            if (ts.TotalHours   < 24)  return $"{(int)ts.TotalHours} giờ trước";
            if (ts.TotalDays    < 7)   return $"{(int)ts.TotalDays} ngày trước";
            return dt.ToString("dd/MM/yyyy");
        }

        // Bo góc helper
        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ─── Inner class ──────────────────────────────────────────────
        private class NotificationInfo
        {
            public string   Message   { get; set; }
            public string   Type      { get; set; }
            public DateTime CreatedAt { get; set; }
            public bool     IsRead    { get; set; }
        }
    }
}
