using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace DAL.Repositories
{
    public class FinancialDAL
    {
        public static List<SavingContractsDTO> GetSavingsByCustomer(int customerId)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var accountNumbers = db.Accounts
                        .Where(a => a.CustomerID == customerId)
                        .Select(a => a.AccountNumber)
                        .ToList();

                    var savings = db.SavingContracts
                        .Where(s => accountNumbers.Contains(s.AccountNumber) && s.Status == "Active")
                        .Select(s => new SavingContractsDTO
                        {
                            ContractID = s.ContractID,
                            AccountNumber = s.AccountNumber,
                            PrincipalAmount = s.PrincipalAmount,
                            SavingType = s.SavingTypes,
                            InterestRate = s.InterestRate,
                            Status = s.Status,
                            StartDate = s.StartDate,
                            EndDate = s.EndDate
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

                    return db.SavingContracts
                        .Where(s => accountNumbers.Contains(s.AccountNumber) &&
                                    s.Status == "Active")
                        .Count();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đếm tài khoản tiết kiệm: " + ex.Message);
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
      
       
    }
}
   
