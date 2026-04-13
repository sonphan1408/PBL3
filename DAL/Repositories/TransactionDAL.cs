using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL.Core;
using DTO.Models;

namespace DAL.Repositories
{
    public class TransactionDAL
    {
        public static List<TransactionDTO> GetTransactionsByAccount(string accountNumber, int limit = 10)
        {
            try
            {
                string sql = @"SELECT TOP (@limit) TransactionID, FromAccount, ToAccount, TypeID, Amount, 
                            BalanceBefore, BalanceAfter, Description, CreatedAt
                            FROM dbo.InternalTransactions 
                            WHERE FromAccount = @account OR ToAccount = @account
                            ORDER BY CreatedAt DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@account", accountNumber),
                    new SqlParameter("@limit", limit)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                List<TransactionDTO> transactions = new List<TransactionDTO>();
                foreach (DataRow row in dt.Rows)
                {
                    var transaction = GetTransactionDTO(row);
                    transactions.Add(transaction);
                }
                return transactions;
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Message.Contains("Invalid object name") && sqlEx.Message.Contains("InternalTransactions"))
                {
                    System.Diagnostics.Debug.WriteLine("TABLE NOT FOUND: dbo.InternalTransactions does not exist in the database. Please create it or verify the table name.");
                    return new List<TransactionDTO>();
                }
                throw new Exception("Lỗi khi lấy lịch sử giao dịch: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy lịch sử giao dịch: " + ex.Message);
            }
        }

        public static decimal GetTotalIncome(string accountNumber)
        {
            try
            {
                string sql = @"SELECT ISNULL(SUM(Amount), 0) AS TotalIncome
                            FROM dbo.InternalTransactions 
                            WHERE ToAccount = @account";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@account", accountNumber)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    return (decimal)dt.Rows[0]["TotalIncome"];
                }
                return 0;
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Message.Contains("Invalid object name"))
                {
                    System.Diagnostics.Debug.WriteLine("TABLE NOT FOUND: dbo.InternalTransactions does not exist");
                    return 0;
                }
                throw new Exception("Lỗi khi tính tổng thu nhập: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tính tổng thu nhập: " + ex.Message);
            }
        }

        public static decimal GetTotalExpense(string accountNumber)
        {
            try
            {
                string sql = @"SELECT ISNULL(SUM(Amount), 0) AS TotalExpense
                            FROM dbo.InternalTransactions 
                            WHERE FromAccount = @account";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@account", accountNumber)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    return (decimal)dt.Rows[0]["TotalExpense"];
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tính tổng chi tiêu: " + ex.Message);
            }
        }

        private static TransactionDTO GetTransactionDTO(DataRow row)
        {
            var transaction = new InternalTransactionDTO();

            if (Guid.TryParse(row["TransactionID"].ToString(), out Guid transId))
                transaction.TransactionID = transId;

            transaction.FromAccount = row["FromAccount"].ToString();
            transaction.ToAccount = row["ToAccount"].ToString();
            transaction.TypeID = (int)row["TypeID"];
            transaction.Amount = (decimal)row["Amount"];
            transaction.BalanceBefore = (decimal)row["BalanceBefore"];
            transaction.BalanceAfter = (decimal)row["BalanceAfter"];
            transaction.Description = row["Description"].ToString();
            transaction.CreatedAt = (DateTime)row["CreatedAt"];

            return transaction;
        }
    }
}
