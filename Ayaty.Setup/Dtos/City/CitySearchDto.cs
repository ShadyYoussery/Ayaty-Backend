using Shared.Dto.Paging;

namespace Ayaty.Setup.Dtos.City
{
    public class CitySearchDto : PagingDto
    {
        public int StateId { get; set; }
        public string Name { get; set; }
    }
}