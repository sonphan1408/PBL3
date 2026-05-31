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
                // Tự động log giao dịch vào lịch sử nếu đây là một transaction
                if (notificationData.NotificationType == "transaction" || notificationData.NotificationType == "success") 
                {
                    LogTransactionFromNotification(notificationData);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[UserSession] Error in RaiseNotification: {ex.Message}");
            }
        }

        private static void LogTransactionFromNotification(DTO.Models.NotificationMessageDTO data)
        {
            if (CurrentUser == null) return;

            string op = data.OperationType?.ToLower();
            if (op == "transfer" || op == "error" || op == "warning") return;

            decimal amount = 0;
            bool isExpense = true;
            string toAccount = "";
            int typeId = 0;

            if (op == "savings") // Mở sổ tiết kiệm
            {
                amount = data.PrincipalAmount;
                isExpense = true;
                toAccount = "SAVING";
                typeId = 5;
            }
            else if (op == "savings_deposit") // Gửi thêm vào sổ tiết kiệm
            {
                amount = data.Amount;
                isExpense = true;
                toAccount = "SAVING";
                typeId = 5;
            }
            else if (op == "payment") // Thanh toán
            {
                amount = data.PaymentAmount;
                isExpense = true;
                toAccount = "PAYMENT";
                typeId = 4;
            }
            else if (op == "deposit") // Giải ngân khoản vay
            {
                amount = data.Amount;
                isExpense = false; // Nhận tiền
                toAccount = "LOAN";
                typeId = 6;
            }
            else if (op == "withdrawal") // Tất toán sổ hoặc thanh toán khoản vay
            {
                amount = data.Amount;
                if (data.Description?.Contains("tiết kiệm") == true)
                {
                    isExpense = false; // Nhận tiền
                    toAccount = "SAVING";
                    typeId = 5;
                }
                else
                {
                    isExpense = true; // Trừ tiền
                    toAccount = "LOAN";
                    typeId = 6;
                }
            }
            else if (op == "loan_repayment") // Thanh toán kỳ vay
            {
                amount = data.Amount;
                isExpense = true;
                toAccount = "LOAN";
                typeId = 6;
            }
            else return;

            try
            {
                var trans = new DTO.Models.InternalTransactionDTO
                {
                    TransactionID = Guid.NewGuid(),
                    FromAccount = isExpense ? CurrentUser.AccountNumber : toAccount,
                    ToAccount = isExpense ? toAccount : CurrentUser.AccountNumber,
                    TypeID = typeId,
                    Amount = amount,
                    BalanceBefore = CurrentUser.Balance + (isExpense ? amount : -amount),
                    BalanceAfter = CurrentUser.Balance,
                    Description = data.Description ?? data.FormatMessage(),
                    CreatedAt = DateTime.Now
                };
                BLL.Services.TransactionService.CreateInternalTransaction(trans);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[UserSession] Error logging transaction from notification: {ex.Message}");
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
