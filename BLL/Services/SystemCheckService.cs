using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class SystemCheckService
    {
        public static void PerformPostLoginChecks(int customerId, string username)
        {
            try
            {
                var notifications = new List<string>();

                // 1. Check Overdue Invoices
                var invoiceNotifs = SystemCheckDAL.CheckAndUpdateOverdueInvoices(customerId);
                notifications.AddRange(invoiceNotifs);

                // 2. Check Overdue Loans
                var loanNotifs = SystemCheckDAL.CheckAndUpdateOverdueLoans(customerId);
                notifications.AddRange(loanNotifs);

                // 3. Process Matured Savings
                var savingNotifs = SystemCheckDAL.CheckAndProcessMaturedSavings(customerId);
                notifications.AddRange(savingNotifs);

                // Send notifications
                foreach (var msg in notifications)
                {
                    NotificationService.CreateNotification(username, msg, "System");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in PerformPostLoginChecks: " + ex.Message);
            }
        }
    }
}
