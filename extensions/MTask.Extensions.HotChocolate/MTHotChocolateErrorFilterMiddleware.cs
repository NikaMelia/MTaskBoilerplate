using HotChocolate;
using MTask.Extensions.Core.Errors;

namespace MTask.Extensions.HotChocolate
{
    public class MTHotChocolateErrorFilterMiddleware : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is MTOperationException mtOperationException)
            {
                var newError = error
                    .RemoveExtension("message")
                    .RemoveExtension("stackTrace")
                    .WithCode(mtOperationException.ErrorCode ?? "UnknownErrorCode")
                    .WithMessage(mtOperationException.ErrorMsg ?? "Error occured");

                if (mtOperationException.AdditionalInformation != null)
                {
                    newError = error.WithExtensions(mtOperationException.AdditionalInformation);
                }
               
                return newError;
            }
            else
            {
                var newError = error
                    .RemoveExtension("message")
                    .RemoveExtension("stackTrace")
                    .WithCode(CommonErrorCodes.InternalServerError)
                    .WithMessage("Internal Server Error occured")
                    .SetExtension("exceptionMessage", error.Exception?.Message);
                return newError;
            }
        }
    }
}