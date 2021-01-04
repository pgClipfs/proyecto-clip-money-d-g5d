using AutoMapper;
using ClipMoney.Entities;
using ClipMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Repository
{
    public class DepositRepository
    {
        private readonly BilleteraVirtualContext _context;
        private readonly IMapper _mapper;

        public DepositRepository(BilleteraVirtualContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DepositModel DepositMoney(DepositModel deposit)
        {
            try
            {
                deposit.Date = DateTime.Now;
                deposit.Time = DateTime.Now.TimeOfDay;
                var newDeposit = _context.Depositos.Add(_mapper.Map<Deposito>(deposit));
                _context.SaveChanges();
                return _mapper.Map<DepositModel>(newDeposit.Entity);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
