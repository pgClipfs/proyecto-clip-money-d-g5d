using ClipMoney.Models;
using ClipMoney.Models.Enums;
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
        private readonly MovementsRepository _movementsRepository;
        public AccountBusinessLogic(AccountRepository accountRepository, MovementsRepository movementsRepository)
        {
            _accountRepository = accountRepository;
            _movementsRepository = movementsRepository;
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

                var movement = new MovementModel();
                movement.AccountId = user.UserAccountId;
                movement.DestinationAccountId = user.UserAccountId;
                movement.Amount = user.Amount;
                if(user.Amount < 0)
                {
                    movement.MovementId = (int)MovementEnum.Extraction;
                }
                else
                {
                    movement.MovementId = (int)MovementEnum.Deposit;
                }
                _movementsRepository.AddMovement(movement);
                
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
