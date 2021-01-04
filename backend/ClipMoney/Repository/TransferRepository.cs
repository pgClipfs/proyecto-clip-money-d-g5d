using AutoMapper;
using ClipMoney.Entities;
using ClipMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Repository
{
    public class TransferRepository
    {
        private readonly BilleteraVirtualContext _context;
        private readonly IMapper _mapper;

        public TransferRepository(BilleteraVirtualContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TransferModel TransferMoney(TransferModel deposit)
        {
                deposit.Date = DateTime.Now;
                deposit.Time = DateTime.Now.TimeOfDay;
                var newDeposit = _context.Transferencia.Add(_mapper.Map<Transferencium>(deposit));
                _context.SaveChanges();
                return _mapper.Map<TransferModel>(newDeposit.Entity);
        }
    }
}
