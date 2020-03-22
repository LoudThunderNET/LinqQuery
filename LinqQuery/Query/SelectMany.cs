using DataAccess.Abstraction.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace LinqQuery.Query
{
    public class SelectMany<TIn, TOut> : IQuery<TIn, TOut> where TIn : class where TOut : class
    {
        private readonly IQuery<TIn, TIn> _prevQuery;
        private readonly Expression<Func<TIn, IEnumerable<TOut>>> _proj;

        public SelectMany(IQuery<TIn, TIn> prevQuery, Expression<Func<TIn, IEnumerable<TOut>>> proj)
        {
            _prevQuery = prevQuery;
            _proj = proj;
        }

        public IQueryable<TOut> Apply(IQueryable<TIn> query, CancellationToken cancellation = default)
        {
            return _prevQuery.Apply(query).SelectMany(_proj);
        }
    }
}
