using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class StateLanguage
    {
        public int StateId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; }

        public virtual Language Language { get; set; }
        public virtual State State { get; set; }
    }
}
