using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Models
{
    public class DepositModel
    {
        public int Id { get; set; }
        public int IdOutboundAccount { get; set; }
        public int IdInboundAccount { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public float Amount { get; set; }
        
    }
}
