using ClipMoney.Models;
using ClipMoney.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.BusinessLogic
{
    public class MovementBusinessLogic
    {
        private readonly MovementsRepository _movementsRepository;

        public MovementBusinessLogic(MovementsRepository movementsRepository)
        {
            _movementsRepository = movementsRepository;
        }

        public ResultModel<List<MovementModel>> GetMovementsByAccountId(int accountId)
        {
            var result = new ResultModel<List<MovementModel>>();
            try
            {
                if (accountId <= 0)
                    result.AddInputDataError("El id de cuenta es requerido");

                if (!result.Ok)
                    return result;

                result.Object = _movementsRepository.GetMovementsByAccountId(accountId);
            }
            catch (Exception ex)
            {

                result.AddInternalError(ex.ToString());
            }

            return result;
        }
    }
}
