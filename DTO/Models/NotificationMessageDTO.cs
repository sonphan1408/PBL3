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
                    return $"Transfer successful: Sent {TransferAmount:N0} VND to {RecipientName} ({RecipientAccount})";

                case "savings":
                    return $"Savings account created: {PrincipalAmount:N0} VND, {TermMonths} months, Rate: {InterestRate}%";

                case "payment":
                    return $"Invoice payment successful: {PaymentAmount:N0} VND for Invoice {InvoiceId}";

                case "deposit":
                    return $"Deposit successful: {Amount:N0} VND - {Description}";

                case "withdrawal":
                    return $"Withdrawal successful: {Amount:N0} VND - {Description}";

                case "error":
                    return $"Error: {ErrorMessage}";

                case "warning":
                    return Description ?? "Warning notification";

                default:
                    return Description ?? "Operation completed";
            }
        }
    }
}
