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

        public static List<string> TempPaidBills = new List<string>();

        public List<string> GetProviders(int serviceTypeId)
        {
            return _invoiceDAL.GetProviders(serviceTypeId);
        }
        // Ham xu ly thanh toan, tra ve thong diep loi neu co, neu thanh cong thi tra ve chuoi rong
        public string ProcessPayment(string inputPassword, string actualPassword, string targetCode, decimal amount, ref decimal currentBalance, string accountNumber = null, int invoiceId = 0)
        {
            // Kiem tra mat khau
            if (inputPassword != actualPassword)
            {
                return "Mật khẩu xác nhận không chính xác!";
            }

            // Kiem tra so du
            if (currentBalance < amount)
            {
                return "Số dư tài khoản không đủ để thực hiện giao dịch!";
            }

            // Tru tien truc tiep trong ham xu ly thanh toan de dam bao tinh nhat quan va dong bo
            currentBalance -= amount;

            // === CẬP NHẬT DATABASE ===
            // 1. Trừ tiền trong DB
            if (!string.IsNullOrEmpty(accountNumber))
            {
                try
                {
                    AccountService.DeductAccountBalance(accountNumber, amount);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi trừ tiền DB: " + ex.Message);
                }
            }

            // 2. Cập nhật trạng thái hóa đơn = "Paid" trong DB
            if (invoiceId > 0 && !string.IsNullOrEmpty(accountNumber))
            {
                try
                {
                    InvoiceDAL.PayInvoice(invoiceId, accountNumber);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi cập nhật Invoice: " + ex.Message);
                }
            }

            // Luu lai hoa don da duoc thanh toan vao danh sach tam thoi 
            if (!TempPaidBills.Contains(targetCode))
            {
                TempPaidBills.Add(targetCode);
            }

            return ""; 
        }

        // Ham lay danh sach hoa don dang cho xu ly, loai bo nhung hoa don da duoc thanh toan (co trong TempPaidBills)
        public List<InvoiceDTO> GetPendingInvoices(string accountNumber, int serviceTypeId)
        {
            var allPending = _invoiceDAL.GetPendingInvoices(accountNumber, serviceTypeId);

            // Loc bo nhung hoa don da duoc thanh toan (co trong TempPaidBills) de hien thi cho nguoi dung, tranh truong hop da thanh toan roi ma van hien thi trong danh sach dang cho xu ly
            var filteredList = allPending.Where(inv => !TempPaidBills.Contains(inv.BillCode)).ToList();

            return filteredList;
        }
        public List<InvoiceDTO> GetInvoicesByAccount(string accountNumber)
        {
            try
            {
                // 1. Lấy tất cả hóa đơn thực tế từ DB
                var invoices = InvoiceDAL.GetInvoicesByAccount(accountNumber);
                var resultList = invoices.Select(i => new InvoiceDTO
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

                // 2. Lấy các giao dịch nạp thẻ điện thoại từ InternalTransactions (TypeID = 4)
                var transactions = TransactionDAL.GetTransactionsByAccount(accountNumber, 100);
                int virtualId = 99999;
                foreach (var trans in transactions)
                {
                    // Lọc những giao dịch thanh toán nội bộ (TypeID = 4) và là nạp thẻ điện thoại
                    if (trans.TypeID == 4 && (trans.Description?.Contains("Nạp thẻ") == true || trans.Description?.Contains("nạp thẻ") == true))
                    {
                        resultList.Add(new InvoiceDTO
                        {
                            InvoiceID = virtualId--, // ID ảo giảm dần để tránh trùng lặp
                            AccountNumber = accountNumber,
                            ProviderID = 0,
                            ProviderName = "Nạp thẻ ĐT",
                            BillCode = "TOPUP",
                            Amount = trans.Amount,
                            Status = "Paid", // Giao dịch thành công chắc chắn đã thanh toán
                            DueDate = trans.CreatedAt
                        });
                    }
                }

                // Sắp xếp theo ngày thanh toán/ngày tạo giảm dần
                return resultList.OrderByDescending(i => i.DueDate ?? DateTime.MinValue).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy dữ liệu thanh toán: " + ex.Message);
            }
        }
        public string ProcessPhonePayment(string inputPassword, string actualPassword, string targetCode, decimal amount, ref decimal currentBalance, string accountNumber = null)
        {
            if (amount % 10000 != 0)
            {
                return $"Số tiền nạp ({amount.ToString("N0")} VND) không hợp lệ. Vui lòng nhập bội số của 10,000 VND (VD: 20000, 50000...).";
            }

            return ProcessPayment(inputPassword, actualPassword, targetCode, amount, ref currentBalance, accountNumber, 0);
        }
    }
}
