using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhsDotNet6.Data.Models
{
    public partial class Appointmenttime
    {
        public Appointmenttime()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int AppointmentTimeId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateOnly StartTime { get; set; }
        public DateOnly EndTime { get; set; }
        public DateOnly? DurationTime { get; set; }
        public DateOnly EstWaitTime { get; set; }
        public DateOnly WaitTime { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
