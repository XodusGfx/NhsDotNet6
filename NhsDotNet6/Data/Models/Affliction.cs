using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Affliction
    {
        public int AfflictionId { get; set; }
        public int AfflictionTypeAfflictionTypeId { get; set; }
        public int AfflictionCatrgoryAfflictionCatrgoryId { get; set; }
        public int PatientPatientId { get; set; }

        public virtual Afflictioncatrgory AfflictionCatrgoryAfflictionCatrgory { get; set; } = null!;
        public virtual Afflictiontype AfflictionTypeAfflictionType { get; set; } = null!;
        public virtual Patient PatientPatient { get; set; } = null!;
    }
}
