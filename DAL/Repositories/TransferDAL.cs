using System;
using System.Linq;
using DTO.Models;

namespace DAL.Repositories
{
    public class TransferDAL
    {
        public AccountDTO GetAccountByAccountNumber(string accountNumber)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
                    if (account != null)
                    {
                        return new AccountDTO
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

        public AccountDTO GetAccountByUsername(string username)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.Username == username);
                    if (account != null)
                    {
                        return new AccountDTO
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
                        // 1. Deduct from sender account
                        var senderAccount = db.Accounts.FirstOrDefault(a => a.AccountNumber == senderAccountNumber);
                        if (senderAccount == null)
                            throw new Exception("Tài khoản người gửi không tồn tại");

                        senderAccount.Balance -= (decimal)amount;

                        // 2. Add to recipient account
                        var recipientAccount = db.Accounts.FirstOrDefault(a => a.AccountNumber == recipientAccountNumber);
                        if (recipientAccount == null)
                            throw new Exception("Tài khoản người nhận không tồn tại");

                        recipientAccount.Balance += (decimal)amount;

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
