using DataAccess.Abstraction.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LinqQuery.EntityFramework.Query
{
    public class FirstOrDefaultAsync<TIn> : IEndQuery<TIn, TIn> where TIn: class
    {
        private readonly IQuery<TIn, TIn> _prevQuery;

        public FirstOrDefaultAsync(IQuery<TIn, TIn> prevQuery)
        {
            _prevQuery = prevQuery;
        }

        public Task<TIn> ApplyAsync(IQueryable<TIn> query, CancellationToken cancellation = default)
        {
            return _prevQuery.Apply(query, cancellation).FirstOrDefaultAsync(cancellation);
        }
    }
}
