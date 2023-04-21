using HotChocolate.Types;
using MTask.Boilerplate.Application.ErrorHandling;
using MTask.Extensions.Core.Errors;

namespace MTask.Boilerplate.Api.Schema.Utils
{
    public class ResponseError
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }

        private ResponseError(string errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        public static ResponseError CreateErrorFrom(MTOperationException ex)
        {
            return new ResponseError(ex.ErrorCode, ex.Message);
        }
    }
}
