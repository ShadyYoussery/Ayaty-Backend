using Ayaty.Context.Interfaces;

namespace Ayaty.Setup.Dtos.State.StateLanguage
{
    public class StateLanguageDto: ILanguageId
    {
        public short LanguageId { get; set; }
        public string Name { get; set; }
    }
}