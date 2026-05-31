using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Core;

namespace DAL.Repositories
{
    public class InvoiceDAL
    {
        public List<InvoiceDTO> GetPendingInvoices(string accountNumber, int serviceTypeId)
        {
            using (var db = new DigitalBankingDBEntities())
            {
                // Dung linq de lay danh sach hoa don chua thanh toan theo account va service type, sau do map sang DTO
                var result = db.Invoices
                    .Where(i => i.AccountNumber == accountNumber
                             && (i.Status == "Unpaid" || i.Status == "Overdue")
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
                        ProviderName = i.ServiceProvider.ProviderName 
                    })
                    .ToList();

                return result;
            }
        }


        public List<string> GetProviders(int serviceTypeId)
        {
            using (var db = new DigitalBankingDBEntities())
            {
                return db.ServiceProviders
                         .Where(p => p.ServiceTypeID == serviceTypeId)
                         .Select(p => p.ProviderName)
                         .ToList();
            }
        }

        public static List<Invoice> GetInvoicesByAccount(string accountNumber)
        {
            using (var context = new DigitalBankingDBEntities())
            {
                return context.Invoices.Include("ServiceProvider").Where(i => i.AccountNumber == accountNumber).ToList();
            }
        }

        public static bool PayInvoice(int invoiceID, string accountNumber)
        {
            try
            {
                using (var context = new DigitalBankingDBEntities())
                {
                    var invoice = context.Invoices.FirstOrDefault(i => i.InvoiceID == invoiceID && i.AccountNumber == accountNumber);
                    if (invoice != null)
                    {
                        invoice.Status = "PAID";
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
