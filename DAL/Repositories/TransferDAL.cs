using System;
using System.Collections.Generic;
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
                accountNumber = accountNumber?.Trim() ?? "";

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

        public List<ExternalBankDTO> GetAllExternalBanks()
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var banks = db.ExternalBanks
                        .Select(b => new ExternalBankDTO
                        {
                            BankCode = b.BankCode,
                            BankName = b.BankName,
                            FullName = b.FullName
                        })
                        .ToList();
                    return banks;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách ngân hàng: " + ex.Message);
            }
        }

        public string GetExternalAccountName(string accountNumber, string bankCode)
        {
            try
            {
                accountNumber = accountNumber?.Trim() ?? "";
                bankCode = bankCode?.Trim() ?? "";

                using (var db = new DigitalBankingDBEntities())
                {
                    var mockAccount = db.Mock_Napas_Accounts.FirstOrDefault(
                        a => a.AccountNumber == accountNumber && a.BankCode == bankCode);

                    if (mockAccount != null)
                    {
                        return mockAccount.FullName;
                    }
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tên tài khoản: " + ex.Message);
            }
        }

        public AccountCustomerDTO GetRecipientByAccountNumberAndBank(string accountNumber, string bankCode)
        {
            try
            {
                accountNumber = accountNumber?.Trim() ?? "";

                // For HTTS Bank (internal transfer), search in internal accounts
                if (bankCode == "HTTS")
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
                else
                {
                    // For external banks, search in Mock_Napas_Accounts
                    using (var db = new DigitalBankingDBEntities())
                    {
                        var mockAccount = db.Mock_Napas_Accounts.FirstOrDefault(
                            a => a.AccountNumber == accountNumber && a.BankCode == bankCode);

                        if (mockAccount != null)
                        {
                            // Return a DTO with mock account info
                            return new AccountCustomerDTO
                            {
                                AccountNumber = mockAccount.AccountNumber,
                                CustomerID = 0, // Mock account doesn't have CustomerID
                                Username = "", // Mock account doesn't have username
                                Password = "",
                                Balance = 0, // External bank balance is not tracked
                                Status = "Active" // Assume mock accounts are always active
                            };
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm tài khoản: " + ex.Message);
            }
        }

        public bool ExecuteTransfer(string senderAccountNumber, string recipientAccountNumber, decimal amount, string notes, string bankCode = "HTTS")
        {
            using (var db = new DigitalBankingDBEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        senderAccountNumber = senderAccountNumber?.Trim() ?? "";
                        recipientAccountNumber = recipientAccountNumber?.Trim() ?? "";
                        bankCode = bankCode?.Trim() ?? "HTTS";

                        var senderAccount = db.Accounts.FirstOrDefault(a => a.AccountNumber == senderAccountNumber);
                        if (senderAccount == null)
                            throw new Exception("Tài khoản người gửi không tồn tại");

                        decimal senderBalanceBefore = (decimal)senderAccount.Balance;

                        if (bankCode == "HTTS")
                        {
                            // nội bộ
                            var recipientAccount = db.Accounts.FirstOrDefault(a => a.AccountNumber == recipientAccountNumber);
                            if (recipientAccount == null)
                                throw new Exception("Tài khoản người nhận không tồn tại");

                            decimal recipientBalanceBefore = (decimal)recipientAccount.Balance;

                            senderAccount.Balance -= (decimal)amount;
                            recipientAccount.Balance += (decimal)amount;

                            // 4. Ghi bản ghi giao dịch
                            var internalTransaction = new InternalTransaction
                            {
                                TransactionID = Guid.NewGuid(),
                                TypeID = 1, // 1 = chuyển khoản nội bộ
                                FromAccount = senderAccountNumber,
                                ToAccount = recipientAccountNumber,
                                Amount = amount,
                                BalanceBefore = senderBalanceBefore,
                                BalanceAfter = (decimal)senderAccount.Balance,
                                Description = string.IsNullOrWhiteSpace(notes) ? "Chuyển khoản nội bộ" : notes,
                                CreatedAt = DateTime.Now
                            };
                            db.InternalTransactions.Add(internalTransaction);
                        }
                        else
                        {
                            // LNH (trừ tiền ng gửi)
                            senderAccount.Balance -= (decimal)amount;

                            // Lấy tên người nhận từ Mock
                            var mockAccount = db.Mock_Napas_Accounts.FirstOrDefault(
                                a => a.AccountNumber == recipientAccountNumber && a.BankCode == bankCode);
                            string recipientName = mockAccount?.FullName ?? "Unknown";

                            //Ghi bản ghi giao dịch
                            var externalTransaction = new ExternalTransaction
                            {
                                TransactionID = Guid.NewGuid(),
                                FromAccount = senderAccountNumber,
                                ReceiverAccount = recipientAccountNumber,
                                ReceiverName = recipientName,
                                BankCode = bankCode,
                                Amount = amount,
                                BalanceBefore = senderBalanceBefore,
                                BalanceAfter = (decimal)senderAccount.Balance,
                                Status = "Pending", // Chờ xử lý từ ngân hàng
                                TraceNumber = Guid.NewGuid().ToString().Substring(0, 10).ToUpper(),
                                Description = string.IsNullOrWhiteSpace(notes) ? "Chuyển khoản liên ngân hàng" : notes,
                                CreatedAt = DateTime.Now
                            };
                            db.ExternalTransactions.Add(externalTransaction);
                        }

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
