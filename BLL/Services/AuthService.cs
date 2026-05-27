using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DTO.Models;
using DAL.Repositories;

namespace BLL.Services
{
    public class AuthService
    {
        private AuthDAL _authDAL = new AuthDAL();

        public string RegisterNewCustomer(CustomerDTO customer, AccountCustomerDTO account, string confirmPassword)
        {
            // Kiem tra validation

            if (string.IsNullOrWhiteSpace(customer.FullName) || !Regex.IsMatch(customer.FullName, @"^(\p{Lu}\p{Ll}* )+\p{Lu}\p{Ll}*$"))
                return "Họ tên không hợp lệ. Vui lòng viết hoa chữ cái đầu mỗi từ và cách nhau 1 khoảng trắng (VD: Hà Đỗ Ngọc Thái).";

            if (string.IsNullOrWhiteSpace(customer.Gender))
                return "Vui lòng chọn giới tính.";

            if (string.IsNullOrWhiteSpace(customer.Address) ||
                customer.Address.Trim().Length < 15 ||
                !customer.Address.Contains(",") ||
                !Regex.IsMatch(customer.Address, @"^[\p{L}0-9\s,/\.-]+$"))
            {
                return "Địa chỉ chưa hợp lệ hoặc quá ngắn. Vui lòng gõ đầy đủ (VD: 107/5 Bà Huyện Thanh Quan, Mỹ An, Ngũ Hành Sơn, Đà Nẵng).";
            }

            int age = DateTime.Now.Year - customer.DateOfBirth.Year;
            if (customer.DateOfBirth.Date > DateTime.Now.AddYears(-age)) age--;
            if (age < 15)
                return "Khách hàng phải từ đủ 15 tuổi trở lên.";

            if (string.IsNullOrWhiteSpace(customer.CCCD) || !Regex.IsMatch(customer.CCCD, @"^0\d{11}$"))
                return "CCCD phải bao gồm chính xác 12 chữ số và bắt đầu bằng số 0";

            if (string.IsNullOrWhiteSpace(customer.PhoneNumber) || !Regex.IsMatch(customer.PhoneNumber, @"^0\d{9}$"))
                return "Số điện thoại phải có đúng 10 số và bắt đầu bằng số 0.";

            if (string.IsNullOrWhiteSpace(account.Username) || account.Username.Length < 6)
                return "Tên đăng nhập không được để trống và phải từ 6 ký tự.";

            if (string.IsNullOrWhiteSpace(customer.Email) || !Regex.IsMatch(customer.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Email không đúng định dạng.";

            if (string.IsNullOrWhiteSpace(account.Password) || account.Password.Length < 6)
                return "Mật khẩu phải có ít nhất 6 ký tự.";

            if (account.Password != confirmPassword)
                return "Mật khẩu xác nhận không khớp!";


            // Goi DAL de kiem tra trung lap va luu thong tin
            try
            {
                _authDAL.RegisterCustomerAndAccount(customer, account);

                return "Tạo thành công tài khoản mới";
            }
            catch (Exception ex)
            {
                return "Lỗi đăng ký (Có thể Tên đăng nhập, CCCD hoặc SĐT đã tồn tại).\nChi tiết: " + ex.Message;
            }
        }

        public static AccountCustomerDTO LoginCustomer(string username, string password)
        {
            try
            {
                return AuthDAL.LoginCustomer(username, password);
            }
            catch (Exception ex)
            {
                throw new Exception("Đăng nhập thất bại: " + ex.Message);
            }
        }
    }
}