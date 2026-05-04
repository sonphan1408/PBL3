using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Session
{
    // ✅ Event delegate cho Notification
    public delegate void NotificationEventHandler(string message, string type);

    public static class UserSession
    {
        public static AccountCustomerDTO CurrentUser { get; set; }

        // ✅ Static event để bất kỳ UI nào cũng có thể subscribe
        public static event NotificationEventHandler OnNotification;

        public static void ClearSession()
        {
            CurrentUser = null;
        }

        /// <summary>
        /// Phát sự kiện notification (được gọi từ bất kỳ UI nào)
        /// </summary>
        public static void RaiseNotification(string message, string type = "General")
        {
            // Gọi tất cả subscribers (chủ yếu là frmClientDashboard)
            OnNotification?.Invoke(message, type);

            // Lưu vào Database
            try
            {
                BLL.Services.NotificationService.CreateNotification(CurrentUser?.Username, message, type);
            }
            catch { }
        }
        public static event Action BalanceChanged;

      
        public static void UpdateBalance(decimal amountToDeduct)
        {
            if (CurrentUser != null)
            {
                // Trừ tiền ngay trên RAM (Session)
                CurrentUser.Balance -= amountToDeduct;

                // PHÁT LOA! Gọi tất cả những Form nào đang đăng ký nghe sự kiện này
                BalanceChanged?.Invoke();
            }
        }

        public static void AddBalance(decimal amountToDeduct)
        {
            if (CurrentUser != null)
            {
                
                CurrentUser.Balance += amountToDeduct;

              
                BalanceChanged?.Invoke();
            }
        }

    }
}
