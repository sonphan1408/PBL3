using System;
using System.Data;
using System.Data.SqlClient;
using DAL.Core;
using DTO.Models;

namespace DAL.Repositories
{
    public class TransferDAL
    {
        public AccountDTO GetAccountByAccountNumber(string accountNumber)
        {
            try
            {
                string sql = "SELECT * FROM Accounts WHERE AccountNumber = @accountNum";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@accountNum", accountNumber)
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
                        Password = row["Password"].ToString(),
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

        public AccountDTO GetAccountByUsername(string username)
        {
            try
            {
                string sql = "SELECT * FROM Accounts WHERE Username = @username";
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
                        Password = row["Password"].ToString(),
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

        public string GetCustomerNameByID(int customerID)
        {
            try
            {
                string sql = "SELECT FullName FROM Customers WHERE CustomerID = @custId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@custId", customerID)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["FullName"].ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tên khách hàng: " + ex.Message);
            }
        }

        public bool ExecuteTransfer(string senderAccountNumber, string recipientAccountNumber, decimal amount, string notes)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Deduct from sender account
                    string sqlUpdateSender = "UPDATE Accounts SET Balance = Balance - @amount WHERE AccountNumber = @senderAccNum";
                    SqlCommand cmdSender = new SqlCommand(sqlUpdateSender, conn, transaction);
                    cmdSender.Parameters.AddWithValue("@amount", amount);
                    cmdSender.Parameters.AddWithValue("@senderAccNum", senderAccountNumber);
                    cmdSender.ExecuteNonQuery();

                    // 2. Add to recipient account
                    string sqlUpdateRecipient = "UPDATE Accounts SET Balance = Balance + @amount WHERE AccountNumber = @recipientAccNum";
                    SqlCommand cmdRecipient = new SqlCommand(sqlUpdateRecipient, conn, transaction);
                    cmdRecipient.Parameters.AddWithValue("@amount", amount);
                    cmdRecipient.Parameters.AddWithValue("@recipientAccNum", recipientAccountNumber);
                    cmdRecipient.ExecuteNonQuery();

                    // 3. Record transaction (if transaction table exists)
                    // Try to insert into Transactions table, but don't fail if it doesn't exist
                    try
                    {
                        string sqlInsertTransaction = @"INSERT INTO Transactions (FromAccountNumber, ToAccountNumber, Amount, TransactionDate, Description, Status) 
                                                       VALUES (@sender, @recipient, @amount, @date, @notes, 'Completed')";
                        SqlCommand cmdTransaction = new SqlCommand(sqlInsertTransaction, conn, transaction);
                        cmdTransaction.Parameters.AddWithValue("@sender", senderAccountNumber);
                        cmdTransaction.Parameters.AddWithValue("@recipient", recipientAccountNumber);
                        cmdTransaction.Parameters.AddWithValue("@amount", amount);
                        cmdTransaction.Parameters.AddWithValue("@date", DateTime.Now);
                        cmdTransaction.Parameters.AddWithValue("@notes", notes ?? "");
                        cmdTransaction.ExecuteNonQuery();
                    }
                    catch
                    {
                        // If transaction table insert fails, just continue - the main transfer is done
                        // This prevents the entire transfer from failing due to transaction logging
                    }

                    // Commit transaction
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi khi thực hiện chuyển khoản: " + ex.Message);
                }
            }
        }
    }
}
