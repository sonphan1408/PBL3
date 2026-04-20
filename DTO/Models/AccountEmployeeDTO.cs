using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class AccountEmployeeDTO : AccountDTO
    {
        public string EmployeeID { get; set; } 
        public string FullName { get; set; }
    }
}
