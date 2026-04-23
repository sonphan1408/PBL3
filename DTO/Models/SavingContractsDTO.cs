using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class SavingContractsDTO
    {
        public string ContractID { get; set; }

        public string SavingType { get; set; }
        public string AccountNumber { get; set; }
        public string Goal { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal AccruedInterest { get; set; }
        public decimal InterestRate { get; set; }
        public int TermMonths { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
       
    }
}
