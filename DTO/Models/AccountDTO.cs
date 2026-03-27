using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class AccountDTO : createTime
    {
        public string AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; }
    }
}
