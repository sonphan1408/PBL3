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
                    var acc = db.Accounts.FirstOrDefault(a => a.Username == username);
                    if (acc == null) return 0;
                    string accNum = acc.AccountNumber;

                    return db.Notifications
                        .Where(n => n.ReceiverAccount == accNum && n.IsRead == false)
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
                    var acc = db.Accounts.FirstOrDefault(a => a.Username == username);
                    if (acc == null) return new List<NotificationDTO>();
                    string accNum = acc.AccountNumber;

                    return db.Notifications
                        .Where(n => n.ReceiverAccount == accNum)
                        .OrderByDescending(n => n.CreatedAt)
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

        public static void MarkAllAsRead(string username)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var acc = db.Accounts.FirstOrDefault(a => a.Username == username);
                    if (acc != null)
                    {
                        string accNum = acc.AccountNumber;
                        var unread = db.Notifications.Where(n => n.ReceiverAccount == accNum && n.IsRead == false).ToList();
                        foreach (var n in unread)
                        {
                            n.IsRead = true;
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch { }
        }

        public static bool CreateNotification(string username, string message, string type)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var acc = db.Accounts.FirstOrDefault(a => a.Username == username);
                    if (acc == null) throw new Exception("Username not found");
                    string accNum = acc.AccountNumber;

                    var notification = new Notification
                    {
                        ReceiverAccount = accNum,
                        Message = message,
                        Type = type ?? "General",
                        IsRead = false,
                        CreatedAt = DateTime.Now
                    };
                    db.Notifications.Add(notification);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message + "\n" + ex.InnerException?.InnerException?.Message;
                System.Diagnostics.Debug.WriteLine("Error in CreateNotification: " + err);
                try { System.IO.File.AppendAllText(@"C:\Users\Admin\Desktop\notif_error.txt", DateTime.Now + ": " + err + "\n"); } catch {}
                return false;
            }
        }
    }
}
