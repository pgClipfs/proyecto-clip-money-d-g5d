using AutoMapper;
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
        private readonly IMapper _mapper;
        public AccountRepository(BilleteraVirtualContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateAccount(AccountModel account)
        {
            _context.Cuenta.Add(_mapper.Map<Cuentum>(account));
            _context.SaveChanges();
        }

        public PostUserMoneyModel PostUserMoney(PostUserMoneyModel user)
        {
            var userAccount = (from c in _context.Cuenta
                               where c.IdCuenta == user.UserAccountId
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

        public AccountModel GetAccountByUserId(int userId)
        {
            var userAccount = (from c in _context.Cuenta
                               where c.IdUsuario == userId
                               select c).FirstOrDefault();

            return _mapper.Map<AccountModel>(userAccount);
        }

        public AccountModel GetAccountById(int id)
        {
            var account = (from a in _context.Cuenta
                           where a.IdCuenta == id
                           select a).FirstOrDefault();

            return _mapper.Map<AccountModel>(account);
        }
    }
}
