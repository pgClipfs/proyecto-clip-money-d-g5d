using ClipMoney.Models;
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

        public TransferBusinessLogic(TransferRepository transferRepository, AccountRepository accountRepository)
        {
            _transferRepository = transferRepository;
            _accountRepository = accountRepository;
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

                var accountFromTransfer = _accountRepository.PostUserMoney(new PostUserMoneyModel { UserAccountId = transfer.IdOutboundAccount, Amount = transfer.Amount *= -1 });
                
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
