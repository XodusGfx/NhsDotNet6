using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Afflictioncatrgory
    {
        public Afflictioncatrgory()
        {
            Afflictions = new HashSet<Affliction>();
        }

        public int AfflictionCatrgoryId { get; set; }
        public string? AfflictionCatrgoryName { get; set; }

        public virtual ICollection<Affliction> Afflictions { get; set; }
    }
}
