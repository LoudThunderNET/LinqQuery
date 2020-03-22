using System;
using System.Linq;
using System.Threading;

namespace DataAccess.Abstraction.Query
{
    public interface IQuery<TIn, TOut> where TIn : class where TOut: class
    {
        IQueryable<TOut> Apply(IQueryable<TIn> query, CancellationToken cancellation = default);
    }
}
