using AutoMapper;
using ClipMoney.Entities;
using ClipMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Repository
{
    public class UserRepository
    {
        private readonly BilleteraVirtualContext _context;
        private readonly IMapper _mapper;
        public UserRepository(BilleteraVirtualContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserModel EditProfile(UserModel profile)
        {
            var user = (from u in _context.Usuarios
                        where u.IdUsuario == profile.Id
                        select u).FirstOrDefault();
            user.Mail = profile.Email;
            user.Contraseña = profile.Password;
            _context.SaveChanges();
            return _mapper.Map<UserModel>(user);
        }

        public UserModel GetUserById(int id)
        {
            var user = (from u in _context.Usuarios
                        where u.IdUsuario == id
                        select u).FirstOrDefault();

            return _mapper.Map<UserModel>(user);
        }
    }
}
