using DataAccess.Abstraction.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace LinqQuery.Query
{
    public class Where<TIn> : IQuery<TIn, TIn> where TIn : class
    {
        private readonly Expression<Func<TIn, bool>> _predicate;
        private readonly IQuery<TIn, TIn> _prevQuery;

        public Where(Expression<Func<TIn, bool>> predicate, IQuery<TIn, TIn> prevQuery)
        {
            _predicate = predicate;
            this._prevQuery = prevQuery;
        }

        public IQueryable<TIn> Apply(IQueryable<TIn> query, CancellationToken cancellation = default)
        {
            return _prevQuery.Apply(query).Where(_predicate);
        }
    }
}
