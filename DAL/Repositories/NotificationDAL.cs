using System;
using System.Collections.Generic;
using System.Linq;
using DTO.Models;

namespace DAL.Repositories
{
    public class NotificationDAL
    {
        public static int GetUnreadNotificationCount(string username)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    return db.Notifications
                        .Where(n => n.ReceiverAccount == username && n.IsRead == false)
                        .Count();
                }
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
                using (var db = new DigitalBankingDBEntities())
                {
                    return db.Notifications
                        .Where(n => n.ReceiverAccount == username)
                        .OrderByDescending(n => n.CreatedAt)
                        .Take(5)
                        .ToList()  // Execute query FIRST, then map in memory
                        .Select(n => new NotificationDTO
                        {
                            NotiID = n.NotiID,
                            ReceiverAccount = n.ReceiverAccount,
                            Message = n.Message,
                            Type = n.Type ?? "General",
                            IsRead = n.IsRead.GetValueOrDefault(false),
                            CreatedAt = n.CreatedAt ?? DateTime.Now
                        })
                        .ToList();
                }
            }
            catch
            {
                return new List<NotificationDTO>();
            }
        }
    }
}
