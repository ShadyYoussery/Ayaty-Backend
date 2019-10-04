using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class CityLanguage
    {
        public int CityId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; }

        public virtual City City { get; set; }
        public virtual Language Language { get; set; }
    }
}
