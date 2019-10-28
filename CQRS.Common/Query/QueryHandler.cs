using System.Threading.Tasks;

namespace CQRS.Common.Query
{
    public abstract class QueryHandler<TQuery, TReadModel> : IQueryHandler<TQuery, TReadModel>
        where TQuery : QueryBase<TReadModel>
        where TReadModel :IReadModel
    {
        public Task<bool> AuthorizeAsync(TQuery query)
        {
            //To-do: Authorization logic for reads goes here.
            return Task.FromResult(true);
        }

        public abstract Task<TReadModel> HandleAsync(TQuery query);
    }
}
