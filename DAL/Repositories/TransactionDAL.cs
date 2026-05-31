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
                    var internalTrans = db.InternalTransactions
                        .Where(t => t.FromAccount == accountNumber || t.ToAccount == accountNumber)
                        .ToList()
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

                    var externalTrans = db.ExternalTransactions
                        .Where(t => t.FromAccount == accountNumber || t.ReceiverAccount == accountNumber)
                        .ToList()
                        .Select(t => new ExternalTransactionDTO
                        {
                            TransactionID = t.TransactionID,
                            FromAccount = t.FromAccount,
                            ReceiverAccount = t.ReceiverAccount,
                            BankCode = t.BankCode,
                            Status = t.Status,
                            TraceNumber = t.TraceNumber,
                            ReceiverName = t.ReceiverName,
                            ToAccount = t.ReceiverAccount,
                            TypeID = 3,
                            Amount = t.Amount,
                            BalanceBefore = t.BalanceBefore ?? 0m,
                            BalanceAfter = t.BalanceAfter ?? 0m,
                            Description = t.Description,
                            CreatedAt = t.CreatedAt ?? DateTime.Now
                        })
                        .Cast<TransactionDTO>()
                        .ToList();

                    var allTransactions = internalTrans.Concat(externalTrans)
                        .OrderByDescending(t => t.CreatedAt)
                        .Take(limit)
                        .ToList();

                    return allTransactions;
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
                    decimal internalIncome = db.InternalTransactions
                        .Where(t => t.ToAccount == accountNumber && t.FromAccount != accountNumber)
                        .Sum(t => (decimal?)t.Amount) ?? 0m;
                        
                    decimal externalIncome = db.ExternalTransactions
                        .Where(t => t.ReceiverAccount == accountNumber && t.FromAccount != accountNumber)
                        .Sum(t => (decimal?)t.Amount) ?? 0m;
                        
                    return internalIncome + externalIncome;
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
                    decimal internalExpense = db.InternalTransactions
                        .Where(t => t.FromAccount == accountNumber && t.ToAccount != accountNumber)
                        .Sum(t => (decimal?)t.Amount) ?? 0m;
                        
                    decimal externalExpense = db.ExternalTransactions
                        .Where(t => t.FromAccount == accountNumber && t.ReceiverAccount != accountNumber)
                        .Sum(t => (decimal?)t.Amount) ?? 0m;
                        
                    return internalExpense + externalExpense;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tính tổng chi tiêu: " + ex.Message);
            }
        }
        public static bool CreateExternalTransaction(ExternalTransactionDTO transaction)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var newTrans = new ExternalTransaction
                    {
                        TransactionID = transaction.TransactionID == Guid.Empty ? Guid.NewGuid() : transaction.TransactionID,
                        FromAccount = transaction.FromAccount,
                        ReceiverAccount = transaction.ReceiverAccount,
                        ReceiverName = transaction.ReceiverName,
                        BankCode = transaction.BankCode,
                        Amount = transaction.Amount,
                        BalanceBefore = transaction.BalanceBefore,
                        BalanceAfter = transaction.BalanceAfter,
                        Status = transaction.Status ?? "Success",
                        TraceNumber = transaction.TraceNumber ?? Guid.NewGuid().ToString().Substring(0, 10).ToUpper(),
                        Description = transaction.Description,
                        CreatedAt = transaction.CreatedAt == default ? DateTime.Now : transaction.CreatedAt
                    };
                    db.ExternalTransactions.Add(newTrans);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo giao dịch liên ngân hàng: " + ex.Message);
            }
        }

        public static List<ExternalTransactionDTO> GetPaymentTransactionsByAccount(string accountNumber)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var trans = db.ExternalTransactions
                        .Where(t => t.FromAccount == accountNumber && t.BankCode == "PAYMENT")
                        .OrderByDescending(t => t.CreatedAt)
                        .Select(t => new ExternalTransactionDTO
                        {
                            TransactionID = t.TransactionID,
                            FromAccount = t.FromAccount,
                            ReceiverAccount = t.ReceiverAccount,
                            ReceiverName = t.ReceiverName,
                            BankCode = t.BankCode,
                            Amount = t.Amount,
                            BalanceBefore = t.BalanceBefore ?? 0m,
                            BalanceAfter = t.BalanceAfter ?? 0m,
                            Status = t.Status,
                            TraceNumber = t.TraceNumber,
                            Description = t.Description,
                            CreatedAt = t.CreatedAt ?? DateTime.Now
                        })
                        .ToList();
                    return trans;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy lịch sử thanh toán: " + ex.Message);
            }
        }

        public static bool CreateInternalTransaction(InternalTransactionDTO transaction)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var internalTx = new InternalTransaction
                    {
                        TransactionID = transaction.TransactionID == Guid.Empty ? Guid.NewGuid() : transaction.TransactionID,
                        FromAccount = transaction.FromAccount,
                        ToAccount = transaction.ToAccount,
                        TypeID = transaction.TypeID,
                        Amount = transaction.Amount,
                        BalanceBefore = transaction.BalanceBefore,
                        BalanceAfter = transaction.BalanceAfter,
                        Description = transaction.Description,
                        CreatedAt = transaction.CreatedAt == default ? DateTime.Now : transaction.CreatedAt
                    };
                    db.InternalTransactions.Add(internalTx);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error saving internal transaction: " + ex.Message);
                return false;
            }
        }
    }
}
