using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Models
{
    public class ResultModel<T>
    {
        public bool Ok { get { return !Errors.Any(); } }

        public T Object { get; set; }

        public List<ErrorModel> Errors { get; set; }

        public string ErrorsText { get { return string.Join(", ", Errors.Select(p => p.Message)); } }

        public ResultModel()
        {
            Errors = new List<ErrorModel>();
        }
        public ResultModel(T obj) : this()
        {
            Object = obj;
        }

        private void AddError(string message, ErrorModel.ErrorsTypesEnum type)
        {
            Errors.Add(new ErrorModel { Message = message, Type = type });
        }

        public void AddInputDataError(string message)
        {
            AddError(message, ErrorModel.ErrorsTypesEnum.InputDataError);
        }

        public void AddInternalError(string message)
        {
            AddError(message, ErrorModel.ErrorsTypesEnum.InternalError);
        }
    }
}
