using DataAccess.Abstraction.Query;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LinqQuery.Query
{
    public class First<TIn> : IEndQuery<TIn, TIn> where TIn : class
    {
        private readonly IQuery<TIn, TIn> _prevQuery;

        public First(IQuery<TIn, TIn> prevQuery)
        {
            _prevQuery = prevQuery;
        }

        public Task<TIn> ApplyAsync(IQueryable<TIn> query, CancellationToken cancellation = default)
        {
            return Task.Run(()=> (_prevQuery?.Apply(query, cancellation) ?? query).First(), cancellation);
        }
    }
}
