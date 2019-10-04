using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class Country
    {
        public Country()
        {
            CountryLanguage = new HashSet<CountryLanguage>();
            State = new HashSet<State>();
        }

        public int Id { get; set; }

        public virtual ICollection<CountryLanguage> CountryLanguage { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}
