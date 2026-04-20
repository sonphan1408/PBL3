using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class InternalTransactionDTO : TransactionDTO
    {
        public new string ToAccount { get; set; }
    }
}
