using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL.Core;
using DTO.Models;

namespace DAL.Repositories
{
    public class AccountDAL
    {
        public static AccountDTO GetAccountByUsername(string username)
        {
            try
            {
                string sql = @"SELECT AccountNumber, CustomerID, Username, Balance, Status 
                            FROM dbo.Accounts WHERE Username = @username";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", username)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new AccountDTO
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

        public static CustomerDTO GetCustomerInfo(int customerId)
        {
            try
            {
                string sql = @"SELECT CustomerID, FullName, Gender, DateOfBirth, Address, PhoneNumber, Email 
                            FROM dbo.Customers WHERE CustomerID = @customerId";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@customerId", customerId)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new CustomerDTO
                    {
                        CustomerID = (int)row["CustomerID"],
                        FullName = row["FullName"].ToString(),
                        Gender = row["Gender"].ToString(),
                        DateOfBirth = (DateTime)row["DateOfBirth"],
                        Address = row["Address"].ToString(),
                        PhoneNumber = row["PhoneNumber"].ToString(),
                        Email = row["Email"].ToString()
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin khách hàng: " + ex.Message);
            }
        }

        public static List<AccountDTO> GetAccountsByCustomer(int customerId)
        {
            try
            {
                string sql = @"SELECT AccountNumber, CustomerID, Username, Balance, Status 
                            FROM dbo.Accounts WHERE CustomerID = @customerId";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@customerId", customerId)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                List<AccountDTO> accounts = new List<AccountDTO>();
                foreach (DataRow row in dt.Rows)
                {
                    accounts.Add(new AccountDTO
                    {
                        AccountNumber = row["AccountNumber"].ToString(),
                        CustomerID = (int)row["CustomerID"],
                        Username = row["Username"].ToString(),
                        Balance = (decimal)row["Balance"],
                        Status = row["Status"].ToString()
                    });
                }
                return accounts;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách tài khoản: " + ex.Message);
            }
        }
    }
}
