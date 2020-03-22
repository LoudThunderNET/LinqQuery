using DataAccess.Abstraction.Query;
using LinqQuery.EntityFramework.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinqQuery.EntityFramework.Query.Visitors
{
    public class NoTrackingVisitor
    {
        public static void Visit<TIn, TOut>(IQuery<TIn, TOut> query) where TIn : class where TOut : class
        { 
            query = new NoTracking<TIn, TOut>(query);
        }

        public static void Visit<TIn, TOut>(IEndQuery<TIn, TOut> query) where TIn : class where TOut : class
        {
            query = new NoTrackingEndQuery<TIn, TOut>(query);
        }
    }
}
