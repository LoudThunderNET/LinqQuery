using DataAccess.Abstraction.Query;
using LinqQuery.EntityFramework.Query;
using LinqQuery.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LinqQuery.EntityFramework.Extensions
{
    public static class QueryExtensions
    {
        #region First

        public static IEndQuery<TIn, TOut> FirstAsync<TIn, TOut>(this IQuery<TIn, TOut> query) where TIn : class where TOut : class
        {
            return new SelectEndQuery<TIn, TOut>(query, new FirstAsync<TOut>(null));
        }

        public static IEndQuery<TIn, TIn> FirstAsync<TIn>(this IQuery<TIn, TIn> query) where TIn : class
        {
            return new FirstAsync<TIn>(query);
        }

        #endregion

        #region FirstOrDefault

        public static IEndQuery<TIn, TOut> FirstOrDefaultAsync<TIn, TOut>(this IQuery<TIn, TOut> query) where TIn : class where TOut : class
        {
            return new SelectEndQuery<TIn, TOut>(query, new FirstOrDefaultAsync<TOut>(null));
        }

        public static IEndQuery<TIn, TIn> FirstOrDefaultAsync<TIn>(this IQuery<TIn, TIn> query) where TIn : class
        {
            return new FirstOrDefaultAsync<TIn>(query);
        }

        #endregion

        #region Single

        public static IEndQuery<TIn, TOut> SingleAsync<TIn, TOut>(this IQuery<TIn, TOut> query) where TIn : class where TOut : class
        {
            return new SelectEndQuery<TIn, TOut>(query, new SingleAsync<TOut>(null));
        }

        public static IEndQuery<TIn, TIn> SingleAsync<TIn>(this IQuery<TIn, TIn> query) where TIn : class
        {
            return new SingleAsync<TIn>(query);
        }

        #endregion

        #region SingleOrDefault

        public static IEndQuery<TIn, TOut> SingleOrDefaultAsync<TIn, TOut>(this IQuery<TIn, TOut> query) where TIn : class where TOut : class
        {
            return new SelectEndQuery<TIn, TOut>(query, new SingleOrDefaultAsync<TOut>(null));
        }

        public static IEndQuery<TIn, TIn> SingleOrDefaultAsync<TIn>(this IQuery<TIn, TIn> query) where TIn : class
        {
            return new SingleOrDefaultAsync<TIn>(query);
        }

        #endregion
    }
}
