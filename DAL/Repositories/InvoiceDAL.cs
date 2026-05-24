using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class InvoiceDAL
    {
        public List<InvoiceDTO> GetPendingInvoices(string accountNumber, int serviceTypeId)
        {
            using (var db = new DigitalBankingDBEntities())
            {
                // Dùng LINQ lọc dữ liệu và map thẳng vào DTO
                var result = db.Invoices
                    .Where(i => i.AccountNumber == accountNumber
                             && i.Status == "Unpaid"
                             && i.ServiceProvider.ServiceTypeID == serviceTypeId)
                    .Select(i => new InvoiceDTO
                    {
                        InvoiceID = i.InvoiceID,
                        AccountNumber = i.AccountNumber,
                        ProviderID = i.ProviderID,
                        BillCode = i.BillCode,
                        Amount = i.Amount,
                        Status = i.Status,
                        DueDate = i.DueDate,
                        ProviderName = i.ServiceProvider.ProviderName // Lấy từ bảng liên kết
                    })
                    .ToList();

                return result;
            }
        }
        // Viết vào bên trong class ở tầng DAL của bạn
        public List<string> GetProviders(int serviceTypeId)
        {
            // Tầng DAL đã có sẵn Entity Framework nên viết bằng db thoải mái
            using (var db = new DigitalBankingDBEntities())
            {
                return db.ServiceProviders
                         .Where(p => p.ServiceTypeID == serviceTypeId)
                         .Select(p => p.ProviderName)
                         .ToList();
            }
        }
    }
}
