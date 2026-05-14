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
                NotificationDAL.MarkAllAsRead(username);
            }
            catch { }
        }

        public static bool CreateNotification(string username, string message, string type = "General")
        {
            try
            {
                return NotificationDAL.CreateNotification(username, message, type);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error creating notification: " + ex.Message);
                return false;
            }
        }
    }
}
