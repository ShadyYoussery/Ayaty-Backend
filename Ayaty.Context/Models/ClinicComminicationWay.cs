using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class ClinicComminicationWay
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int CommincationWayId { get; set; }
        public string Value { get; set; }

        public virtual Clinic Clinic { get; set; }
        public virtual CommincationWay ClinicNavigation { get; set; }
    }
}
