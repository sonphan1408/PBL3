using DAL.Core;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DAL.Repositories
{
    public class AuthDAL
    {
        public static string Login(string username, string password)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a=> a.Username == username && a.Password == password);
                    if(account != null) return "Customer";

                    var employ = db.Employees.FirstOrDefault(e => e.Username == username && e.Password == password);
                    if(employ != null) return employ.Role;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng nhập: " + ex.Message);
            }
        }

        public static AccountDTO GetAccountByUsername(string username)
        {
            try
            {
                using(var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.Username == username);
                    if(account != null)
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

        public static bool UsernameExists(string username)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    return db.Accounts.Any(a => a.Username == username);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra username: " + ex.Message);
            }
        }

        public static bool PhoneExists(string phone)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    return db.Customers.Any(c => c.PhoneNumber == phone);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra số điện thoại: " + ex.Message);
            }
        }

        public string RegisterCustomerAndAccount(CustomerDTO customer, AccountDTO account)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Tạo và lưu Customer mới
                            var newCustomer = new Customer
                            {
                                FullName = customer.FullName,
                                Gender = customer.Gender,
                                DateOfBirth = customer.DateOfBirth,
                                Address = customer.Address,
                                PhoneNumber = customer.PhoneNumber,
                                Email = customer.Email,
                                IDCard = customer.IDCard,
                                CCCD = customer.CCCD
                            };

                            db.Customers.Add(newCustomer);
                            db.SaveChanges();

                            int newCustomerId = newCustomer.CustomerID;

                            // 2. Tạo và lưu Account mới
                            string newAccountNumber = "8888000" + newCustomerId.ToString();
                            var newAccount = new Account
                            {
                                AccountNumber = newAccountNumber,
                                CustomerID = newCustomerId,
                                Username = account.Username,
                                Password = account.Password,
                                Balance = 0,
                                Status = "Active"
                            };

                            db.Accounts.Add(newAccount);
                            db.SaveChanges();

                            transaction.Commit();
                            return newAccountNumber;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Lỗi Database: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi đăng ký tài khoản: " + ex.Message);
            }
        }
    }
}