using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL.Core;
using DTO.Models;

namespace DAL.Repositories
{
    public class NotificationDAL
    {
        public static int GetUnreadNotificationCount(string username)
        {
            try
            {
                // Giả định ReceiverAccount lưu username hoặc AccountNumber
                string sql = @"SELECT COUNT(*) FROM Notifications WHERE ReceiverAccount = @username AND IsRead = 0";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", username)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0][0]);
                }
                return 0;
            }
            catch
            {
                // Nếu bảng chưa tồn tại hoặc có lỗi, trả về số ảo để UI không lỗi
                return 0; 
            }
        }

        public static List<NotificationDTO> GetRecentNotifications(string username)
        {
            List<NotificationDTO> list = new List<NotificationDTO>();
            try
            {
                string sql = @"SELECT TOP 5 NotiID, ReceiverAccount, Message, Type, IsRead, CreatedAt 
                               FROM Notifications 
                               WHERE ReceiverAccount = @username 
                               ORDER BY CreatedAt DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", username)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new NotificationDTO
                    {
                        NotiID = Convert.ToInt32(row["NotiID"]),
                        ReceiverAccount = row["ReceiverAccount"].ToString(),
                        Message = row["Message"].ToString(),
                        Type = row["Type"] != DBNull.Value ? row["Type"].ToString() : "General",
                        IsRead = Convert.ToBoolean(row["IsRead"]),
                        CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now
                    });
                }
            }
            catch
            {
                // Return empty if table doesn't exist
            }
            return list;
        }
    }
}
