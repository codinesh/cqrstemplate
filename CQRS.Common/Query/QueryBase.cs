using System;

namespace CQRS.Common
{
    public abstract class QueryBase<TReadModel> : IQuery<TReadModel>
        where TReadModel : IReadModel
    {
        protected QueryBase() {
            CorrelationId = Guid.NewGuid();
        }

        public Guid UserId { get; set; }

        public Guid CorrelationId { get; set; }
    }
}
