using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    internal class InterestRateDTO
    {
        public int RateID { get; set; }
        public string Category { get; set; }
        public int TermMonths { get; set; }
        public decimal RateValue { get; set; }
    }
}
