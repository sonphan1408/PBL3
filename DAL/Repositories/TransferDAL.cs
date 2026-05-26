using System;
using System.Linq;
using DTO.Models;
using DAL;

namespace DAL.Repositories
{
    public class TransferDAL
    {
        public AccountCustomerDTO GetAccountByAccountNumber(string accountNumber)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
                    if (account != null)
                    {
                        return new AccountCustomerDTO
                        {
                            AccountNumber = account.AccountNumber,
                            CustomerID = account.CustomerID,
                            Username = account.Username,
                            Password = account.Password,
                            Balance = (decimal)account.Balance,
                            Status = account.Status
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin tài khoản: " + ex.Message);
            }
        }

        public AccountCustomerDTO GetAccountByUsername(string username)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.Username == username);
                    if (account != null)
                    {
                        return new AccountCustomerDTO
                        {
                            AccountNumber = account.AccountNumber,
                            CustomerID = account.CustomerID,
                            Username = account.Username,
                            Password = account.Password,
                            Balance = (decimal)account.Balance,
                            Status = account.Status
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin tài khoản: " + ex.Message);
            }
        }

        public string GetCustomerNameByID(int customerID)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var customer = db.Customers.FirstOrDefault(c => c.CustomerID == customerID);
                    if (customer != null)
                    {
                        return customer.FullName;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tên khách hàng: " + ex.Message);
            }
        }

        public bool ExecuteTransfer(string senderAccountNumber, string recipientAccountNumber, decimal amount, string notes)
        {
            using (var db = new DigitalBankingDBEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // 1. Lấy tài khoản người gửi
                        var senderAccount = db.Accounts.FirstOrDefault(a => a.AccountNumber == senderAccountNumber);
                        if (senderAccount == null)
                            throw new Exception("Tài khoản người gửi không tồn tại");

                        decimal senderBalanceBefore = (decimal)senderAccount.Balance;

                        // 2. Lấy tài khoản người nhận
                        var recipientAccount = db.Accounts.FirstOrDefault(a => a.AccountNumber == recipientAccountNumber);
                        if (recipientAccount == null)
                            throw new Exception("Tài khoản người nhận không tồn tại");

                        decimal recipientBalanceBefore = (decimal)recipientAccount.Balance;

                        // 3. Trừ tiền người gửi, cộng tiền người nhận
                        senderAccount.Balance -= (decimal)amount;
                        recipientAccount.Balance += (decimal)amount;

                        // 4. Ghi bản ghi giao dịch vào InternalTransactions
                        var internalTransaction = new InternalTransaction
                        {
                            TransactionID  = Guid.NewGuid(),
                            TypeID         = 1, // 1 = chuyển khoản nội bộ
                            FromAccount    = senderAccountNumber,
                            ToAccount      = recipientAccountNumber,
                            Amount         = amount,
                            BalanceBefore  = senderBalanceBefore,
                            BalanceAfter   = (decimal)senderAccount.Balance,
                            Description    = string.IsNullOrWhiteSpace(notes) ? "Chuyển khoản" : notes,
                            CreatedAt      = DateTime.Now
                        };
                        db.InternalTransactions.Add(internalTransaction);

                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Lỗi khi thực hiện chuyển khoản: " + ex.Message);
                    }
                }
            }
        }
    }
}
