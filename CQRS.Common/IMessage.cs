using System;

namespace CQRS.Common
{
    public interface IMessage
    {
        Guid UserId { get; set; }

        Guid CorrelationId { get; set; }
    }
}
