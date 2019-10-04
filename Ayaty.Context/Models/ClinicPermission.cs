using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class ClinicPermission
    {
        public ClinicPermission()
        {
            ClinicPermissionLanguage = new HashSet<ClinicPermissionLanguage>();
        }

        public int Id { get; set; }

        public virtual ICollection<ClinicPermissionLanguage> ClinicPermissionLanguage { get; set; }
    }
}
