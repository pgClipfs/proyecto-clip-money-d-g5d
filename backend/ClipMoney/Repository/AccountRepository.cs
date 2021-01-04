using ClipMoney.Entities;
using ClipMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Repository
{
    public class AccountRepository
    {
        private readonly BilleteraVirtualContext _context;

        public AccountRepository(BilleteraVirtualContext context)
        {
            _context = context;
        }

        public PostUserMoneyModel PostUserMoney(PostUserMoneyModel user)
        {
            var userAccount = (from c in _context.Cuenta
                               where c.IdUsuario == user.UserId
                               select c).FirstOrDefault();
            if(userAccount != null)
            {
                var newAmount = userAccount.Monto + user.Amount;
                userAccount.Monto = newAmount;
                _context.SaveChanges();
                user.Amount = newAmount;
            }
            
            return user;
           
        }
        
    }
}
