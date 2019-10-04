using System.Collections.Generic;
using Ayaty.Setup.Dtos.City.CityLanguage;

namespace Ayaty.Setup.Dtos.City
{
    public class CityAddEditDto
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public IEnumerable<CityLanguageDto> CityLanguages { get; set; }
    }
}