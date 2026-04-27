using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Session
{
    public static class UserSession
    {
        public static AccountCustomerDTO CurrentUser { get; set; }
        public static void ClearSession()
        {
            CurrentUser = null;
        }
        public static event Action BalanceChanged;

      
        public static void UpdateBalance(decimal amountToDeduct)
        {
            if (CurrentUser != null)
            {
                // Trừ tiền ngay trên RAM (Session)
                CurrentUser.Balance -= amountToDeduct;

                // PHÁT LOA! Gọi tất cả những Form nào đang đăng ký nghe sự kiện này
                BalanceChanged?.Invoke();
            }
        }
    }
}
