using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class ExternalTransactionDTO : TransactionDTO
    {
        public string ReceiverAccount { get; set; }
        public string ReceiverName { get; set; }
        public string BankCode { get; set; }
        public string Status { get; set; }
        public string TraceNumber { get; set; }
    }
}
