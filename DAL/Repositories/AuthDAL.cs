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
        public static AccountCustomerDTO LoginCustomer(string username, string password)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    // Tim tai khoan trong database voi username, password va status la "Active"
                    var account = db.Accounts.FirstOrDefault(a => a.Username == username
                                                               && a.Password == password
                                                               && a.Status == "Active");

                    // Neu tim thay tai khoan, tra ve AccountCustomerDTO, nguoc lai tra ve null
                    if (account != null)
                    {
                        return new AccountCustomerDTO
                        {
                            AccountNumber = account.AccountNumber,
                            Username = account.Username,
                            Role = "Customer", 
                            Balance = account.Balance ?? 0, 
                            Status = account.Status,
                            CustomerID = account.CustomerID

                        };
                    }

                    
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng nhập Khách hàng: " + ex.Message);
            }
        }

        public static AccountCustomerDTO GetAccountByUsername(string username)
        {
            try
            {
                using(var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.Username == username);
                    if(account != null)
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

        public void RegisterCustomerAndAccount(CustomerDTO customer, AccountCustomerDTO account)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            // tao moi doi tuong Customer moi va gan gia tri tu customerDTO
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

                            var newAccount = new Account
                            {
                                CustomerID = newCustomer.CustomerID,
                                Username = account.Username,
                                Password = account.Password,
                                AccountNumber = "ACC" + DateTime.Now.Ticks.ToString().Substring(0, 12),
                                Balance = 0,
                                Status = "Active",
                                CreatedAt = DateTime.Now
                            };

                            db.Accounts.Add(newAccount);
                            db.SaveChanges();

                            transaction.Commit();
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
                throw new Exception("Lỗi khi đăng ký tài khoản: " + ex.Message);
            }
        }

        public AccountEmployeeDTO LoginEmployee(string username, string password)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng nhập nhân viên: " + ex.Message);
            }
        }
        }
    }

