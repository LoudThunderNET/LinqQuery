using DataAccess.Abstraction.Query;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LinqQuery.Query
{
    public class SelectEndQuery<TIn, TOut> : IEndQuery<TIn, TOut> where TIn : class where TOut : class
    {
        private readonly IQuery<TIn, TOut> _selectQuery;
        private readonly IEndQuery<TOut, TOut> _endQuery;

        public SelectEndQuery(IQuery<TIn, TOut> selectQuery, IEndQuery<TOut, TOut> endQuery)
        {
            _selectQuery = selectQuery;
            _endQuery = endQuery;
        }

        public Task<TOut> ApplyAsync(IQueryable<TIn> query, CancellationToken cancellation = default)
        {
            return _endQuery.ApplyAsync(_selectQuery.Apply(query), cancellation);
        }
    }
}
