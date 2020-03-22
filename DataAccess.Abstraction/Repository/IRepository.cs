using DataAccess.Abstraction.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Abstraction.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);
        ValueTask<TEntity> FindAsync(object keyId, CancellationToken cancellation = default);
        Task<TOut> ApplyAsync<TOut>(IEndQuery<TEntity, TOut> endQuery, CancellationToken cancellation = default) where TOut : class;
        Task<IReadOnlyCollection<TOut>> ApplyAsync<TOut>(IQuery<TEntity, TOut> endQuery, CancellationToken cancellation = default) where TOut : class;
    }
}
