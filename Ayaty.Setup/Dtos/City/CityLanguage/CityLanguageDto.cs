using Ayaty.Context.Interfaces;

namespace Ayaty.Setup.Dtos.City.CityLanguage
{
    public class CityLanguageDto : ILanguageId
    {
        public short LanguageId { get; set; }
        public string Name { get; set; }
    }
}