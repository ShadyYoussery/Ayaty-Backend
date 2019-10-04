using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class Clinic
    {
        public Clinic()
        {
            ClinicComminicationWay = new HashSet<ClinicComminicationWay>();
            ClinicLanguage = new HashSet<ClinicLanguage>();
            ClinicUser = new HashSet<ClinicUser>();
        }

        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Logo { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<ClinicComminicationWay> ClinicComminicationWay { get; set; }
        public virtual ICollection<ClinicLanguage> ClinicLanguage { get; set; }
        public virtual ICollection<ClinicUser> ClinicUser { get; set; }
    }
}
