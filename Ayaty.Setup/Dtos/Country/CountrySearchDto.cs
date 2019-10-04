using Shared.Dto.Paging;

namespace Ayaty.Setup.Dtos.Country
{
    public class CountrySearchDto : PagingDto
    {
        public string Name { get; set; }
    }
}