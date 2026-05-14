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
        public static List<Invoice> GetInvoicesByAccount(string accountNumber)
        {
            using (var context = new DigitalBankingDBEntities())
            {
                // return context.Invoices.Where(i => i.AccountNumber == accountNumber).ToList();
                // Need Include Provider to get Name
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
