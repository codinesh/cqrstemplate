using System;
using System.Threading.Tasks;

namespace CQRS.Common.Query
{
    public interface IQueryHandlerRegister
    {
        Task<TResult> HandleAsync<TResult>(IQuery<TResult> query);

        void Register<TQuery, TReadModel>(Func<IQueryHandler<TQuery, TReadModel>> handler)
            where TQuery : QueryBase<TReadModel>
            where TReadModel : IReadModel;
    }
}
