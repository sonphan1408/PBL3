using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class LoanContractDTO
    {
        public string ContractID { get; set; }
        public string AccountNumber { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal RemainingBalance { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TermMonths { get; set; }
        public string Collateral { get; set; }
        public string Status { get; set; }
    }
}
