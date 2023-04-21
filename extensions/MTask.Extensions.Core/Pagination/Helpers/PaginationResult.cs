using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MTask.Extensions.Core.Pagination.Helpers
{


    public class PaginationResult<T>
    {
        private readonly Func<CancellationToken, ValueTask<int>> _getTotalCount;

        public PaginationResult(
            IReadOnlyCollection<CursorPagingEdge<T>> edges,
            CursorPagingPageInfo info,
            Func<CancellationToken, ValueTask<int>> getTotalCount)
        {
            _getTotalCount = getTotalCount;
            Edges = edges;
            Info = info;
        }

        public PaginationResult(
            IReadOnlyCollection<CursorPagingEdge<T>> edges,
            CursorPagingPageInfo info,
            int totalCount = 0)
        {
            Edges = edges;
            Info = info;
            _getTotalCount = _ => new(totalCount);
        }

        /// <summary>
        /// The edges that belong to this connection.
        /// </summary>
        public IReadOnlyCollection<CursorPagingEdge<T>> Edges { get; }

        public CursorPagingPageInfo Info { get; }

        public ValueTask<int> GetTotalCountAsync(CancellationToken cancellationToken) =>
            _getTotalCount(cancellationToken);
    }
}