using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Abstraction.Query
{
    public interface IEndQuery<TIn, TOut>
    {
        Task<TOut> ApplyAsync(IQueryable<TIn> query, CancellationToken cancellation = default);
    }
}
