namespace MTask.Extensions.Core.Pagination.Helpers
{
    
    public class CursorPagingRequest
    {
        public string? After { get; set; }
        public int? First { get; set; }
        
        public string?  Before { get; set; }
        public int? Last { get; set; }
    }
}
