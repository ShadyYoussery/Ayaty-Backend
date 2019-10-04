using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class ClinicPermissionLanguage
    {
        public int ClinicPermissionId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; }

        public virtual ClinicPermission ClinicPermission { get; set; }
        public virtual Language Language { get; set; }
    }
}
