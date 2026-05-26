using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Session
{
    // ✅ Event delegate cho Notification - truyền formatted message và type
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
        /// Phát sự kiện notification dựa vào NotificationMessageDTO
        /// System sẽ format message dựa vào OperationType
        /// </summary>
        public static void RaiseNotification(NotificationMessageDTO notificationData)
        {
            try
            {
                if (notificationData == null)
                    return;

                // Format message dựa vào OperationType
                string formattedMessage = notificationData.FormatMessage();
                string notificationType = notificationData.NotificationType;

                System.Diagnostics.Debug.WriteLine($"[UserSession] RaiseNotification: {formattedMessage} ({notificationType})");

                // ✅ Lưu vào Database TRƯỚC — để khi UI reload sẽ có data
                try
                {
                    BLL.Services.NotificationService.CreateNotification(
                        CurrentUser?.Username, 
                        formattedMessage, 
                        notificationType
                    );
                    System.Diagnostics.Debug.WriteLine($"[UserSession] Notification saved to DB successfully");
                }
                catch (Exception ex) 
                { 
                    System.Diagnostics.Debug.WriteLine($"[UserSession] Error saving notification: {ex.Message}");
                }

                // ✅ Sau đó mới gọi UI subscribers — lúc này DB đã có data
                OnNotification?.Invoke(formattedMessage, notificationType);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[UserSession] Error in RaiseNotification: {ex.Message}");
            }
        }
        public static event Action BalanceChanged;
        public static event Action DataSavingChanged;
        public static event Action DataLoanChanged;



        public static void UpdateBalance(decimal amountToDeduct)
        {
            if (CurrentUser != null)
            {
                
                CurrentUser.Balance -= amountToDeduct;

                
                System.Diagnostics.Debug.WriteLine($"[UserSession] UpdateBalance: Deducting {amountToDeduct}, New balance: {CurrentUser.Balance}");

                // PHÁT LOA! Gọi tất cả những Form nào đang đăng ký nghe sự kiện này
                System.Diagnostics.Debug.WriteLine($"[UserSession] Triggering BalanceChanged event. Subscribers: {(BalanceChanged == null ? 0 : BalanceChanged.GetInvocationList().Length)}");
                BalanceChanged?.Invoke();
            }
        }

        public static void AddBalance(decimal amountToAdd)
        {
            if (CurrentUser != null)
            {
                CurrentUser.Balance += amountToAdd;
                
                System.Diagnostics.Debug.WriteLine($"[UserSession] AddBalance: Adding {amountToAdd}, New balance: {CurrentUser.Balance}");
                System.Diagnostics.Debug.WriteLine($"[UserSession] Triggering BalanceChanged event. Subscribers: {(BalanceChanged == null ? 0 : BalanceChanged.GetInvocationList().Length)}");
                BalanceChanged?.Invoke();
            }
        }
        public static void LoadSavingData()
        {
           
                DataSavingChanged?.Invoke();
            
        }
        public static void LoadLoanData()
        {

            DataLoanChanged?.Invoke();

        }



    }
}
