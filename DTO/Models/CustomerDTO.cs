using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class CustomerDTO : createTime
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string CCCD { get; set; } // Số khách hàng tự nhập
        public string IDCard { get; set; } // Mã 9 số hệ thống tự sinh
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AvatarPath { get; set; }
    }
}
