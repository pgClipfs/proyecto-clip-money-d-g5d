using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Models
{
    public class TransferModel
    {
        public int Id { get; set; }
        public int IdOutboundAccount { get; set; }
        public int IdInboundAccount { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Amount { get; set; }
        
    }
}
