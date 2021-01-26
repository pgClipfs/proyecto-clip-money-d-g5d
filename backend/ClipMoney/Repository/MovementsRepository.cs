using AutoMapper;
using ClipMoney.Entities;
using ClipMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Repository
{
    public class MovementsRepository
    {
        private readonly BilleteraVirtualContext _context;
        private readonly IMapper _mapper;

        public MovementsRepository(BilleteraVirtualContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MovementModel> GetMovementsByAccountId(int accountId)
        {
            var movements = (from m in _context.MovimientosXusuarios
                             join c in _context.Cuenta on m.IdCuenta equals c.IdCuenta
                             join u in _context.Usuarios on c.IdUsuario equals u.IdUsuario
                             join mov in _context.Movimientos on m.IdMovimiento equals mov.IdMovimiento
                             join cd in _context.Cuenta on m.IdCuentaDestino equals cd.IdCuenta
                             join ud in _context.Usuarios on cd.IdUsuario equals ud.IdUsuario
                             where m.IdCuenta == accountId
                             orderby m.FechaMovimiento descending
                             select new MovementModel 
                             {
                                 Id = m.Id,
                                 MovementId = m.IdMovimiento,
                                 MovementName = mov.Nombre,
                                 User = new UserModel
                                 {
                                     Id = u.IdUsuario,
                                     Firstname = u.NombreUsuario,
                                     Lastname = u.Apellido
                                 },
                                 UserDestination = new UserModel
                                 {
                                     Id = ud.IdUsuario,
                                     Firstname = ud.NombreUsuario,
                                     Lastname = ud.Apellido
                                 },
                                 Amount = m.Monto,
                                 DateMovement = m.FechaMovimiento

                             }).ToList();
            return movements;
        }
        public bool AddMovement(MovementModel movement)
        {
            try
            {
                _context.MovimientosXusuarios.Add(_mapper.Map<MovimientosXusuario>(movement));
                _context.SaveChanges();
                
            }
            catch (Exception)
            {

                return false;
            }

            return true;

        }

    }
}
