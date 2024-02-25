using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Afflictiontype
    {
        public Afflictiontype()
        {
            Afflictions = new HashSet<Affliction>();
        }

        public int AfflictionTypeId { get; set; }
        public string? AfflictionTypeName { get; set; }

        public virtual ICollection<Affliction> Afflictions { get; set; }
    }
}
