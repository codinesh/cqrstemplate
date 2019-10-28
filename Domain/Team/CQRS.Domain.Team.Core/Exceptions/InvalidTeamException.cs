using CQRS.Common.Exceptions;
using System;
using System.Runtime.Serialization;

namespace CQRS.Domain.Team.Core
{
    [Serializable]
    public class InvalidTeamException : DomainException
    {
        public InvalidTeamException(string message) : base(message)
        {
        }
    }
}