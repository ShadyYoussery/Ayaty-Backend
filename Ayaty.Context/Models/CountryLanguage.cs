using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class CountryLanguage
    {
        public int CountryId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual Language Language { get; set; }
    }
}
