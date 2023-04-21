using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTask.Boilerplate.Application.ErrorHandling
{
    public class ResponseException : Exception
    {
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }

        public ResponseException(string errorCode, string errorDescription) : base(errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }

        public ResponseException(string errorCode) : this(errorCode, errorCode)
        {
        }
    }
}
