using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class ClinicUserComminicationWay
    {
        public int Id { get; set; }
        public int ClinetUserId { get; set; }
        public int CommincationWayId { get; set; }
        public int ClinicId { get; set; }
        public string Value { get; set; }
        public bool IsVisable { get; set; }

        public virtual ClinicUser Clin { get; set; }
        public virtual CommincationWay Clinic { get; set; }
    }
}
