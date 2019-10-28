using System.Threading.Tasks;

namespace CQRS.Common.Query
{
    public interface IQueryHandler<TQuery, TReadModel> where TQuery : QueryBase<TReadModel>
        where TReadModel : IReadModel
    {
        Task<TReadModel> HandleAsync(TQuery query);

        Task<bool> AuthorizeAsync(TQuery query);
    }
}
