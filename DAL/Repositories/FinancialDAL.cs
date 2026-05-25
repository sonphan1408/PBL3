using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace DAL.Repositories
{
    public class FinancialDAL
    {
        public static List<SavingContractsDTO> GetSavingsByAccountNumber(string accountNumber)
        {
            try
            {
                
             
                using (var db = new DigitalBankingDBEntities())
                {
                    var savings = db.SavingContracts
                        .Where(s => s.AccountNumber == accountNumber && s.Status == "Active")
                        .OrderByDescending(s => s.StartDate)
                        .Select(s => new SavingContractsDTO
                        {
                            ContractID = s.ContractID,
                            AccountNumber = s.AccountNumber,
                            PrincipalAmount = s.PrincipalAmount,
                            TermMonths = s.TermMonths,
                            SavingType = s.SavingTypes,
                            InterestRate = s.InterestRate,
                            AccruedInterest = s.AccruedInterest ?? 0m,
                            Status = s.Status,
                            CurrentBalance = s.CurrentBalance,
                            Goal = s.Goal,
                            StartDate = s.StartDate,
                            EndDate = s.EndDate,
                          
                           
                            
                        })
                        .ToList();

                    return savings;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách tiết kiệm: " + ex.Message);
            }
        }

        public static decimal GetTotalSavings(int customerId)
        {
            try
            {

                
                using (var db = new DigitalBankingDBEntities())
                {
                    var accountNumbers = db.Accounts
                        .Where(a => a.CustomerID == customerId)
                        .Select(a => a.AccountNumber)
                        .ToList();

                    var totalSavings = db.SavingContracts
                        .Where(s => accountNumbers.Contains(s.AccountNumber) &&
                                    s.Status == "Active")
                        .Sum(s => (decimal?)s.PrincipalAmount) ?? 0m;

                    return totalSavings;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tính tổng tiết kiệm: " + ex.Message);
            }
        }

        public static decimal GetTotalLoans(int customerId)
        {
            try
            {
                
                
                using (var db = new DigitalBankingDBEntities())
                {
                    var accountNumbers = db.Accounts
                        .Where(a => a.CustomerID == customerId)
                        .Select(a => a.AccountNumber)
                        .ToList();

                    var totalLoans = db.LoanContracts
                        .Where(l => accountNumbers.Contains(l.AccountNumber) &&
                                    l.Status == "Active")
                        .Sum(l => (decimal?)l.RemainingBalance) ?? 0m;

                    return totalLoans;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tính tổng khoản vay: " + ex.Message);
            }
        }

        public static int GetTotalSavingsAccounts(int customerId)
        {
            try
            {
                

                
                using (var db = new DigitalBankingDBEntities())
                {
                    var accountNumbers = db.Accounts
                        .Where(a => a.CustomerID == customerId)
                        .Select(a => a.AccountNumber)
                        .ToList();

                    if (accountNumbers.Count == 0)
                    {
                        return 0; // No accounts found
                    }

                    return db.SavingContracts
                        .Where(s => accountNumbers.Contains(s.AccountNumber) &&
                                    s.Status == "Active")
                        .Count();
                }
                
            }
            catch (Exception ex)
            {
                // Log the full exception details for debugging
                System.Diagnostics.Debug.WriteLine("FinancialDAL.GetTotalSavingsAccounts Error: " + ex.ToString());
                throw new Exception("Lỗi khi đếm tài khoản tiết kiệm: " + ex.Message + "\n\nInner: " + (ex.InnerException?.Message ?? "No inner exception"), ex);
            }
        }

        public static int GetTotalLoanAccounts(int customerId)
        {
            try
            {
               
                using (var db = new DigitalBankingDBEntities())
                {
                    var accountNumbers = db.Accounts
                        .Where(a => a.CustomerID == customerId)
                        .Select(a => a.AccountNumber)
                        .ToList();

                    return db.LoanContracts
                        .Where(l => accountNumbers.Contains(l.AccountNumber) &&
                                    l.Status == "Active")
                        .Count();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đếm khoản vay: " + ex.Message);
            }
        }


        public static List<InterestRateDTO> GetInterestRatesByCategory(string category)
        {
            try
            {

                using (var db = new DigitalBankingDBEntities())
                {
                    return db.InterestRates
                        .Where(r => r.Category == category)
                        .OrderBy(r => r.TermMonths)
                        .ToList()
                        .Select(r => new InterestRateDTO
                        {
                            RateID = r.RateID,
                            Category = r.Category,
                            TermMonths = r.TermMonths.GetValueOrDefault(0),
                            RateValue = (decimal)(r.RateValue ?? 0m)
                        })
                        .ToList();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy lãi suất theo danh mục: " + ex.Message);
            }
        }

        public static decimal GetExactRateValue(string category, int termMonths)
        {
            try
            {
                
                using (var db = new DigitalBankingDBEntities())
                {
                    var rate = db.InterestRates
                        .FirstOrDefault(r => r.Category == category && r.TermMonths == termMonths);

                    if (rate != null)
                    {
                        return rate.RateValue ?? 0m;
                    }
                    return 0m;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm lãi suất: " + ex.Message);
            }
        }

        public static bool CreateSavingAccount(SavingContractsDTO savingContract)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var newContract = new SavingContract
                    {
                        ContractID = savingContract.ContractID,
                        AccountNumber = savingContract.AccountNumber,
                        PrincipalAmount = savingContract.PrincipalAmount,
                        InterestRate = savingContract.InterestRate,
                        StartDate = savingContract.StartDate,
                        EndDate = savingContract.EndDate,
                        CurrentBalance = savingContract.CurrentBalance,
                        AccruedInterest = savingContract.AccruedInterest,
                        Status = savingContract.Status,
                        Goal = savingContract.Goal,
                        TermMonths = savingContract.TermMonths,
                        SavingTypes = savingContract.SavingType
                    };

                    db.SavingContracts.Add(newContract);
                    db.SaveChanges();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo tài khoản tiết kiệm: " + ex.Message);

            }
        }

        public static bool CreateSavingTransaction(string contractID, string transactionType, decimal amount, string notes)
        {
            try
            {
               
                using (var db = new DigitalBankingDBEntities())
                {
                    var newTransaction = new SavingTransaction
                    {
                        ContractID = contractID,
                        TransactionType = transactionType,
                        Amount = amount,
                        TransactionDate = DateTime.Now,
                        Notes = notes
                    };

                    db.SavingTransactions.Add(newTransaction);
                    db.SaveChanges();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo ghi chép tiết kiệm: " + ex.Message);
            }
        }
        public static dynamic GetSavingTransactions(string contractId, DateTime fromDate, DateTime toDate)
        {
            using (var db = new DigitalBankingDBEntities())
            {
                // Chuẩn hóa ngày: 00:00:00 ngày bắt đầu -> 23:59:59 ngày kết thúc
                DateTime start = fromDate.Date;
                DateTime end = toDate.Date.AddDays(1).AddTicks(-1);

                var list = db.SavingTransactions
                    .Where(t => t.ContractID == contractId
                             && t.TransactionDate >= start
                             && t.TransactionDate <= end)
                    .OrderByDescending(t => t.TransactionDate)
                    .Select(t => new SavingTransactionDTO
                    {
                        TransactionID = t.TransactionID,
                        TransactionDate = t.TransactionDate ?? DateTime.Now,
                        TransactionType = t.TransactionType, // Ví dụ: Gửi thêm, Rút gốc, Nhận lãi
                        Amount = t.Amount,
                        Note = t.Notes
                    })
                    .ToList();

                return list;
            }
        }
        public static bool UpdateFinalSettlement(string contractId, decimal finalAmount, decimal accruedInterest, DateTime endDate)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var contract = db.SavingContracts.FirstOrDefault(s => s.ContractID == contractId);
                    if (contract != null && contract.Status == "Active")
                    {
                        contract.CurrentBalance = 0m;
                        contract.Status = "Closed";
                        contract.EndDate = endDate;
                        contract.AccruedInterest = accruedInterest;
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tất toán tiết kiệm: " + ex.Message);
            }


        }
        public static bool UpdateDeposit(string contractId, decimal depositAmount, decimal newInterest)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var contract = db.SavingContracts.FirstOrDefault(s => s.ContractID == contractId);
                    if (contract != null && contract.Status == "Active")
                    {
                        contract.CurrentBalance += depositAmount;
                       
                        
                        contract.AccruedInterest += newInterest;
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tất toán tiết kiệm: " + ex.Message);
            }

        }
       
    }
}


