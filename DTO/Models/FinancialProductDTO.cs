using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    internal class FinancialProductDTO
    {
        public int ProductID { get; set; }
        public string AccountNumber { get; set; }
        public string Category { get; set; } // Saving/Loan
        public decimal PrincipalAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int TermMonths { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public int? ApprovedBy { get; set; }
    }
}
