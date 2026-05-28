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
        public string ProcessPayment(string inputPassword, string actualPassword, string targetCode, decimal amount, ref decimal currentBalance)
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
        public string ProcessPhonePayment(string inputPassword, string actualPassword, string targetCode, decimal amount, ref decimal currentBalance)
        {
            if (amount % 10000 != 0)
            {
                return $"Số tiền nạp ({amount.ToString("N0")} VND) không hợp lệ. Vui lòng nhập bội số của 10,000 VND (VD: 20000, 50000...).";
            }

            return ProcessPayment(inputPassword, actualPassword, targetCode, amount, ref currentBalance);
        }
    }
}
