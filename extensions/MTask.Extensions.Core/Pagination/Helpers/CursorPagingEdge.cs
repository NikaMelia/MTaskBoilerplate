namespace MTask.Extensions.Core.Pagination.Helpers
{
    
    public class CursorPagingEdge<TResult> 
    {
        public CursorPagingEdge(string cursor, TResult node)
        {
            Cursor = cursor;
            Node = node;
        }

        public string Cursor { get; set; }
        public TResult Node { get; set; }
    }
}
