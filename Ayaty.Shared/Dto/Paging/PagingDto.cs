namespace Ayaty.Shared.Dto.Paging
{
    public class PagingDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool IsFullData { get; set; }
    }
}