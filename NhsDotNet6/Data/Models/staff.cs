using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Appointmentstaffs = new HashSet<Appointmentstaff>();
            Phonenumberstaffs = new HashSet<Phonenumberstaff>();
            Specializations = new HashSet<Specialization>();
            Stafflogins = new HashSet<Stafflogin>();
        }

        public int StaffId { get; set; }
        public string? NameF { get; set; }
        public string? NameL { get; set; }
        public int? Age { get; set; }
        public int? RoleRoleId { get; set; }

        public virtual Role? RoleRole { get; set; }
        public virtual ICollection<Appointmentstaff> Appointmentstaffs { get; set; }
        public virtual ICollection<Phonenumberstaff> Phonenumberstaffs { get; set; }
        public virtual ICollection<Specialization> Specializations { get; set; }
        public virtual ICollection<Stafflogin> Stafflogins { get; set; }
    }
}
