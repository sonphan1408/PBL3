using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class SavingsPreviewDTO
    {
        public decimal InterestRate { get; set; }        // Lãi suất áp dụng (%)
        public decimal MaturityInterest { get; set; }    // Tiền lãi dự kiến
    }
}
