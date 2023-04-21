using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MTask.Extensions.Core.Pagination.Helpers;

namespace MTask.Extensions.Core.Pagination
{
    public static class EnumerableExtensions
    {
        public static IOrderedQueryable<T> OrderByDirection<T, TKey>(this IQueryable<T> source, Expression<Func<T, TKey>> selector, OrderDirection orderDirection)
        {
            return orderDirection == OrderDirection.Asc ? source.OrderBy(selector) : source.OrderByDescending(selector);
        }

        public static async Task<PaginationResult<T>> ApplySlicingAsync<T>(
            this IQueryable<T> source, 
            CursorPagingRequest pagingRequest,
            CancellationToken cancellationToken = default)
        {
            CursorPaginationAlgorithm<T> cursorPaginationAlgorithm = new CursorPaginationAlgorithm<T>();
            var pagedResult = await cursorPaginationAlgorithm.ApplyPaginationAsync(source, pagingRequest, cancellationToken);
            return pagedResult;
        }
    }
}

