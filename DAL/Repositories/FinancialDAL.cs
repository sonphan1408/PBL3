using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Windows.Forms;
using DAL.Core;
using DTO.Models;

namespace DAL.Repositories
{
    public class FinancialDAL
    {
        public static List<FinancialProductDTO> GetSavingsByCustomer(int customerId)
        {
            try
            {
                string sql = @"SELECT ProductID, AccountNumber, Category, PrincipalAmount, InterestRate, StartDate, EndDate, Status
                            FROM dbo.FinancialProducts 
                            WHERE AccountNumber IN (SELECT AccountNumber FROM dbo.Accounts WHERE CustomerID = @customerId)
                            AND Category = 'Saving'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@customerId", customerId)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                List<FinancialProductDTO> savings = new List<FinancialProductDTO>();
                foreach (DataRow row in dt.Rows)
                {
                    savings.Add(new FinancialProductDTO
                    {
                        ProductID = (int)row["ProductID"],
                        ProductName = string.Format("Account {0}", row["AccountNumber"].ToString()),
                        AccountNumber = row["AccountNumber"].ToString(),
                        Amount = (decimal)row["PrincipalAmount"],
                        InterestRate = (decimal)row["InterestRate"],
                        Status = row["Status"].ToString()
                    });
                }
                return savings;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách tiết kiệm: " + ex.Message);
            }
        }

        public static decimal GetTotalSavings(int customerId)
        {
            try
            {
                string sql = @"SELECT ISNULL(SUM(PrincipalAmount), 0) AS TotalSavings
                            FROM dbo.FinancialProducts 
                            WHERE AccountNumber IN (SELECT AccountNumber FROM dbo.Accounts WHERE CustomerID = @customerId)
                            AND Category = 'Saving' AND Status = 'Active'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@customerId", customerId)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    return (decimal)dt.Rows[0]["TotalSavings"];
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tính tổng tiết kiệm: " + ex.Message);
            }
        }

        public static decimal GetTotalLoans(int customerId)
        {
            try
            {
                string sql = @"SELECT ISNULL(SUM(PrincipalAmount), 0) AS TotalLoans
                            FROM dbo.FinancialProducts 
                            WHERE AccountNumber IN (SELECT AccountNumber FROM dbo.Accounts WHERE CustomerID = @customerId)
                            AND Category = 'Loan' AND Status = 'Active'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@customerId", customerId)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    return (decimal)dt.Rows[0]["TotalLoans"];
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tính tổng khoản vay: " + ex.Message);
            }
        }

        public static int GetTotalSavingsAccounts(int customerId)
        {
            try
            {
                string sql = @"SELECT COUNT(*) AS Count FROM dbo.FinancialProducts 
                            WHERE AccountNumber IN (SELECT AccountNumber FROM dbo.Accounts WHERE CustomerID = @customerId)
                            AND Category = 'Saving' AND Status = 'Active'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@customerId", customerId)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    return (int)dt.Rows[0]["Count"];
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đếm tài khoản tiết kiệm: " + ex.Message);
            }
        }

        public static int GetTotalLoans(int customerId, int count)
        {
            try
            {
                string sql = @"SELECT COUNT(*) AS Count FROM dbo.FinancialProducts 
                            WHERE AccountNumber IN (SELECT AccountNumber FROM dbo.Accounts WHERE CustomerID = @customerId)
                            AND Category = 'Loan' AND Status = 'Active'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@customerId", customerId)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    return (int)dt.Rows[0]["Count"];
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đếm khoản vay: " + ex.Message);
            }
        }


            public static List<InterestRateDTO> GetInterestRatesByCategory(string category)
        {
            List<InterestRateDTO> list = new List<InterestRateDTO>();

           
            string query = "SELECT RateID, Category, TermMonths, RateValue FROM InterestRates WHERE Category = @Category ORDER BY TermMonths ASC";

           
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Category", category)
            };

            DataTable dt = DBHelper.ExecuteQuery(query, parameters);

           
            foreach (DataRow row in dt.Rows)
            {
                InterestRateDTO rate = new InterestRateDTO
                {
                    RateID = Convert.ToInt32(row["RateID"]),
                    Category = row["Category"].ToString(),
                    TermMonths = Convert.ToInt32(row["TermMonths"]),
                    RateValue = Convert.ToDecimal(row["RateValue"])
                };
                list.Add(rate);
            }

            return list;
        }
        public static double GetExactRateValue(string category, int termMonths)
        {
            try
            {
                double rate = 0;
                string query = "SELECT RateValue FROM InterestRates WHERE Category = @Category AND TermMonths = @TermMonths";

                SqlParameter[] parameters = new SqlParameter[]
                {
        new SqlParameter("@Category", category),
        new SqlParameter("@TermMonths", termMonths)
                };


                object result = DBHelper.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    rate = Convert.ToDouble(result);
                }

                return rate;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tim rate: " + ex.Message);
               
            }

           
        }
    }
}
   
