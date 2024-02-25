using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Hospital
    {
        public Hospital()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int HospitalId { get; set; }
        public string? Postcode { get; set; }
        public string? HospitalName { get; set; }
        public int TowncityTownCityId { get; set; }
        public int TowncityCountyCountyId { get; set; }

        public virtual Towncity Towncity { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
