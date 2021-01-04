using ClipMoney.Models;
using ClipMoney.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.BusinessLogic
{
    public class AccountBusinessLogic
    {
        private readonly AccountRepository _accountRepository;

        public AccountBusinessLogic(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public ResultModel<PostUserMoneyModel> PostMoney(PostUserMoneyModel user)
        {
            var result = new ResultModel<PostUserMoneyModel>();
            try
            {
                if (user.UserAccountId <= 0)
                    result.AddInputDataError("El id de usuario es requerido");

                if (user.Amount == 0)
                    result.AddInputDataError("El monto es requerido");

                if (!result.Ok)
                    return result;

                result.Object = _accountRepository.PostUserMoney(user);

            }
            catch (Exception ex)
            {
                result.AddInternalError(ex.ToString());
            }
            
            return result;
        }

        public ResultModel<AccountModel> GetAccountByUserId(int userId)
        {
            var result = new ResultModel<AccountModel>();
            try
            {
                if (userId <= 0)
                    result.AddInputDataError("El id de usuario es requerido.");

                if (!result.Ok)
                    return result;

                result.Object = _accountRepository.GetAccountByUserId(userId);
            }
            catch (Exception ex)
            {
                result.AddInternalError(ex.ToString());
            }

            return result;
        }
    }
}
