using DataAccess.Abstraction.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinqQuery.EntityFramework.Query
{
    internal class TrackingEndQuery<TIn, TOut> : IEndQuery<TIn, TOut> where TIn : class where TOut : class
    {
        private readonly IEndQuery<TIn, TOut> _query;

        public TrackingEndQuery(IEndQuery<TIn, TOut> query)
        {
            _query = query;
        }

        public Task<TOut> ApplyAsync(IQueryable<TIn> query, CancellationToken cancellation = default)
        {
            return _query.ApplyAsync(query.AsNoTracking(), cancellation);
        }
    }
}
