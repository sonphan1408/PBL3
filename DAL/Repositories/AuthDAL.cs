using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO.Models; // Gọi Thùng hàng

namespace DAL.Repositories
{
    // Đã đổi internal thành public
    public class AuthDAL
    {
        // Chuỗi kết nối Database của bạn
        private string connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DigitalBankingDB;Integrated Security=True;TrustServerCertificate=True";

        public string RegisterCustomerAndAccount(CustomerDTO customer, AccountDTO account)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Lưu Customer (Thêm cột CCCD và IDCard)
                    string sqlCustomer = @"INSERT INTO Customers (FullName, Gender, DateOfBirth, Address, PhoneNumber, Email, CCCD, IDCard) 
                                           OUTPUT INSERTED.CustomerID 
                                           VALUES (@name, @gender, @dob, @address, @phone, @email, @cccd, @idcard)";

                    int newCustomerId = 0;
                    using (SqlCommand cmd = new SqlCommand(sqlCustomer, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@name", customer.FullName);
                        cmd.Parameters.AddWithValue("@gender", customer.Gender);
                        cmd.Parameters.AddWithValue("@dob", customer.DateOfBirth);
                        cmd.Parameters.AddWithValue("@address", customer.Address);
                        cmd.Parameters.AddWithValue("@phone", customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@email", customer.Email);
                        cmd.Parameters.AddWithValue("@cccd", customer.CCCD);
                        cmd.Parameters.AddWithValue("@idcard", customer.IDCard); // Mã 9 số do BLL tự sinh

                        newCustomerId = (int)cmd.ExecuteScalar();
                    }

                    // 2. Lưu Account
                    string newAccountNumber = "8888000" + newCustomerId.ToString();
                    string sqlAccount = @"INSERT INTO Accounts (AccountNumber, CustomerID, Username, Password, Balance, Status) 
                                          VALUES (@accNum, @custId, @user, @pass, 0, 'Active')";

                    using (SqlCommand cmd = new SqlCommand(sqlAccount, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@accNum", newAccountNumber);
                        cmd.Parameters.AddWithValue("@custId", newCustomerId);
                        cmd.Parameters.AddWithValue("@user", account.Username);
                        cmd.Parameters.AddWithValue("@pass", account.Password);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return newAccountNumber; // Trả về số tài khoản
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi Database: " + ex.Message);
                }
            }
        }
    }
}