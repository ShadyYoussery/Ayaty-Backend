using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class ClinicLanguage
    {
        public int ClinicId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public virtual Clinic Clinic { get; set; }
        public virtual Language Language { get; set; }
    }
}
