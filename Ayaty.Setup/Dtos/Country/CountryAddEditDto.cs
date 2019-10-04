using System.Collections.Generic;
using Ayaty.Setup.Dtos.Country.CountryLanguage;

namespace Ayaty.Setup.Dtos.Country
{
    public class CountryAddEditDto
    {
        public int Id { get; set; }

        public IEnumerable<CountryLanguageDto> CountryLanguages { get; set; }
    }
}