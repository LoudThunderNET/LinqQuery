using DataAccess.Abstraction.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinqQuery.EntityFramework.Query.Visitors
{
    public class TrackingVisitor
    {
        public static void Visit<TIn, TOut>(IQuery<TIn, TOut> query) where TIn : class where TOut : class
        { 
            query = new Tracking<TIn, TOut>(query);
        }

        public static void Visit<TIn, TOut>(IEndQuery<TIn, TOut> query) where TIn : class where TOut : class
        {
            query = new TrackingEndQuery<TIn, TOut>(query);
        }
    }
}
