using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class LoanRepaymentDTO
    {
        public int RepaymentID { get; set; }
        public string ContractID { get; set; }
        public decimal PrincipalPaid { get; set; }
        public decimal InterestPaid { get; set; }
        public decimal PenaltyPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalAmount => PrincipalPaid + InterestPaid + PenaltyPaid;

    }
}
