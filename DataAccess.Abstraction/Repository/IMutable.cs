using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Abstraction.Repository
{
    public interface IMutable<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellation = default);
        Task AddRangeAsync(IEnumerable<TEntity> entity, CancellationToken cancellation = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellation = default);
        Task UpdateRangeAsync(IEnumerable<TEntity> entity, CancellationToken cancellation = default);
        Task SaveChangesAsync(CancellationToken cancellation = default);
    }
}
