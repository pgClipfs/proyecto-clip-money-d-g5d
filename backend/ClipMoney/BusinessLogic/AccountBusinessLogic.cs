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
                MovementModel movementOverdraft = null;
                var movements = _movementsRepository.GetMovementsByAccountId(user.UserAccountId);
                var movementDeposit = movements.Where(m => m.MovementId == (int)MovementEnum.Deposit).OrderByDescending(o => o.DateMovement).FirstOrDefault();
                if(movementDeposit != null)
                {
                    movementOverdraft = movements.Where(x => x.MovementId == (int)MovementEnum.Overdraft && x.DateMovement > movementDeposit.DateMovement).OrderByDescending(p=>p.DateMovement).FirstOrDefault();
                }
                decimal amount;
                if(movementOverdraft != null && user.Amount > 0)
                {
                    amount = user.Amount - movementOverdraft.Amount;
                }
                else
                {
                    amount = user.Amount;
                }
                var movement = new MovementModel();
                movement.AccountId = user.UserAccountId;
                movement.DestinationAccountId = user.UserAccountId;
                movement.Amount = amount;
                movement.DateMovement = DateTime.Now;
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
                MovementModel movementDeposit = null;
                var account = _accountRepository.GetAccountById(accountId);
                var movements = _movementsRepository.GetMovementsByAccountId(accountId);
                var movementOverdraft = movements.Where(m => m.MovementId == (int)MovementEnum.Overdraft).OrderBy(o => o.DateMovement).FirstOrDefault();
                if(movementOverdraft != null)
                {
                    movementDeposit = movements.Where(m => m.MovementId == (int)MovementEnum.Deposit && (m.DateMovement == null || m.DateMovement > movementOverdraft.DateMovement)).FirstOrDefault();
                }
                
                if(account.Amount > 0 && (movementDeposit != null || movementOverdraft == null))
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
                        MovementId = (int)MovementEnum.Overdraft,
                        DateMovement = DateTime.Now
                    };
                    _movementsRepository.AddMovement(movement);
                }
                else if(account.Amount == 0 && (movementDeposit != null || movementOverdraft == null))
                {
                    var amount = movementDeposit.Amount * Convert.ToDecimal(0.1);
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
                        MovementId = (int)MovementEnum.Overdraft,
                        DateMovement = DateTime.Now
                    };
                    _movementsRepository.AddMovement(movement);
                }
                else if(account.Amount > 0 && movementDeposit == null)
                {
                    result.AddInputDataError("Debe primero realizar un deposito para girar al descubierto nuevamente.");
                }
                else if(account.Amount < 0)
                {
                    result.AddInputDataError("No se puede girar al descubierto con saldos negativos.");
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
