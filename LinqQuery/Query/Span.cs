using DataAccess.Abstraction.Query;
using System;
using System.Linq;
using System.Threading;

namespace LinqQuery.Query
{
    public class Span<TIn> : IQuery<TIn, TIn> where TIn : class
    {
        private readonly IQuery<TIn, TIn> _prevQuery;
        private readonly int _skip;
        private readonly int _take;

        /// <summary>
        /// Инициализирует экземпляр <see cref="Span{TIn}"/>.
        /// </summary>
        /// <param name="prevQuery">Предыдущий запрос.</param>
        /// <param name="pageNo">Номер страницы (нумерация с 0).</param>
        /// <param name="pageSize">Размер страницы.</param>
        public Span(IQuery<TIn, TIn> prevQuery, int pageSize, int pageNo = 0)
        {
            _prevQuery = prevQuery;
            if (pageNo < 0)
                throw new ArgumentException("Номер страницы не может быть отрицательным.");

            if(pageSize <= 0)
                throw new ArgumentException("Размер страницы должен быть положительным.");


            _skip = pageNo * pageSize;
            _take = pageSize;
        }

        public IQueryable<TIn> Apply(IQueryable<TIn> query, CancellationToken cancellation = default)
        {
            return _prevQuery.Apply(query, cancellation).Skip(_skip).Take(_take);
        }
    }
}
