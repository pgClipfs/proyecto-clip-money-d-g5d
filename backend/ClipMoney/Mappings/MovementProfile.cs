using AutoMapper;
using ClipMoney.Entities;
using ClipMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Mappings
{
    public class MovementProfile: Profile
    {
        public MovementProfile()
        {
            CreateMap<MovementModel, MovimientosXusuario>()
                .ForMember(e => e.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(e => e.IdCuenta, opt => opt.MapFrom(m => m.AccountId))
                .ForMember(e => e.IdCuentaDestino, opt => opt.MapFrom(m => m.DestinationAccountId))
                .ForMember(e => e.Monto, opt => opt.MapFrom(m => m.Amount))
                .ForMember(e => e.IdMovimiento, opt => opt.MapFrom(m => m.MovementId))
                .ForMember(e => e.FechaMovimiento, opt => opt.MapFrom(m => m.DateMovement));

            CreateMap<MovimientosXusuario, MovementModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(e => e.AccountId, opt => opt.MapFrom(m => m.IdCuenta))
                .ForMember(e => e.DestinationAccountId, opt => opt.MapFrom(m => m.IdCuentaDestino))
                .ForMember(e => e.Amount, opt => opt.MapFrom(m => m.Monto))
                .ForMember(e => e.MovementId, opt => opt.MapFrom(m => m.IdMovimiento))
                .ForMember(e => e.DateMovement, opt => opt.MapFrom(m => m.FechaMovimiento));

        }
    }
}
