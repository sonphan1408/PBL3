using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public abstract class createTime
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
