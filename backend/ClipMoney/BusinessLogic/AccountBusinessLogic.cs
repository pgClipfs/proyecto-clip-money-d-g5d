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

                var movement = new MovementModel();
                movement.AccountId = user.UserAccountId;
                movement.DestinationAccountId = user.UserAccountId;
                movement.Amount = user.Amount;
                if (user.Amount < 0)
                {
                    movement.MovementId = (int)MovementEnum.Extraction;
                }
                else
                {
                    movement.MovementId = (int)MovementEnum.Deposit;
                }
                _movementsRepository.AddMovement(movement);

                result.Object = _accountRepository.PostUserMoney(user);

            }
            catch (Exception ex)
            {
                result.AddInternalError(ex.ToString());
            }
            
            return result;
        }

        public ResultModel<PostUserMoneyModel> PostOverdraft(int accountId)
        {
            var result = new ResultModel<PostUserMoneyModel>();
            try
            {
                if (accountId <= 0)
                    result.AddInputDataError("El id de cuenta es requerido");

                if (!result.Ok)
                    return result;

                var account = _accountRepository.GetAccountById(accountId);
                if(account.Amount >= 0)
                {
                    var amount = account.Amount * Convert.ToDecimal(0.1);
                    var postOverdraft = new PostUserMoneyModel
                    {
                        Amount = amount,
                        UserAccountId = account.Id
                    };
                    
                    result.Object = _accountRepository.PostUserMoney(postOverdraft);
                    var movement = new MovementModel
                    {
                        AccountId = account.Id,
                        DestinationAccountId = account.Id,
                        Amount = amount,
                        MovementId = (int)MovementEnum.Overdraft
                    };
                    _movementsRepository.AddMovement(movement);
                }
                else if(account.Amount < 0)
                {
                    result.AddInputDataError("No se puede girar al descubierto con saldos negativos");
                    return result;
                }
                
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
