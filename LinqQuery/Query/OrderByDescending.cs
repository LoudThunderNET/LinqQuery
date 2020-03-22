using DataAccess.Abstraction.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace LinqQuery.Query
{
    public class OrderByDescending<TIn, TKey> : IQuery<TIn, TIn> where TIn : class
    {
        private readonly IQuery<TIn, TIn> _prevQuery;
        private readonly Expression<Func<TIn, TKey>> _keySelector;

        public OrderByDescending(IQuery<TIn, TIn> prevQuery, Expression<Func<TIn, TKey>> keySelector)
        {
            _prevQuery = prevQuery;
            _keySelector = keySelector;
        }

        public IQueryable<TIn> Apply(IQueryable<TIn> query, CancellationToken cancellation = default)
        {
            return _prevQuery.Apply(query, cancellation).OrderByDescending(_keySelector);
        }
    }
}
