using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class AccountDAL
    {
        public static AccountCustomerDTO GetAccountByUsername(string username)
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

        public static CustomerDTO GetCustomerInfo(int customerId)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var customer = db.Customers.FirstOrDefault(c => c.CustomerID == customerId);
                    if (customer != null)
                    {
                        return new CustomerDTO
                        {
                            CustomerID = customer.CustomerID,
                            FullName = customer.FullName,
                            Gender = customer.Gender,
                            DateOfBirth = (DateTime)customer.DateOfBirth,
                            Address = customer.Address,
                            PhoneNumber = customer.PhoneNumber,
                            Email = customer.Email,
                            AvatarPath = customer.AvatarPath
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin khách hàng: " + ex.Message);
            }
        }

        public static List<AccountCustomerDTO> GetAccountsByCustomer(int customerId)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var accounts = db.Accounts.Where(a => a.CustomerID == customerId).ToList();
                    return accounts.Select(account => new AccountCustomerDTO
                    {
                        AccountNumber = account.AccountNumber,
                        CustomerID = account.CustomerID,
                        Username = account.Username,
                        Password = account.Password,
                        Balance = (decimal)account.Balance,
                        Status = account.Status
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách tài khoản: " + ex.Message);
            }
        }

        public static string GetPasswordByAccountNumber(string accountNumber)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
                    if (account != null)
                    {
                        return account.Password;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy mật khẩu: " + ex.Message);
            }
        }

        public static decimal GetAccountBalance(string accountNumber)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
                    if (account != null)
                    {
                        return (decimal)(account.Balance ?? 0);
                    }
                    throw new Exception("Không tìm thấy tài khoản!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy số dư: " + ex.Message);
            }
        }

        public static bool DeductAccountBalance(string accountNumber, decimal amount)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
                    if (account != null)
                    {
                        decimal currentBalance = (decimal)(account.Balance ?? 0);

                        if (currentBalance < amount)
                        {
                            throw new Exception("Tài khoản không đủ tiền!");
                        }

                        account.Balance = currentBalance - amount;
                        db.SaveChanges();
                        return true;
                    }
                    throw new Exception("Không tìm thấy tài khoản!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi trừ tiền: " + ex.Message);
            }
        }

        public static bool AddAccountBalance(string accountNumber, decimal amount)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
                    if (account != null)
                    {
                        decimal currentBalance = (decimal)(account.Balance ?? 0);
                        account.Balance = currentBalance + amount;
                        db.SaveChanges();
                        return true;
                    }
                    throw new Exception("Không tìm thấy tài khoản!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cộng tiền: " + ex.Message);
            }
        }
        // 🌟 BỔ SUNG: HÀM CẬP NHẬT THÔNG TIN BẰNG ENTITY FRAMEWORK
        public static bool UpdateCustomerInfo(string accountNumber, string fullName, string phone, string email, string address)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
                    if (account != null)
                    {
                        var customer = db.Customers.FirstOrDefault(c => c.CustomerID == account.CustomerID);
                        if (customer != null)
                        {
                            customer.FullName = fullName;
                            customer.PhoneNumber = phone;
                            customer.Email = email;
                            customer.Address = address;

                            db.SaveChanges();
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật thông tin khách hàng: " + ex.Message);
            }
        }

        // Hàm đổi mật khẩu
        public static bool ChangePassword(string accountNumber, string newPassword)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
                    if (account != null)
                    {
                        account.Password = newPassword;
                        db.SaveChanges(); // Ép EF lưu xuống SQL Server
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đổi mật khẩu: " + ex.Message);
            }
        }
        public static string GetFullNameByCustomerId(int customerId)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities()) // Gọi DB Context của bạn
                {
                    // 1. Tìm khách hàng có ID khớp với tham số truyền vào
                    var khachHang = db.Customers.FirstOrDefault(c => c.CustomerID == customerId);

                    // 2. Nếu tìm thấy, trả về tên
                    if (khachHang != null)
                    {
                        return khachHang.FullName; // Thay 'FullName' bằng tên cột thật trong DB của bạn nếu khác
                    }

                    // 3. Nếu không tìm thấy (ID không tồn tại)
                    return "Không tìm thấy khách hàng";
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi rớt mạng SQL hoặc lỗi truy vấn
                Console.WriteLine("Lỗi lấy tên khách hàng: " + ex.Message);
                return ""; // Trả về chuỗi rỗng để giao diện không bị lỗi hiển thị chữ null
            }
        }
    }
}
