using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class AccountCustomerDTO : AccountDTO
    {
        //public string Username { get; set; }
        //public string Password { get; set; }
        //public string Role { get; set; }
        public string AccountNumber { get; set; } 
        public int CustomerID { get; set; }
        public decimal Balance { get; set; } = 0;
        public string Status { get; set; } = "Active";
    }
}
