﻿using DataAccess.Abstraction.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;

namespace LinqQuery.EntityFramework.Query
{
    public class NoTracking<TIn, TOut> : IQuery<TIn, TOut> where TIn: class where TOut : class
    {
        private readonly IQuery<TIn, TOut> _query;

        public NoTracking(IQuery<TIn, TOut> query)
        {
            _query = query;
        }

        public IQueryable<TOut> Apply(IQueryable<TIn> query, CancellationToken cancellation = default)
        {
            return _query.Apply(query, cancellation).AsNoTracking();
        }
    }
}
