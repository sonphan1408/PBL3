using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class LoanSchedulesDTO
    {
        public int ScheduleID { get; set; }
        public string ContractID { get; set; }

        public DateTime DueDate { get; set; }

        public decimal ExpectedPrincipal { get; set; }
        public decimal ExpectedInterest { get; set; }
        public decimal PenaltyAmount  { get; set; }
        public decimal PrincipalPaid  { get; set; }
        public decimal InterestPaid   { get; set; }

        public string Status { get; set; }

        public int InstallmentNumber { get; set; }
        public decimal PenaltyPaid { get; set; }
        public decimal TotalExpectedAmount => ExpectedPrincipal + ExpectedInterest + PenaltyAmount;

        public decimal TotalPaidAmount => PrincipalPaid + InterestPaid + PenaltyPaid;
    }
}
