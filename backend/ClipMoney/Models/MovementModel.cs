using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Models
{
    public class MovementModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int DestinationAccountId { get; set; }
        public decimal Amount { get; set; }
        public int MovementId { get; set; }
        public string MovementName { get; set; }
        public UserModel User { get; set; }
        public UserModel UserDestination { get; set; }
        public DateTime? DateMovement { get; set; }
    }
}
