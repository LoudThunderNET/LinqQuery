using DataAccess.Abstraction.Query;
using LinqQuery.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LinqQuery.Extensions
{
    public static class QueryExtensions
    {
        public static IQuery<TIn, TIn> Query<TIn>() where TIn : class
        {
            return new Nop<TIn>();
        }

        public static IQuery<TIn, TIn> Where<TIn>(this IQuery<TIn, TIn> query, Expression<Func<TIn, bool>> predicate) where TIn : class
        {
            return new Where<TIn>(predicate, query);
        }

        #region Select

        public static IQuery<TIn, TOut> Select<TIn, TOut>(this IQuery<TIn, TIn> query, Expression<Func<TIn, TOut>> projection) where TIn : class where TOut : class
        {
            return new Select<TIn, TOut>(projection, query);
        }

        public static IQuery<TIn, TOut> SelectMany<TIn, TOut>(this IQuery<TIn, TIn> query, Expression<Func<TIn, IEnumerable<TOut>>> projection) where TIn : class where TOut : class
        {
            return new SelectMany<TIn, TOut>(query, projection);
        }

        #endregion

        #region First

        public static IEndQuery<TIn, TOut> First<TIn, TOut>(this IQuery<TIn, TOut> query) where TIn : class where TOut : class
        {
            return new SelectEndQuery<TIn, TOut>(query, new First<TOut>(null));
        }

        public static IEndQuery<TIn, TIn> First<TIn>(this IQuery<TIn, TIn> query) where TIn : class
        {
            return new First<TIn>(query);
        }

        #endregion

        #region FirstOrDefault

        public static IEndQuery<TIn, TOut> FirstOrDefault<TIn, TOut>(this IQuery<TIn, TOut> query) where TIn : class where TOut : class
        {
            return new SelectEndQuery<TIn, TOut>(query, new FirstOrDefault<TOut>(null));
        }

        public static IEndQuery<TIn, TIn> FirstOrDefault<TIn>(this IQuery<TIn, TIn> query) where TIn : class
        {
            return new FirstOrDefault<TIn>(query);
        }

        #endregion

        #region Single

        public static IEndQuery<TIn, TOut> Single<TIn, TOut>(this IQuery<TIn, TOut> query) where TIn : class where TOut : class
        {
            return new SelectEndQuery<TIn, TOut>(query, new Single<TOut>(null));
        }

        public static IEndQuery<TIn, TIn> Single<TIn>(this IQuery<TIn, TIn> query) where TIn : class
        {
            return new Single<TIn>(query);
        }

        #endregion

        #region SingleOrDefault

        public static IEndQuery<TIn, TOut> SingleOrDefault<TIn, TOut>(this IQuery<TIn, TOut> query) where TIn : class where TOut : class
        {
            return new SelectEndQuery<TIn, TOut>(query, new SingleOrDefault<TOut>(null));
        }

        public static IEndQuery<TIn, TIn> SingleOrDefault<TIn>(this IQuery<TIn, TIn> query) where TIn : class
        {
            return new SingleOrDefault<TIn>(query);
        }

        #endregion

        public static IQuery<TIn, TIn> OrderBy<TIn, TKey>(this IQuery<TIn, TIn> query, Expression<Func<TIn, TKey>> keySelector) where TIn : class
        {
            return new OrderBy<TIn, TKey>(query, keySelector);
        }

        public static IQuery<TIn, TIn> OrderByDescending<TIn, TKey>(this IQuery<TIn, TIn> query, Expression<Func<TIn, TKey>> keySelector) where TIn : class
        {
            return new OrderByDescending<TIn, TKey>(query, keySelector);
        }
    }
}
