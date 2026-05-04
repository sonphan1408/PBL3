using DAL.Core;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                    // Tìm tài khoản khách hàng khớp user, pass và phải đang hoạt động (Active)
                    var account = db.Accounts.FirstOrDefault(a => a.Username == username
                                                               && a.Password == password
                                                               && a.Status == "Active");

                    // Nếu tìm thấy, tạo mới một CustomerDTO để hứng dữ liệu và trả về
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
                            MessageBox.Show("Lỗi Database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public AccountEmployeeDTO LoginEmployee(string username, string password)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var employee = db.Employees.FirstOrDefault(e => e.Username == username && e.Password == password);
                    if (employee != null)
                    {
                        return new AccountEmployeeDTO
                        {
                            EmployeeID = employee.EmployeeID.ToString(),
                            FullName = employee.FullName,
                            Username = employee.Username,
                            Password = employee.Password,
                            Role = employee.Role
                        };
                    }
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

