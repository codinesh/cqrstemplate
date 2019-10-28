using CQRS.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Common.Query
{
    public class QueryHandlerRegister : IQueryHandlerRegister
    {
        private readonly Dictionary<Type, Func<dynamic>> queryHandlers = new Dictionary<Type, Func<dynamic>>();

        public async Task<TResult> HandleAsync<TResult>(IQuery<TResult> query)
        {
            var queryHandler = FetchHandler(query);
            await queryHandler.AuthorizeAsync((dynamic)query);

            return await queryHandler.HandleAsync((dynamic)query);
        }

        private dynamic FetchHandler<TResult>(IQuery<TResult> query)
        {
            var queryType = query.GetType();
            if (!queryHandlers.ContainsKey(queryType))
            {
                throw new QueryHandlerNotRegisteredException();
            }

            return queryHandlers[queryType]();
        }

        public void Register<TQuery, TReadModel>(Func<IQueryHandler<TQuery, TReadModel>> handler)
            where TQuery : QueryBase<TReadModel>
            where TReadModel: IReadModel
        {
            var queryType = typeof(TQuery);
            if (!queryHandlers.ContainsKey(queryType))
            {
                queryHandlers.Add(queryType, handler);
            }
        }
    }
}
