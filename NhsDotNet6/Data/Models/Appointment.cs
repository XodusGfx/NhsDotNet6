using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Appointment
    {
        public string AppointmentId { get; set; } = null!;
        public int HospitalHospitalId { get; set; }
        public int HospitalTowncityTownCityId { get; set; }
        public int HospitalTowncityCountyCountyId { get; set; }
        public int PatientPatientId { get; set; }
        public int AppointmentstaffAppointmentStaffId { get; set; }
        public int AppointmentstaffStaffStaffId { get; set; }
        public int AppointmenttimeAppointmentTimeId { get; set; }

        public virtual Appointmentstaff Appointmentstaff { get; set; } = null!;
       // public virtual Appointmenttime AppointmenttimeAppointmentTime { get; set; } = null!;
        public virtual Hospital Hospital { get; set; } = null!;
        public virtual Patient PatientPatient { get; set; } = null!;
    }
}
