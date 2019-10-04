using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class City
    {
        public City()
        {
            CityLanguage = new HashSet<CityLanguage>();
            Clinic = new HashSet<Clinic>();
        }

        public int Id { get; set; }
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<CityLanguage> CityLanguage { get; set; }
        public virtual ICollection<Clinic> Clinic { get; set; }
    }
}
