using Ayaty.Context.Interfaces;

namespace Ayaty.Setup.Dtos.Country.CountryLanguage
{
    public class CountryLanguageDto: ILanguageId
    {
        public short LanguageId { get; set; }
        public string Name { get; set; }
    }
}