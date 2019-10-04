using System;
using System.Collections.Generic;

namespace Ayaty.Context.Models
{
    public partial class ClinicUser
    {
        public ClinicUser()
        {
            ClinicUserComminicationWay = new HashSet<ClinicUserComminicationWay>();
            ClinicUserLanguage = new HashSet<ClinicUserLanguage>();
        }

        public int Id { get; set; }
        public int ClinicId { get; set; }
        public string Photo { get; set; }
        public string Username { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] SaltPassword { get; set; }
        public bool IsAdmin { get; set; }

        public virtual Clinic Clinic { get; set; }
        public virtual ICollection<ClinicUserComminicationWay> ClinicUserComminicationWay { get; set; }
        public virtual ICollection<ClinicUserLanguage> ClinicUserLanguage { get; set; }
    }
}
