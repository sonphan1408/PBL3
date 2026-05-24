using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }
        public string AccountNumber { get; set; }
        public int ProviderID { get; set; }
        public string BillCode { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime? DueDate { get; set; }
        public string ProviderName { get; set; }
    }
}
