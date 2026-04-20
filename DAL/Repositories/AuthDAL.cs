using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Core;
using DTO.Models;

namespace DAL.Repositories
{
    public class AuthDAL
    {
        public static string Login(string username, string password)
        {
            try
            {
                string sql = @"SELECT 'Customer' AS UserRole FROM Accounts WHERE Username = @u AND Password = @p
                            UNION
                            SELECT Role AS UserRole FROM Employees WHERE Username = @u AND Password = @p";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@u", username),
                    new SqlParameter("@p", password)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["UserRole"].ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng nhập: " + ex.Message);
            }
        }
        //public static string Register(CustomerDTO customer, string username, string password)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = DBHelper.GetConnection())
        //        {
        //            conn.Open();
        //            SqlTransaction transaction = conn.BeginTransaction();

        //            try
        //            {
        //                string sqlCustomer = @"INSERT INTO Customers (FullName, Gender, DateOfBirth, Address, PhoneNumber, Email, IDCard) 
        //                               OUTPUT INSERTED.CustomerID 
        //                               VALUES (@name, @gender, @dob, @address, @phone, @email, @idcard)";

        //                int newCustomerId = 0;
        //                using (SqlCommand cmd = new SqlCommand(sqlCustomer, conn, transaction))
        //                {
        //                    cmd.Parameters.AddWithValue("@name", customer.FullName ?? (object)DBNull.Value);
        //                    cmd.Parameters.AddWithValue("@gender", customer.Gender ?? (object)DBNull.Value);
        //                    cmd.Parameters.AddWithValue("@dob", customer.DateOfBirth);
        //                    cmd.Parameters.AddWithValue("@address", customer.Address ?? (object)DBNull.Value);
        //                    cmd.Parameters.AddWithValue("@phone", customer.PhoneNumber ?? (object)DBNull.Value);
        //                    cmd.Parameters.AddWithValue("@email", customer.Email ?? (object)DBNull.Value);
        //                    cmd.Parameters.AddWithValue("@idcard", customer.IDCard ?? (object)DBNull.Value);

        //                    newCustomerId = (int)cmd.ExecuteScalar();
        //                }

        //                string newAccountNumber = "8888000" + newCustomerId.ToString().PadLeft(7, '0');

        //                string sqlAccount = @"INSERT INTO Accounts (AccountNumber, CustomerID, Username, Password, Balance, Status) 
        //                              VALUES (@accNum, @custId, @user, @pass, 0, 'Active')";

        //                using (SqlCommand cmd = new SqlCommand(sqlAccount, conn, transaction))
        //                {
        //                    cmd.Parameters.AddWithValue("@accNum", newAccountNumber);
        //                    cmd.Parameters.AddWithValue("@custId", newCustomerId);
        //                    cmd.Parameters.AddWithValue("@user", username);
        //                    cmd.Parameters.AddWithValue("@pass", password);

        //                    cmd.ExecuteNonQuery();
        //                }

        //                transaction.Commit();
        //                return newAccountNumber;
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw new Exception("Lỗi đăng ký: " + ex.Message);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi đăng ký tài khoản: " + ex.Message);
        //    }
        //}
        public static AccountCustomerDTO GetAccountByUsername(string username)
        {
            try
            {
                string sql = "SELECT * FROM Accounts WHERE Username = @u";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@u", username)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new AccountCustomerDTO
                    {
                        AccountNumber = row["AccountNumber"].ToString(),
                        CustomerID = (int)row["CustomerID"],
                        Username = row["Username"].ToString(),
                      
                        Balance = (decimal)row["Balance"],
                        Status = row["Status"].ToString()
                    };
                }
                return null;
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
                string sql = "SELECT COUNT(*) FROM Accounts WHERE Username = @u";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@u", username)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);
                return (int)dt.Rows[0][0] > 0;
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
                string sql = "SELECT COUNT(*) FROM Customers WHERE PhoneNumber = @phone";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@phone", phone)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);
                return (int)dt.Rows[0][0] > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra số điện thoại: " + ex.Message);
            }
        }

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
                        cmd.Parameters.AddWithValue("@idcard", customer.IDCard); 

                        newCustomerId = (int)cmd.ExecuteScalar();
                    }

                    
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
                    return newAccountNumber; 
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi Database: " + ex.Message);
                }
            }
        }
      
        
            public static AccountCustomerDTO LoginCustomer(string username, string password)
            {
               
                string query = "SELECT AccountNumber, CustomerID, Username, Balance, Status FROM Accounts WHERE Username = @u AND Password = @p AND Status = 'Active'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@u", username),
                new SqlParameter("@p", password)
                };

                DataTable dt = DBHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    AccountCustomerDTO customer = new AccountCustomerDTO();

             
                    customer.Username = row["Username"].ToString();
                    customer.Role = "Customer"; 

                    customer.AccountNumber = row["AccountNumber"].ToString();

                    if (row["CustomerID"] != DBNull.Value)
                        customer.CustomerID = Convert.ToInt32(row["CustomerID"]);

                    if (row["Balance"] != DBNull.Value)
                        customer.Balance = Convert.ToDecimal(row["Balance"]);

                    customer.Status = row["Status"].ToString();

                    return customer;
                }

                return null; 
            }

            
            public AccountEmployeeDTO LoginEmployee(string username, string password)
            {
                
                string query = "SELECT EmployeeID, FullName, Username, Role FROM Employees WHERE Username = @u AND Password = @p";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@u", username),
                new SqlParameter("@p", password)
                };

                DataTable dt = DBHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    AccountEmployeeDTO employee = new AccountEmployeeDTO();

                    
                    employee.Username = row["Username"].ToString();
                    employee.Role = row["Role"].ToString(); 

                    employee.EmployeeID = row["EmployeeID"].ToString();

                    if (row["FullName"] != DBNull.Value)
                        employee.FullName = row["FullName"].ToString();

                    return employee;
                }

                return null; 
            }
        }
    }

