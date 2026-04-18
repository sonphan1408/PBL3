using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class InterestRateDTO
    {
        public int RateID { get; set; }
        public string Category { get; set; }
        public int TermMonths { get; set; }
        public decimal RateValue { get; set; }
        public InterestRateDTO() { }


        public InterestRateDTO(int rateId, string category, int termMonths, decimal rateValue)
        {
            this.RateID = rateId;
            this.Category = category;
            this.TermMonths = termMonths;
            this.RateValue = rateValue;
        }
    }
}
