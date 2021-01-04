using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public TimeSpan CreationTime { get; set; }
        public decimal Amount { get; set; }
        public int TypeAccountId { get; set; }
        public string Movements { get; set; }
        public int CurrencyTypeId { get; set; }
        public int CryptocurrencyId { get; set; }
    }
}
