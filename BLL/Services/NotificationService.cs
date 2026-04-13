using System;
using System.Collections.Generic;
using DAL.Repositories;
using DTO.Models;

namespace BLL.Services
{
    public class NotificationService
    {
        public static int GetUnreadCount(string username)
        {
            try
            {
                return NotificationDAL.GetUnreadNotificationCount(username);
            }
            catch
            {
                return 0;
            }
        }

        public static List<NotificationDTO> GetRecentNotifications(string username)
        {
            try
            {
                return NotificationDAL.GetRecentNotifications(username);
            }
            catch
            {
                return new List<NotificationDTO>();
            }
        }

        public static void MarkAllAsRead(string username)
        {
            try
            {
                string sql = "UPDATE Notifications SET IsRead = 1 WHERE ReceiverAccount = @username AND IsRead = 0";
                System.Data.SqlClient.SqlParameter[] p = { new System.Data.SqlClient.SqlParameter("@username", username) };
                DAL.Core.DBHelper.ExecuteQuery(sql, p);
            }
            catch { }
        }
    }
}
