using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Toast notification popup - hiển thị góc dưới phải màn hình khi có giao dịch
    /// </summary>
    public class ToastNotification : Form
    {
        // ── Controls ────────────────────────────────────────────────
        private Panel  pnlContainer;
        private Label  lblIcon;
        private Label  lblTitle;
        private Label  lblMessage;
        private Label  lblTime;
        private Panel  pnlAccent;       // thanh màu bên trái
        private Timer  timerClose;
        private Timer  timerAnimate;

        // ── Config ───────────────────────────────────────────────────
        private const int DISPLAY_MS   = 4000;   // thời gian tự đóng (ms)
        private const int TOAST_W      = 340;
        private const int TOAST_H      = 100;
        private const int SLIDE_STEP   = 12;

        private int    _targetY;
        private bool   _sliding        = true;

        // ── Màu theo loại ───────────────────────────────────────────
        private Color _accentColor;
        private string _icon;

        // ====================================================================
        // Constructor
        // ====================================================================
        public ToastNotification(string title, string message, string type = "success")
        {
            SetStyle();
            BuildUI(title, message, type);
            PositionOnScreen();
            StartAnimation();
        }

        // ====================================================================
        // Kiểu dáng form
        // ====================================================================
        private void SetStyle()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar   = false;
            this.TopMost         = true;
            this.StartPosition   = FormStartPosition.Manual;
            this.Size            = new Size(TOAST_W, TOAST_H);
            this.BackColor       = Color.White;
            this.Opacity         = 0.97;

            // Bo góc bằng Region
            ApplyRoundedCorners(10);
        }

        private void ApplyRoundedCorners(int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(Width - radius * 2, Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }

        // ====================================================================
        // Xây dựng UI
        // ====================================================================
        private void BuildUI(string title, string message, string type)
        {
            // Chọn màu & icon theo loại
            switch (type.ToLower())
            {
                case "success":
                    _accentColor = Color.FromArgb(46, 204, 113);
                    _icon        = "✓";
                    break;
                case "error":
                    _accentColor = Color.FromArgb(231, 76, 60);
                    _icon        = "✕";
                    break;
                case "warning":
                    _accentColor = Color.FromArgb(241, 196, 15);
                    _icon        = "!";
                    break;
                case "transaction":
                default:
                    _accentColor = Color.FromArgb(41, 128, 185);
                    _icon        = "↑";
                    break;
            }

            // ── Thanh accent bên trái ────────────────────────────────
            pnlAccent = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(6, TOAST_H),
                BackColor = _accentColor
            };

            // ── Icon tròn ────────────────────────────────────────────
            lblIcon = new Label
            {
                Text      = _icon,
                Font      = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = _accentColor,
                Size      = new Size(40, 40),
                Location  = new Point(16, (TOAST_H - 40) / 2),
                TextAlign = ContentAlignment.MiddleCenter
            };
            // Bo tròn icon
            GraphicsPath iconPath = new GraphicsPath();
            iconPath.AddEllipse(0, 0, 40, 40);
            lblIcon.Region = new Region(iconPath);

            // ── Tiêu đề ──────────────────────────────────────────────
            lblTitle = new Label
            {
                Text      = title,
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location  = new Point(66, 18),
                Size      = new Size(TOAST_W - 80, 22),
                AutoEllipsis = true
            };

            // ── Nội dung ─────────────────────────────────────────────
            lblMessage = new Label
            {
                Text      = message,
                Font      = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(90, 90, 90),
                Location  = new Point(66, 40),
                Size      = new Size(TOAST_W - 80, 36),
                AutoEllipsis = true
            };

            // ── Thời gian ─────────────────────────────────────────────
            lblTime = new Label
            {
                Text      = DateTime.Now.ToString("HH:mm"),
                Font      = new Font("Segoe UI", 7.5F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location  = new Point(TOAST_W - 50, 10),
                Size      = new Size(46, 16),
                TextAlign = ContentAlignment.TopRight
            };

            // ── Thanh tiến trình (auto-close indicator) ──────────────
            // Được vẽ qua Paint event của container

            // ── Thêm vào form ─────────────────────────────────────────
            this.Controls.AddRange(new Control[] {
                pnlAccent, lblIcon, lblTitle, lblMessage, lblTime
            });

            // Click để đóng
            this.Click          += (s, e) => CloseToast();
            lblTitle.Click      += (s, e) => CloseToast();
            lblMessage.Click    += (s, e) => CloseToast();
            lblIcon.Click       += (s, e) => CloseToast();

            // Vẽ viền nhẹ
            this.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(220, 220, 220), 1))
                    e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            };
        }

        // ====================================================================
        // Vị trí trên màn hình
        // ====================================================================
        private void PositionOnScreen()
        {
            Rectangle workArea = Screen.PrimaryScreen.WorkingArea;
            int x      = workArea.Right  - TOAST_W - 16;
            _targetY   = workArea.Bottom - TOAST_H - 16;

            // Bắt đầu từ dưới màn hình → slide lên
            this.Location = new Point(x, workArea.Bottom + 10);
        }

        // ====================================================================
        // Animation slide-up
        // ====================================================================
        private void StartAnimation()
        {
            timerAnimate = new Timer { Interval = 10 };
            timerAnimate.Tick += (s, e) =>
            {
                if (_sliding)
                {
                    if (this.Top > _targetY)
                        this.Top = Math.Max(this.Top - SLIDE_STEP, _targetY);
                    else
                    {
                        _sliding = false;
                        timerAnimate.Stop();
                        StartAutoClose();
                    }
                }
            };
            timerAnimate.Start();
        }

        private void StartAutoClose()
        {
            timerClose = new Timer { Interval = DISPLAY_MS };
            timerClose.Tick += (s, e) =>
            {
                timerClose.Stop();
                CloseToast();
            };
            timerClose.Start();
        }

        private void CloseToast()
        {
            timerClose?.Stop();
            timerAnimate?.Stop();
            // Slide xuống rồi đóng
            timerAnimate = new Timer { Interval = 10 };
            int screenBottom = Screen.PrimaryScreen.WorkingArea.Bottom + 20;
            timerAnimate.Tick += (s, e) =>
            {
                if (this.Top < screenBottom)
                    this.Top += SLIDE_STEP;
                else
                {
                    timerAnimate.Stop();
                    this.Close();
                    this.Dispose();
                }
            };
            timerAnimate.Start();
        }

        // ====================================================================
        // Factory methods — dùng từ bên ngoài
        // ====================================================================

        /// <summary>
        /// Hiển thị toast thông báo chuyển khoản thành công
        /// </summary>
        public static void ShowTransfer(string recipientName, string recipientAccount, decimal amount)
        {
            string title   = "✅ Chuyển khoản thành công";
            string message = $"Đã chuyển {amount:N0} VNĐ\nTới: {recipientName} ({recipientAccount})";
            ShowToast(title, message, "success");
        }

        /// <summary>
        /// Hiển thị toast thông báo tạo tiết kiệm thành công
        /// </summary>
        public static void ShowSaving(decimal amount, int months)
        {
            string title   = "📅 Tạo tiết kiệm thành công";
            string message = $"Số tiền: {amount:N0} VNĐ | Kỳ hạn: {months} tháng";
            ShowToast(title, message, "success");
        }

        /// <summary>
        /// Hiển thị toast thông báo gửi thêm tiết kiệm
        /// </summary>
        public static void ShowDeposit(decimal amount)
        {
            string title   = "💰 Gửi thêm thành công";
            string message = $"Đã gửi thêm {amount:N0} VNĐ vào tài khoản tiết kiệm";
            ShowToast(title, message, "success");
        }

        /// <summary>
        /// Hiển thị toast lỗi
        /// </summary>
        public static void ShowError(string message)
        {
            ShowToast("❌ Có lỗi xảy ra", message, "error");
        }

        private static void ShowToast(string title, string message, string type)
        {
            // Phải chạy trên UI thread
            Form activeForm = Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null;
            if (activeForm != null && activeForm.InvokeRequired)
            {
                activeForm.Invoke(new Action(() => ShowToast(title, message, type)));
                return;
            }

            var toast = new ToastNotification(title, message, type);
            toast.Show();
        }
    }
}
