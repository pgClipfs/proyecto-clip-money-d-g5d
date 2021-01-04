using AutoMapper;
using ClipMoney.Entities;
using ClipMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Mappings
{
    public class DepositProfile: Profile
    {
        public DepositProfile()
        {
            CreateMap<DepositModel, Deposito>()
                .ForMember(e => e.IdDeposito, opt => opt.MapFrom(m => m.Id))
                .ForMember(e => e.IdCuentaSaliente, opt => opt.MapFrom(m => m.IdOutboundAccount))
                .ForMember(e => e.IdCuentaEntrante, opt => opt.MapFrom(m => m.IdInboundAccount))
                .ForMember(e => e.Fecha, opt => opt.MapFrom(m => m.Date))
                .ForMember(e => e.Hora, opt => opt.MapFrom(m => m.Time))
                .ForMember(e => e.Monto, opt => opt.MapFrom(m => m.Amount));

            CreateMap<Deposito, DepositModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(m => m.IdDeposito))
                .ForMember(e => e.IdOutboundAccount, opt => opt.MapFrom(m => m.IdCuentaSaliente))
                .ForMember(e => e.IdInboundAccount, opt => opt.MapFrom(m => m.IdCuentaEntrante))
                .ForMember(e => e.Date, opt => opt.MapFrom(m => m.Fecha))
                .ForMember(e => e.Time, opt => opt.MapFrom(m => m.Hora))
                .ForMember(e => e.Amount, opt => opt.MapFrom(m => m.Monto));

        }
    }
}
