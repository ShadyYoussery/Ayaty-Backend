using System.Collections.Generic;
using Ayaty.Setup.Dtos.State.StateLanguage;

namespace Ayaty.Setup.Dtos.State
{
    public class StateAddEditDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public IEnumerable<StateLanguageDto> StateLanguages { get; set; }
    }
}