using HotChocolate.AspNetCore.Serialization;
using HotChocolate.Execution;
using MTask.Extensions.Core.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MTask.Extensions.HotChocolate
{
    public class MTHttpResultSerializer : DefaultHttpResultSerializer
    {
        public override HttpStatusCode GetStatusCode(IExecutionResult result)
        {
            if (result is IQueryResult queryResult && queryResult.Errors?.Count > 0)
            {
                if (queryResult.Errors.Any(error => error.Code == CommonErrorCodes.InternalServerError))
                {
                    return HttpStatusCode.InternalServerError;
                }

                return HttpStatusCode.OK;
            }

            return base.GetStatusCode(result);
        }
    }
}
