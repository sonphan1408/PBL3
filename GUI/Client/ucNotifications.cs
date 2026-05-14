using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL.Services;
using GUI.Session;

namespace GUI.Client
{
    public partial class ucNotifications : UserControl
    {
        private List<NotificationInfo> notifications = new List<NotificationInfo>();

        public ucNotifications()
        {
            InitializeComponent();
        }

        private void ucNotifications_Load(object sender, EventArgs e)
        {
            try
            {
                // Subscribe to notification events
                UserSession.OnNotification += UserSession_OnNotification;
                
                // Load initial notifications
                LoadNotifications();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in ucNotifications_Load: " + ex.Message);
            }
        }

        private void UserSession_OnNotification(string message, string type)
        {
            try
            {
                // Reload notifications when a new one is posted
                LoadNotifications();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in OnNotification handler: " + ex.Message);
            }
        }

        public void LoadNotifications()
        {
            try
            {
                if (UserSession.CurrentUser == null)
                {
                    lstNotifications.Items.Clear();
                    lblEmpty.Visible = true;
                    return;
                }

                // Get notifications from database
                var dbNotifications = NotificationService.GetRecentNotifications(UserSession.CurrentUser.Username);
                
                notifications.Clear();
                if (dbNotifications != null)
                {
                    foreach (var notif in dbNotifications)
                    {
                        notifications.Add(new NotificationInfo
                        {
                            Message = notif.Message,
                            Type = notif.Type,
                            CreatedAt = notif.CreatedAt,
                            IsRead = notif.IsRead
                        });
                    }
                }

                // Refresh listbox
                lstNotifications.Items.Clear();
                if (notifications.Count == 0)
                {
                    lblEmpty.Visible = true;
                }
                else
                {
                    lblEmpty.Visible = false;
                    foreach (var notif in notifications)
                    {
                        lstNotifications.Items.Add(notif);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading notifications: " + ex.Message);
            }
        }

        private void LstNotifications_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= notifications.Count)
                return;

            var notif = notifications[e.Index];
            e.DrawBackground();

            // Colors based on notification type
            Color bgColor = Color.White;
            Color borderColor = Color.Gray;
            Color textColor = Color.Black;
            string icon = "ℹ️";

            switch (notif.Type?.ToLower())
            {
                case "success":
                    bgColor = Color.FromArgb(240, 255, 240);
                    borderColor = Color.FromArgb(40, 167, 69);
                    icon = "✓";
                    break;
                case "error":
                    bgColor = Color.FromArgb(255, 240, 245);
                    borderColor = Color.FromArgb(220, 53, 69);
                    icon = "✕";
                    break;
                case "warning":
                    bgColor = Color.FromArgb(255, 248, 240);
                    borderColor = Color.FromArgb(211, 84, 0);
                    icon = "⚠";
                    break;
                case "transaction":
                    bgColor = Color.FromArgb(240, 248, 255);
                    borderColor = Color.FromArgb(25, 55, 99);
                    icon = "→";
                    break;
                default:
                    bgColor = Color.FromArgb(250, 250, 250);
                    break;
            }

            // Draw background and border
            using (Brush br = new SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
            }

            using (Pen pen = new Pen(borderColor, 2))
            {
                e.Graphics.DrawRectangle(pen, e.Bounds.X + 5, e.Bounds.Y + 5, e.Bounds.Width - 10, e.Bounds.Height - 10);
            }

            // Draw icon
            Font iconFont = new Font("Arial", 16, FontStyle.Bold);
            e.Graphics.DrawString(icon, iconFont, new SolidBrush(borderColor), new PointF(e.Bounds.X + 15, e.Bounds.Y + 8));

            // Draw message
            Font msgFont = new Font("Segoe UI", 9, FontStyle.Bold);
            RectangleF msgRect = new RectangleF(e.Bounds.X + 50, e.Bounds.Y + 8, e.Bounds.Width - 70, 25);
            e.Graphics.DrawString(notif.Message, msgFont, new SolidBrush(textColor), msgRect);

            // Draw timestamp
            Font timeFont = new Font("Segoe UI", 8);
            RectangleF timeRect = new RectangleF(e.Bounds.X + 50, e.Bounds.Y + 32, e.Bounds.Width - 70, 20);
            e.Graphics.DrawString(notif.CreatedAt.ToString("yyyy-MM-dd HH:mm"), timeFont, new SolidBrush(Color.Gray), timeRect);

            e.DrawFocusRectangle();
        }

        private class NotificationInfo
        {
            public string Message { get; set; }
            public string Type { get; set; }
            public DateTime CreatedAt { get; set; }
            public bool IsRead { get; set; }

            public override string ToString() => Message;
        }
    }
}
