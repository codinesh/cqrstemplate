using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Common.Exceptions
{
    public class QueryHandlerNotRegisteredException : BusinessValidationException
    {
        public QueryHandlerNotRegisteredException(string message) : base(message)
        {
        }

        public QueryHandlerNotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public QueryHandlerNotRegisteredException()
        {
        }
    }
}
