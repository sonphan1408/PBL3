using System;
using System.Collections.Generic;
using System.Linq;
using DTO.Models;

namespace DAL.Repositories
{
    public class TransactionDAL
    {
        public static List<TransactionDTO> GetTransactionsByAccount(string accountNumber, int limit = 10)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var transactions = db.InternalTransactions
                        .Where(t => t.FromAccount == accountNumber || t.ToAccount == accountNumber)
                        .OrderByDescending(t => t.CreatedAt)
                        .Take(limit)
                        .ToList()  // Execute query FIRST, then map in memory
                        .Select(t => new InternalTransactionDTO
                        {
                            TransactionID = t.TransactionID,
                            FromAccount = t.FromAccount,
                            ToAccount = t.ToAccount,
                            TypeID = t.TypeID,
                            Amount = t.Amount,
                            BalanceBefore = t.BalanceBefore.GetValueOrDefault(0),
                            BalanceAfter = t.BalanceAfter.GetValueOrDefault(0),
                            Description = t.Description,
                            CreatedAt = t.CreatedAt ?? DateTime.Now
                        })
                        .Cast<TransactionDTO>()
                        .ToList();

                    return transactions;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("InternalTransaction"))
                {
                    System.Diagnostics.Debug.WriteLine("TABLE NOT FOUND: InternalTransactions does not exist in the database.");
                    return new List<TransactionDTO>();
                }
                throw new Exception("Lỗi khi lấy lịch sử giao dịch: " + ex.Message);
            }
        }

        public static decimal GetTotalIncome(string accountNumber)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    return db.InternalTransactions
                        .Where(t => t.ToAccount == accountNumber)
                        .Sum(t => (decimal?)t.Amount) ?? 0m;
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("TABLE NOT FOUND: InternalTransactions does not exist");
                return 0;
            }
        }

        public static decimal GetTotalExpense(string accountNumber)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    return db.InternalTransactions
                        .Where(t => t.FromAccount == accountNumber)
                        .Sum(t => (decimal?)t.Amount) ?? 0m;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tính tổng chi tiêu: " + ex.Message);
            }
        }

            }
        }
