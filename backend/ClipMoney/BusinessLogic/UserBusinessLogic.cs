using ClipMoney.Models;
using ClipMoney.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.BusinessLogic
{
    public class UserBusinessLogic
    {
        private readonly UserRepository _userRepository;
        public UserBusinessLogic(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ResultModel<UserModel> EditProfile(UserModel profile)
        {
            var result = new ResultModel<UserModel>();
            try
            {
                if (profile.Id <= 0)
                    result.AddInputDataError("El id de usuario es requerido para editar el perfil.");

                if (!result.Ok)
                    return result;

                result.Object = _userRepository.EditProfile(profile);
            }
            catch (Exception ex)
            {
                result.AddInternalError(ex.ToString());
            }

            return result;
        }

        public ResultModel<UserModel> GetUserById(int id)
        {
            var result = new ResultModel<UserModel>();
            try
            {
                if (id <= 0)
                    result.AddInputDataError("El id de usuario es requerido");

                if (!result.Ok)
                    return result;

                result.Object = _userRepository.GetUserById(id);
            }
            catch (Exception ex)
            {

                result.AddInternalError(ex.ToString());
            }

            return result;
        }
    }
}
