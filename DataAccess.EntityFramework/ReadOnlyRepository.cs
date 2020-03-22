using DataAccess.Abstraction.Query;
using LinqQuery.EntityFramework.Query.Visitors;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class ReadOnlyRepository<TEntity> : RepositoryBase<TEntity> where TEntity : class
    {
        public ReadOnlyRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override Task<TOut> ApplyAsync<TOut>(IEndQuery<TEntity, TOut> endQuery, CancellationToken cancellation = default)
        {
            NoTrackingVisitor.Visit(endQuery);
            return base.ApplyAsync(endQuery, cancellation);
        }

        public override Task<IReadOnlyCollection<TOut>> ApplyAsync<TOut>(IQuery<TEntity, TOut> endQuery, CancellationToken cancellation = default)
        {
            NoTrackingVisitor.Visit(endQuery);
            return base.ApplyAsync(endQuery, cancellation);
        }
    }
}
