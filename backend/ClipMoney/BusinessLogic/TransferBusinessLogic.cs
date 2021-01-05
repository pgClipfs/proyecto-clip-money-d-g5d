using ClipMoney.Models;
using ClipMoney.Models.Enums;
using ClipMoney.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.BusinessLogic
{
    public class TransferBusinessLogic
    {
        private readonly TransferRepository _transferRepository;
        private readonly AccountRepository _accountRepository;
        private readonly MovementsRepository _movementsRepository;
        public TransferBusinessLogic(TransferRepository transferRepository, AccountRepository accountRepository, MovementsRepository movementsRepository)
        {
            _transferRepository = transferRepository;
            _accountRepository = accountRepository;
            _movementsRepository = movementsRepository;
        }

        public ResultModel<TransferModel> TransferMoney(TransferModel transfer)
        {
            var result = new ResultModel<TransferModel>();
            try
            {
                if (transfer.IdInboundAccount <= 0)
                    result.AddInputDataError("El id de cuenta entrante es requerido.");

                if (transfer.IdOutboundAccount <= 0)
                    result.AddInputDataError("El id de cuenta saliente es requerido.");

                if (transfer.Amount <= 0)
                    result.AddInputDataError("El monto de la transferencia es requerida.");

                if (!result.Ok)
                    return result;

                var accountTransferred = _accountRepository.PostUserMoney(new PostUserMoneyModel { UserAccountId = transfer.IdInboundAccount, Amount = transfer.Amount });

                var movementTransferred = new MovementModel();
                movementTransferred.Amount = transfer.Amount;
                movementTransferred.MovementId = (int)MovementEnum.Transfer;
                movementTransferred.AccountId = transfer.IdOutboundAccount;
                movementTransferred.DestinationAccountId = transfer.IdInboundAccount;
                _movementsRepository.AddMovement(movementTransferred);

                var amountNegative = transfer.Amount * -1;
                var accountFromTransfer = _accountRepository.PostUserMoney(new PostUserMoneyModel { UserAccountId = transfer.IdOutboundAccount, Amount = amountNegative });
                var movementFromTransfer = new MovementModel();
                movementFromTransfer.Amount = amountNegative;
                movementFromTransfer.MovementId = (int)MovementEnum.Transfer;
                movementFromTransfer.AccountId = transfer.IdInboundAccount;
                movementFromTransfer.DestinationAccountId = transfer.IdOutboundAccount;
                _movementsRepository.AddMovement(movementFromTransfer);

                result.Object = _transferRepository.TransferMoney(transfer);

            }
            catch (Exception ex)
            {
                result.AddInternalError(ex.ToString());
            }

            return result;
        }
    }
}
