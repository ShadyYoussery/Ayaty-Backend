using Shared.Dto.Paging;

namespace Ayaty.Setup.Dtos.State
{
    public class StateSearchDto : PagingDto
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}