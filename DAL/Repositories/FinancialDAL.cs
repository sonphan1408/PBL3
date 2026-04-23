using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace DAL.Repositories
{
    public class FinancialDAL
    {
        //public static List<FinancialProductDTO> GetSavingsByCustomer(int customerId)
        //{
        //    try
        //    {
        //        using (var db = new DigitalBankingDBEntities())
        //        {
        //            var accountNumbers = db.Accounts
        //                .Where(a => a.CustomerID == customerId)
        //                .Select(a => a.AccountNumber)
        //                .ToList();

        //            var savings = db.FinancialProducts
        //                .Where(p => accountNumbers.Contains(p.AccountNumber) && p.Category == "Saving")
        //                .Select(p => new FinancialProductDTO
        //                {
        //                    ProductID = p.ProductID,
        //                    ProductName = "Account " + p.AccountNumber,
        //                    AccountNumber = p.AccountNumber,
        //                    Amount = p.PrincipalAmount,
        //                    InterestRate = p.InterestRate,
        //                    Status = p.Status
        //                })
        //                .ToList();

        //            return savings;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi lấy danh sách tiết kiệm: " + ex.Message);
        //    }
        //}

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

                    var totalSavings = db.FinancialProducts
                        .Where(p => accountNumbers.Contains(p.AccountNumber) && 
                                    p.Category == "Saving" && 
                                    p.Status == "Active")
                        .Sum(p => (decimal?)p.PrincipalAmount) ?? 0m;

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

                    var totalLoans = db.FinancialProducts
                        .Where(p => accountNumbers.Contains(p.AccountNumber) && 
                                    p.Category == "Loan" && 
                                    p.Status == "Active")
                        .Sum(p => (decimal?)p.PrincipalAmount) ?? 0m;

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

                    return db.FinancialProducts
                        .Where(p => accountNumbers.Contains(p.AccountNumber) && 
                                    p.Category == "Saving" && 
                                    p.Status == "Active")
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

                    return db.FinancialProducts
                        .Where(p => accountNumbers.Contains(p.AccountNumber) && 
                                    p.Category == "Loan" && 
                                    p.Status == "Active")
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
                            .ToList()  // Execute query FIRST, then map in memory
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
   
