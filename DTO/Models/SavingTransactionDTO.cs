using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
     public class SavingTransactionDTO
    {
        public int TransactionID { get; set; }
        public string ContractID { get; set; }
        public string TransactionType { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }
        public string Note { get; set; }
    }
}
