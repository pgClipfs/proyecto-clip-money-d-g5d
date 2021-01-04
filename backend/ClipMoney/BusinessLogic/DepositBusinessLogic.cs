using ClipMoney.Models;
using ClipMoney.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.BusinessLogic
{
    public class DepositBusinessLogic
    {
        private readonly DepositRepository _depositRepository;

        public DepositBusinessLogic(DepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        public ResultModel<DepositModel> DepositMoney(DepositModel deposit)
        {
            var result = new ResultModel<DepositModel>();
            try
            {
                if (deposit.IdInboundAccount <= 0)
                    result.AddInputDataError("El id de cuenta entrante es requerido.");

                if (deposit.IdOutboundAccount <= 0)
                    result.AddInputDataError("El id de cuenta saliente es requerido.");

                if (deposit.Amount <= 0)
                    result.AddInputDataError("El monto del deposito es requerido.");

                if (!result.Ok)
                    return result;

                result.Object = _depositRepository.DepositMoney(deposit);

            }
            catch (Exception ex)
            {
                result.AddInternalError(ex.ToString());
            }

            return result;
        }
    }
}
