using DAL;
using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BLL.Services
{
    public class AccountService
    {
        public static AccountCustomerDTO GetAccountByUsername(string username)
        {
            return AccountDAL.GetAccountByUsername(username);
        }

        public static CustomerDTO GetCustomerInfo(int customerId)
        {
            return AccountDAL.GetCustomerInfo(customerId);
        }

        public static List<AccountCustomerDTO> GetAccountsByCustomer(int customerId)
        {
            return AccountDAL.GetAccountsByCustomer(customerId);
        }

        public static string GetPasswordByAccountNumber(string accountNumber)
        {
            return AccountDAL.GetPasswordByAccountNumber(accountNumber);
        }

        public static decimal GetAccountBalance(string accountNumber)
        {
            return AccountDAL.GetAccountBalance(accountNumber);
        }

        public static bool DeductAccountBalance(string accountNumber, decimal amount)
        {
            return AccountDAL.DeductAccountBalance(accountNumber, amount);
        }

        public static bool AddAccountBalance(string accountNumber, decimal amount)
        {
            return AccountDAL.AddAccountBalance(accountNumber, amount);
        }
        public static string UpdateCustomerInfo(string accountNumber, string fullName, string phone, string email, string address)
        {
            // 1. KIỂM TRA VALIDATION (BLL làm nhiệm vụ gác cổng)
            if (string.IsNullOrWhiteSpace(fullName) || !Regex.IsMatch(fullName, @"^(\p{Lu}\p{Ll}* )+\p{Lu}\p{Ll}*$"))
                return "Họ tên không hợp lệ. Vui lòng viết hoa chữ cái đầu mỗi từ (VD: Phan Le Son).";

            if (string.IsNullOrWhiteSpace(phone) || !Regex.IsMatch(phone, @"^0\d{9}$"))
                return "Số điện thoại phải có đúng 10 số và bắt đầu bằng số 0.";

            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Email không đúng định dạng.";

            // 2. GỌI XUỐNG TẦNG DAL (Chỉ nhờ DAL làm việc với Database)
            try
            {
                // Gọi hàm UpdateCustomerInfo bên AccountDAL
                bool isSuccess = AccountDAL.UpdateCustomerInfo(accountNumber, fullName, phone, email, address);

                if (isSuccess)
                    return ""; // Trả về chuỗi rỗng nghĩa là thành công hoàn toàn
                else
                    return "Không tìm thấy thông tin tài khoản để cập nhật.";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống: " + ex.Message;
            }
        }
        public static string ChangePassword(string accountNumber, string oldPasswordInput, string newPassword, string confirmPassword)
        {
            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(oldPasswordInput) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                return "Vui lòng nhập đầy đủ thông tin mật khẩu.";
            }

            // 2. Kiểm tra mật khẩu cũ có chính xác không (Gọi hàm có sẵn của DAL)
            string actualOldPassword = AccountDAL.GetPasswordByAccountNumber(accountNumber);
            if (actualOldPassword != oldPasswordInput)
            {
                return "Mật khẩu hiện tại không chính xác.";
            }

            // 3. Kiểm tra điều kiện mật khẩu mới
            if (newPassword.Length < 5)
            {
                return "Mật khẩu mới phải có ít nhất 5 ký tự.";
            }
            if (newPassword == oldPasswordInput)
            {
                return "Mật khẩu mới không được trùng với mật khẩu hiện tại.";
            }

            // 4. Kiểm tra xác nhận mật khẩu mới
            if (newPassword != confirmPassword)
            {
                return "Xác nhận mật khẩu không khớp.";
            }

            // 5. Nếu vượt qua mọi bài kiểm tra, gọi DAL để lưu vào Database
            try
            {
                bool isSuccess = AccountDAL.ChangePassword(accountNumber, newPassword);
                if (isSuccess)
                    return ""; // Trả về chuỗi rỗng nghĩa là thành công 100%
                else
                    return "Không tìm thấy tài khoản để cập nhật.";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống: " + ex.Message;
            }
        }
    }
}
