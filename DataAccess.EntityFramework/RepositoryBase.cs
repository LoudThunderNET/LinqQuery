using DataAccess.Abstraction.Query;
using DataAccess.Abstraction.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext DbContext;
        protected DbSet<TEntity> Entities;

        public RepositoryBase(DbContext dbContext)
        {
            DbContext = dbContext;
            Entities = dbContext.Set<TEntity>();
        }
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default)
        {
            return Entities.AnyAsync(predicate, cancellation);
        }

        public virtual Task<TOut> ApplyAsync<TOut>(IEndQuery<TEntity, TOut> endQuery, CancellationToken cancellation = default) where TOut : class
        {
            return endQuery.ApplyAsync(Entities, cancellation);
        }

        public virtual async Task<IReadOnlyCollection<TOut>> ApplyAsync<TOut>(IQuery<TEntity, TOut> endQuery, CancellationToken cancellation = default) where TOut : class
        {
            return await endQuery.Apply(Entities, cancellation).ToListAsync();
        }

        public ValueTask<TEntity> FindAsync(object keyId, CancellationToken cancellation = default)
        {
            Type keyIdType = keyId.GetType();
            var publicProps = typeof(TEntity).GetProperties();
            var entityDefinition = DbContext.Model.FindEntityType(typeof(TEntity));
            if (entityDefinition == null)
                throw new InvalidOperationException($"Сущность типа {typeof(TEntity).Name} не является доменной.");

            var primaryKey = entityDefinition.FindPrimaryKey();
            if (primaryKey == null)
                throw new InvalidOperationException($"У сущности {typeof(TEntity).Name} не определен первичный ключ.");

            return Entities.FindAsync(new[] { keyId }, cancellation);
        }
    }
}
