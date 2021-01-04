using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Models
{
    public class ErrorModel
    {
        public string Message { get; set; }
        public ErrorsTypesEnum Type { get; set; }

        public enum ErrorsTypesEnum
        {
            InputDataError,
            InternalError
        }
    }
}
