using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class Language
    {
        public Language()
        {
            CityLanguage = new HashSet<CityLanguage>();
            ClinicLanguage = new HashSet<ClinicLanguage>();
            ClinicPermissionLanguage = new HashSet<ClinicPermissionLanguage>();
            ClinicUserLanguage = new HashSet<ClinicUserLanguage>();
            CountryLanguage = new HashSet<CountryLanguage>();
            StateLanguage = new HashSet<StateLanguage>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<CityLanguage> CityLanguage { get; set; }
        public virtual ICollection<ClinicLanguage> ClinicLanguage { get; set; }
        public virtual ICollection<ClinicPermissionLanguage> ClinicPermissionLanguage { get; set; }
        public virtual ICollection<ClinicUserLanguage> ClinicUserLanguage { get; set; }
        public virtual ICollection<CountryLanguage> CountryLanguage { get; set; }
        public virtual ICollection<StateLanguage> StateLanguage { get; set; }
    }
}
