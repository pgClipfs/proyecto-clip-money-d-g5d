using AutoMapper;
using ClipMoney.Entities;
using ClipMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Mappings
{
    public class AccountProfile: Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountModel, Cuentum>()
                .ForMember(e => e.IdCuenta, opt => opt.MapFrom(m => m.Id))
                .ForMember(e => e.IdTipoCuenta, opt => opt.MapFrom(m => m.TypeAccountId))
                .ForMember(e => e.IdUsuario, opt => opt.MapFrom(m => m.UserId))
                .ForMember(e => e.FechaCreacion, opt => opt.MapFrom(m => m.CreationDate))
                .ForMember(e => e.HoraCreacion, opt => opt.MapFrom(m => m.CreationTime))
                .ForMember(e => e.Monto, opt => opt.MapFrom(m => m.Amount))
                .ForMember(e => e.Movimientos, opt => opt.MapFrom(m => m.Movements))
                .ForMember(e => e.IdMoneda, opt => opt.MapFrom(m => m.CurrencyTypeId))
                .ForMember(e => e.IdCriptomoneda, opt => opt.MapFrom(m => m.CryptocurrencyId));

            CreateMap<Cuentum, AccountModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(m => m.IdCuenta))
                .ForMember(e => e.TypeAccountId, opt => opt.MapFrom(m => m.IdTipoCuenta))
                .ForMember(e => e.UserId, opt => opt.MapFrom(m => m.IdUsuario))
                .ForMember(e => e.CreationDate, opt => opt.MapFrom(m => m.FechaCreacion))
                .ForMember(e => e.CreationTime, opt => opt.MapFrom(m => m.HoraCreacion))
                .ForMember(e => e.Amount, opt => opt.MapFrom(m => m.Monto))
                .ForMember(e => e.Movements, opt => opt.MapFrom(m => m.Movimientos))
                .ForMember(e => e.CurrencyTypeId, opt => opt.MapFrom(m => m.IdMoneda))
                .ForMember(e => e.CryptocurrencyId, opt => opt.MapFrom(m => m.IdCriptomoneda));
        }
    }
}
