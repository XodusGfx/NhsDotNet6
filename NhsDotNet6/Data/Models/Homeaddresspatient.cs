using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Homeaddresspatient
    {
        public int HomeAddressPatientId { get; set; }
        public int? PatientId { get; set; }
        public int? HomeAddressId { get; set; }

        public virtual Homeaddress? HomeAddress { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
