using ClipMoney.Models;
using ClipMoney.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClipMoney.BusinessLogic
{
    /// <summary>
    /// Logica de negocio de logueo.
    /// </summary>
    public class AuthBusinessLogic
    {
        private readonly AuthRepository _authRepository;
        private readonly AccountRepository _accountRepository;
        public AuthBusinessLogic(AuthRepository authRepository, AccountRepository accountRepository)
        {
            _authRepository = authRepository;
            _accountRepository = accountRepository;
        }

        /// <summary>
        /// Registra un nuevo usuario.
        /// </summary>
        /// <param name="user"></param>
        public void SignInUser(UserModel user)
        {
            var newUser = _authRepository.SignInUser(user);
            var accountModel = new AccountModel
            {
                Amount = 0,
                UserId = newUser.Id,
                CreationDate = DateTime.Now,
                CreationTime = DateTime.Now.TimeOfDay,
                CryptocurrencyId = 1,
                CurrencyTypeId = 1,
                TypeAccountId = 1,
                Movements = "null"
            };
            _accountRepository.CreateAccount(accountModel);
        }

        /// <summary>
        /// Verifica la existencia del usuario y genera el token en caso de existir. En caso de no existir genera un mensaje de error.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserTokenModel LoginUser(UserModel user)
        {
            var userToken = new UserTokenModel();
            try
            {
                var userDb = _authRepository.LoginUser(user);
                if (userDb != null)
                {
                    var token = GenerarJWT(userDb);
                    userToken.UserToken = token ;
                    
                }
                else
                {
                    userToken.UserToken = "Usuario y/o contraseña incorrectos.";
                }
            }
            catch (Exception ex)
            {

                //return ex.ToString();
            }

            return userToken;
        }

        /// <summary>
        /// Genera el jwt token con los datos del usuario.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GenerarJWT(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("C75D02A9D9E396ABD5FFE60A8C0D6DCFA8AC6C5EB1A9A300AA271140C8C0A0D4"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(24);

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim("email", user.Email),
                new Claim("name", user.Firstname),
                new Claim("lastname", user.Lastname)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                claims: Claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
