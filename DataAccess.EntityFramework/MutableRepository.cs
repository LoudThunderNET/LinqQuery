using DataAccess.Abstraction.Query;
using DataAccess.Abstraction.Repository;
using LinqQuery.EntityFramework.Query.Visitors;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class MutableRepository<TEntity> : RepositoryBase<TEntity>, IMutable<TEntity> where TEntity : class 
    {
        public MutableRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellation = default)
        {
            var changeTracking = await DbContext.Set<TEntity>().AddAsync(entity, cancellation);
            return changeTracking.Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default)
        {
            DbContext.ChangeTracker.AutoDetectChangesEnabled = false;

            await DbContext.Set<TEntity>().AddRangeAsync(entities, cancellation);

            DbContext.ChangeTracker.AutoDetectChangesEnabled = true;

            await DbContext.SaveChangesAsync(cancellation);
        }

        public override Task<TOut> ApplyAsync<TOut>(IEndQuery<TEntity, TOut> endQuery, CancellationToken cancellation = default)
        {
            TrackingVisitor.Visit(endQuery);
            return base.ApplyAsync(endQuery, cancellation);
        }

        public override Task<IReadOnlyCollection<TOut>> ApplyAsync<TOut>(IQuery<TEntity, TOut> endQuery, CancellationToken cancellation = default)
        {
            TrackingVisitor.Visit(endQuery);
            return base.ApplyAsync(endQuery, cancellation);
        }

        public Task SaveChangesAsync(CancellationToken cancellation = default)
        {
            return DbContext.SaveChangesAsync(cancellation);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellation = default)
        {
            var changeTracking = Entities.Update(entity);
            await DbContext.SaveChangesAsync(cancellation);

            return changeTracking.Entity;
        }

        public Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default)
        {
            DbContext.ChangeTracker.AutoDetectChangesEnabled = false;
            Entities.UpdateRange(entities);

            DbContext.ChangeTracker.AutoDetectChangesEnabled = true;

            return DbContext.SaveChangesAsync(cancellation);
        }
    }
}
