using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Patientlogin
    {
        public string PatientLoginId { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; } = null!;
    }
}
