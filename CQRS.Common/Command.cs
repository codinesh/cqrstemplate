using System;

namespace CQRS.Common
{
    public class Command : ICommand
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }

        public Guid UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid CorrelationId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Command(Guid id, int version)
        {
            Id = id;
            Version = version;
        }
    }
}
