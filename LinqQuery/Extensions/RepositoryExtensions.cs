using DataAccess.Abstraction.Query;
using DataAccess.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinqQuery.Extensions
{
    public static class RepositoryExtensions
    {
        public static Task<TOut> ExcecuteQueryAsync<TIn, TOut>(this IRepository<TIn> repository, Func<IQuery<TIn, TIn>, IEndQuery<TIn, TOut>> queryProvider) where TIn : class where TOut : class
        {
            return repository.ApplyAsync(queryProvider(QueryExtensions.Query<TIn>()));
        }

        public static Task<IReadOnlyCollection<TOut>> ExcecuteQueryAsync<TIn, TOut>(this IRepository<TIn> repository, Func<IQuery<TIn, TIn>, IQuery<TIn, TOut>> queryProvider) where TIn : class where TOut : class
        {
            return repository.ApplyAsync(queryProvider(QueryExtensions.Query<TIn>()));
        }
    }
}
