using DAL;
using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BLL.Utilities;

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
        public static string GetFullNameByCustomerId(int customerId)
        {
            return AccountDAL.GetFullNameByCustomerId(customerId);
        }

        public static string GetUsernameByAccountNumber(string accountNumber)
        {
            return AccountDAL.GetUsernameByAccountNumber(accountNumber);
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
            // kiem tra validation
            if (string.IsNullOrWhiteSpace(fullName) || !Regex.IsMatch(fullName, @"^(\p{Lu}\p{Ll}* )+\p{Lu}\p{Ll}*$"))
                return "Họ tên không hợp lệ. Vui lòng viết hoa chữ cái đầu mỗi từ (VD: Phan Le Son).";

            if (string.IsNullOrWhiteSpace(phone) || !Regex.IsMatch(phone, @"^0\d{9}$"))
                return "Số điện thoại phải có đúng 10 số và bắt đầu bằng số 0.";

            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Email không đúng định dạng.";

            // Goi DAL de cap nhat thong tin
            try
            {
                // Goi ham update trong DAL, neu thanh cong tra ve chuoi rong, neu khong tra ve thong bao loi
                bool isSuccess = AccountDAL.UpdateCustomerInfo(accountNumber, fullName, phone, email, address);

                if (isSuccess)
                    return ""; // tra ve chuoi rong nghia la thanh cong 100%
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
            if (string.IsNullOrWhiteSpace(oldPasswordInput) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                return "Vui lòng nhập đầy đủ thông tin mật khẩu.";
            }

            // Kiem tra mat khau cu co chinh xac khong
            string currentPasswordHash = AccountDAL.GetPasswordByAccountNumber(accountNumber);
            if (!HashPassword.Verify(oldPasswordInput, currentPasswordHash))
            {
                return "Mật khẩu hiện tại không chính xác.";
            }

            // Kiem tra mat khau moi co it nhat 5 ky tu khong va khong trung voi mat khau cu
            if (newPassword.Length < 5)
            {
                return "Mật khẩu mới phải có ít nhất 5 ký tự.";
            }
            if (HashPassword.Verify(newPassword, currentPasswordHash))
            {
                return "Mật khẩu mới không được trùng với mật khẩu hiện tại.";
            }

            // Kiem tra mat khau moi va xac nhan mat khau co khop nhau khong
            if (newPassword != confirmPassword)
            {
                return "Xác nhận mật khẩu không khớp.";
            }

            // Neu dat duoc tat ca cac dieu kien thi goi DAL de cap nhat mat khau
            try
            {
                string hashPassword = HashPassword.Hash(newPassword);
                bool isSuccess = AccountDAL.ChangePassword(accountNumber, hashPassword);
                if (isSuccess)
                    return ""; // Tra ve chuoi rong nghia la thanh cong 100%
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
