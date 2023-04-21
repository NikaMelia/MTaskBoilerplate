using System;
using System.Collections.Generic;

namespace MTask.Extensions.Core.Errors
{
    public class MTOperationException : Exception
    {
        public string ErrorCode { get; }
        public string ErrorMsg { get; }
        
        public Dictionary<string, object?>? AdditionalInformation { get; }

        public MTOperationException(string errorCode, string errorMsg, Dictionary<string, object?> additionalInformation = null)
        {
            ErrorCode = errorCode;
            ErrorMsg = errorMsg;
            AdditionalInformation = additionalInformation;
        }
    }

    public class NotFoundMTOperationException : MTOperationException
    {
        private const string NotFoundErrorMessage = "Could not resolve entity id '{0}'.";
        
        public NotFoundMTOperationException(int id) : 
            base(CommonErrorCodes.NotFound, string.Format(NotFoundErrorMessage, id))
        {
        }
        
        public NotFoundMTOperationException(string id) : 
            base(CommonErrorCodes.NotFound, string.Format(NotFoundErrorMessage, id))
        {
        }
    }

    public class AlreadyExistMTOperationException : MTOperationException
    {
        private const string AlreadyExistMessage = "entity already exist";

        public AlreadyExistMTOperationException() : base(CommonErrorCodes.AlreadyExist,AlreadyExistMessage)
        {
        }
    }
}