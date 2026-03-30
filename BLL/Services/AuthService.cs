using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DTO.Models;

namespace BLL.Services
{
    public class AuthService
    {
        public static string Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username và password không được để trống!");
            }

            string userRole = AuthDAL.Login(username, password);
            if (string.IsNullOrEmpty(userRole))
            {
                throw new Exception("Sai tài khoản hoặc mật khẩu!");
            }

            return userRole;
        }
        public static string RegisterCustomer(CustomerDTO customer, string username, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Mật khẩu không được để trống!");
            }

            if (password != confirmPassword)
            {
                throw new ArgumentException("Mật khẩu xác nhận không khớp!");
            }

            if (string.IsNullOrWhiteSpace(customer.FullName))
            {
                throw new ArgumentException("Họ tên không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
            {
                throw new ArgumentException("Số điện thoại không được để trống!");
            }

            if (AuthDAL.UsernameExists(username))
            {
                throw new Exception("Username đã tồn tại!");
            }

            if (AuthDAL.PhoneExists(customer.PhoneNumber))
            {
                throw new Exception("Số điện thoại đã được đăng ký!");
            }

            if (!IsValidPhoneNumber(customer.PhoneNumber))
            {
                throw new ArgumentException("Số điện thoại không hợp lệ!");
            }

            if (!string.IsNullOrWhiteSpace(customer.Email) && !IsValidEmail(customer.Email))
            {
                throw new ArgumentException("Email không hợp lệ!");
            }

            string accountNumber = AuthDAL.Register(customer, username, password);
            return accountNumber;
        }

        public static AccountDTO GetAccountByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username không được để trống!");
            }

            return AuthDAL.GetAccountByUsername(username);
        }

        private static bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            phone = phone.Trim();
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^0\d{9}$");
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
