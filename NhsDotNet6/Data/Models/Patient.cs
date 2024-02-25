using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Afflictions = new HashSet<Affliction>();
            Appointments = new HashSet<Appointment>();
            Homeaddresspatients = new HashSet<Homeaddresspatient>();
            Patientlogins = new HashSet<Patientlogin>();
        }

        public int PatientId { get; set; }
        public string? PatientFirstName { get; set; }
        public string? PatientLastName { get; set; }
        public string? PatientSex { get; set; }
        //public DateOnly PatientDateOfBirth { get; set; }

        public virtual ICollection<Affliction> Afflictions { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Homeaddresspatient> Homeaddresspatients { get; set; }
        public virtual ICollection<Patientlogin> Patientlogins { get; set; }
    }
}
