using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.Services
{
    public class PaymentService
    {
        private InvoiceDAL _invoiceDAL = new InvoiceDAL();

        // 🌟 THỦ THUẬT TEST: Danh sách tĩnh lưu tạm các mã hóa đơn/số điện thoại đã thanh toán
        public static List<string> TempPaidBills = new List<string>();

        public List<string> GetProviders(int serviceTypeId)
        {
            // Gọi hàm GetProviders từ tầng DAL mà bạn vừa tạo ở bước trước
            return _invoiceDAL.GetProviders(serviceTypeId);
        }
        // Hàm xử lý thanh toán, trả về true nếu thành công, false nếu thất bại (ví dụ: sai mật khẩu)
        public string ProcessPayment(string inputPassword, string actualPassword, string targetCode, decimal amount, ref decimal currentBalance)
        {
            // 1. Kiểm tra Mật khẩu
            if (inputPassword != actualPassword)
            {
                return "Mật khẩu xác nhận không chính xác!";
            }

            // 2. Kiểm tra Số dư
            if (currentBalance < amount)
            {
                return "Số dư tài khoản không đủ để thực hiện giao dịch!";
            }

            // 3. Trừ tiền trực tiếp vào RAM (Session)
            currentBalance -= amount;

            // 4. Lưu mã hóa đơn/số điện thoại vào RAM để làm mượt giao diện
            if (!TempPaidBills.Contains(targetCode))
            {
                TempPaidBills.Add(targetCode);
            }

            return ""; // Giao dịch thành công ảo
        }

        /// <summary>
        /// Hàm kéo hóa đơn đã được nâng cấp thêm logic "Né" các hóa đơn đã test
        /// </summary>
        public List<InvoiceDTO> GetPendingInvoices(string accountNumber, int serviceTypeId)
        {
            // 1. Lấy dữ liệu gốc từ DB
            var allPending = _invoiceDAL.GetPendingInvoices(accountNumber, serviceTypeId);

            // 2. Lọc bỏ những hóa đơn nằm trong danh sách "Đã thanh toán ảo" (TempPaidBills)
            // Nhờ dòng lệnh này, cả ucInvoicePayment và ucPaymentElectricity đều sẽ tự động làm biến mất Card!
            var filteredList = allPending.Where(inv => !TempPaidBills.Contains(inv.BillCode)).ToList();

            return filteredList;
        }

        /// <summary>
        /// Get all invoices by account number
        /// </summary>
        public List<InvoiceDTO> GetInvoicesByAccount(string accountNumber)
        {
            try
            {
                var invoices = InvoiceDAL.GetInvoicesByAccount(accountNumber);
                return invoices.Select(i => new InvoiceDTO
                {
                    InvoiceID = i.InvoiceID,
                    AccountNumber = i.AccountNumber,
                    ProviderID = i.ProviderID,
                    ProviderName = i.ServiceProvider?.ProviderName ?? "N/A",
                    BillCode = i.BillCode,
                    Amount = i.Amount,
                    Status = i.Status,
                    DueDate = i.DueDate
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy dữ liệu thanh toán: " + ex.Message);
            }
        }
    }
}
