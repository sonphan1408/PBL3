using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    /// <summary>
    /// DTO để truyền dữ liệu notification, không phải formatted message
    /// Notification system sẽ format dựa vào OperationType
    /// </summary>
    public class NotificationMessageDTO
    {
        /// <summary>
        /// Loại hoạt động: "transfer", "savings", "payment", "deposit", "withdrawal", etc.
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// Loại notification: "success", "error", "warning", "transaction"
        /// </summary>
        public string NotificationType { get; set; } = "transaction";

        // Dữ liệu cho Transfer
        public string RecipientName { get; set; }
        public string RecipientAccount { get; set; }
        public decimal TransferAmount { get; set; }

        // Dữ liệu cho Savings
        public decimal PrincipalAmount { get; set; }
        public int TermMonths { get; set; }
        public decimal InterestRate { get; set; }
        public string SavingsAccountNumber { get; set; }

        // Dữ liệu cho Payment/Invoice
        public string InvoiceId { get; set; }
        public decimal PaymentAmount { get; set; }

        // Dữ liệu cho Deposit/Withdrawal
        public decimal Amount { get; set; }
        public string Description { get; set; }

        // Dữ liệu cho Error
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Format message dựa vào OperationType
        /// </summary>
        public string FormatMessage()
        {
            switch (OperationType?.ToLower())
            {
                case "transfer":
                    return $"Chuyển khoản thành công: Đã chuyển {TransferAmount:N0} VND cho {RecipientName} ({RecipientAccount})";

                case "savings":
                    return $"Mở sổ tiết kiệm thành công: {PrincipalAmount:N0} VND, {TermMonths} tháng, Lãi suất: {InterestRate}%";

                case "savings_deposit":
                    return $"Gửi thêm tiền vào sổ tiết kiệm thành công: {Amount:N0} VND - {Description}";

                case "payment":
                    return $"Thanh toán thành công: {PaymentAmount:N0} VND cho hóa đơn {InvoiceId}";

                case "deposit":
                    return $"Nạp tiền thành công: {Amount:N0} VND - {Description}";

                case "withdrawal":
                    return $"Rút tiền thành công: {Amount:N0} VND - {Description}";

                case "loan_repayment":
                    return $"Thanh toán khoản vay thành công: {Amount:N0} VND - {Description}";

                case "error":
                    return $"Lỗi: {ErrorMessage}";

                case "warning":
                    return Description ?? "Cảnh báo hệ thống";

                default:
                    return Description ?? "Giao dịch hoàn tất";
            }
        }
    }
}
