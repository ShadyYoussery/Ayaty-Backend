using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
            StateLanguage = new HashSet<StateLanguage>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<StateLanguage> StateLanguage { get; set; }
    }
}
