using DataAccess.Abstraction.Query;
using System.Linq;
using System.Threading;

namespace LinqQuery.Query
{
    internal class Nop<TIn> : IQuery<TIn, TIn> where TIn : class
    {
        public IQueryable<TIn> Apply(IQueryable<TIn> query, CancellationToken cancellation = default)
        {
            return query;
        }
    }
}
