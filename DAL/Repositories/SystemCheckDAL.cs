using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class SystemCheckDAL
    {
        public static List<string> CheckAndUpdateOverdueInvoices(int customerId)
        {
            var notifications = new List<string>();
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var accountNumbers = db.Accounts.Where(a => a.CustomerID == customerId).Select(a => a.AccountNumber).ToList();
                    var today = DateTime.Now.Date;

                    var overdueInvoices = db.Invoices.Include("ServiceProvider")
                        .Where(i => accountNumbers.Contains(i.AccountNumber) && i.Status == "Unpaid" && i.DueDate < today)
                        .ToList();

                    foreach (var invoice in overdueInvoices)
                    {
                        invoice.Status = "Overdue";
                        string providerName = invoice.ServiceProvider != null ? invoice.ServiceProvider.ProviderName : "Không xác định";
                        notifications.Add($"Hóa đơn {invoice.BillCode} (Dịch vụ: {providerName}) đã quá hạn thanh toán. Vui lòng thanh toán sớm.");
                    }

                    if (overdueInvoices.Any())
                    {
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in CheckAndUpdateOverdueInvoices: " + ex.Message);
            }
            return notifications;
        }

        public static List<string> CheckAndUpdateOverdueLoans(int customerId)
        {
            var notifications = new List<string>();
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var accountNumbers = db.Accounts.Where(a => a.CustomerID == customerId).Select(a => a.AccountNumber).ToList();
                    var today = DateTime.Now.Date;

                    var loanContractIds = db.LoanContracts
                        .Where(c => accountNumbers.Contains(c.AccountNumber))
                        .Select(c => c.ContractID)
                        .ToList();

                    var overdueSchedules = db.LoanSchedules
                        .Where(s => loanContractIds.Contains(s.ContractID) && s.Status == "Pending" && s.DueDate < today)
                        .ToList();

                    foreach (var schedule in overdueSchedules)
                    {
                        schedule.Status = "Overdue";
                        string dateStr = schedule.DueDate.ToString("dd/MM/yyyy");
                        notifications.Add($"Kỳ trả nợ khoản vay {schedule.ContractID} (Hạn chót: {dateStr}) đã quá hạn!");
                    }

                    if (overdueSchedules.Any())
                    {
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in CheckAndUpdateOverdueLoans: " + ex.Message);
            }
            return notifications;
        }

        public static List<string> CheckAndProcessMaturedSavings(int customerId)
        {
            var notifications = new List<string>();
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var accounts = db.Accounts.Where(a => a.CustomerID == customerId).ToList();
                    var accountNumbers = accounts.Select(a => a.AccountNumber).ToList();
                    var today = DateTime.Now.Date;

                    var maturedSavings = db.SavingContracts
                        .Where(s => accountNumbers.Contains(s.AccountNumber) && s.Status == "Active" && s.EndDate <= today)
                        .ToList();

                    foreach (var saving in maturedSavings)
                    {
                        // Update account balance
                        var account = accounts.FirstOrDefault(a => a.AccountNumber == saving.AccountNumber);
                        if (account != null)
                        {
                            decimal totalAmount = saving.CurrentBalance + (decimal)(saving.AccruedInterest ?? 0);
                            account.Balance += totalAmount;

                            saving.CurrentBalance = 0;
                            saving.Status = "Closed";

                            // Ghi lại log SavingTransaction
                            db.SavingTransactions.Add(new SavingTransaction
                            {
                                ContractID = saving.ContractID,
                                TransactionType = "Tất toán",
                                Amount = totalAmount,
                                TransactionDate = DateTime.Now,
                                Notes = "Tất toán sổ tiết kiệm đến hạn"
                            });

                            notifications.Add($"Sổ tiết kiệm {saving.ContractID} đã đáo hạn. Số tiền {totalAmount:N0} VND đã được chuyển vào tài khoản chính.");
                        }
                    }

                    if (maturedSavings.Any())
                    {
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in CheckAndProcessMaturedSavings: " + ex.Message);
            }
            return notifications;
        }
    }
}
