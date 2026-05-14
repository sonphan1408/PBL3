using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PaymentService
    {
        public static List<DTO.Models.InvoiceDTO> GetInvoicesByAccount(string accountNumber)
        {
            var invoices = DAL.Repositories.InvoiceDAL.GetInvoicesByAccount(accountNumber);
            return invoices.Select(i => new DTO.Models.InvoiceDTO
            {
                InvoiceID = i.InvoiceID,
                AccountNumber = i.AccountNumber,
                ProviderID = i.ProviderID,
                ProviderName = i.ServiceProvider?.ProviderName,
                BillCode = i.BillCode,
                Amount = i.Amount,
                Status = i.Status,
                DueDate = i.DueDate ?? DateTime.MinValue,
            }).ToList();
        }
    }
}
