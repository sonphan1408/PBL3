using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Core
{
    public class DBHelper
    {
        // Lấy chuỗi kết nối từ file App.config
        private static string connString = ConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;

        // Hàm mở kết nối
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connString);
        }

        // Hàm thực thi SQL không trả về dữ liệu (INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Hàm lấy dữ liệu (SELECT) trả về một DataTable
        public static DataTable ExecuteQuery(string sql, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
