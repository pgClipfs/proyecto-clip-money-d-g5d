using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Models
{
    public class PostUserMoneyModel
    {
        public int UserAccountId { get; set; }

        public decimal Amount { get; set; }
    }
}
