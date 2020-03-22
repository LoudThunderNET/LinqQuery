using DataAccess.Abstraction.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace LinqQuery.Query
{
    public class Select<TIn, TOut> : IQuery<TIn, TOut> where TIn : class where TOut : class
    {
        private readonly IQuery<TIn, TIn> _prevQuery;
        private readonly Expression<Func<TIn, TOut>> _proj;

        public Select(Expression<Func<TIn, TOut>> proj, IQuery<TIn, TIn> prevQuery)
        {
            _prevQuery = prevQuery;
            _proj = proj;
        }

        public IQueryable<TOut> Apply(IQueryable<TIn> query, CancellationToken cancellation = default)
        {
            return _prevQuery.Apply(query).Select(_proj);
        }
    }
}
