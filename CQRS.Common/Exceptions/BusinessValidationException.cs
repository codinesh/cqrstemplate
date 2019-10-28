using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Common.Exceptions
{
    public class BusinessValidationException : Exception
    {
        public BusinessValidationException(string message) : base(message)
        {
        }

        public BusinessValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BusinessValidationException()
        {
        }
    }
}
