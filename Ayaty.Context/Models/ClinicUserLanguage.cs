using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class ClinicUserLanguage
    {
        public int Id { get; set; }
        public int ClinetUserId { get; set; }
        public int ClinicId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; }

        public virtual ClinicUser Clin { get; set; }
        public virtual Language Language { get; set; }
    }
}
