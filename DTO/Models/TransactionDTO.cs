using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public abstract class TransactionDTO : createTime
    {
        public Guid TransactionID { get; set; } = Guid.NewGuid();
        public string FromAccount { get; set; }
        public int TypeID { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceBefore { get; set; }
        public decimal BalanceAfter { get; set; }
        public string Description { get; set; }
    }
}
