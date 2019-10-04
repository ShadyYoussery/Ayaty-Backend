using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class CommincationWay
    {
        public CommincationWay()
        {
            ClinicComminicationWay = new HashSet<ClinicComminicationWay>();
            ClinicUserComminicationWay = new HashSet<ClinicUserComminicationWay>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ClinicComminicationWay> ClinicComminicationWay { get; set; }
        public virtual ICollection<ClinicUserComminicationWay> ClinicUserComminicationWay { get; set; }
    }
}
