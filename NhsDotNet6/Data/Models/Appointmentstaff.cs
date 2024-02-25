using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Appointmentstaff
    {
        public Appointmentstaff()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int AppointmentStaffId { get; set; }
        public int StaffStaffId { get; set; }

        public virtual Staff StaffStaff { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
