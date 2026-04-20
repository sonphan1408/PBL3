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
        public static AccountDTO CurrentUser { get; set; }
        public static void ClearSession()
        {
            CurrentUser = null;
        }
    }
}
