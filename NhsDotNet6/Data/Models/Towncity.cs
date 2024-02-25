using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Towncity
    {
        public Towncity()
        {
            Hospitals = new HashSet<Hospital>();
        }

        public int TownCityId { get; set; }
        public string? TownCityName { get; set; }
        public int CountyCountyId { get; set; }

        public virtual County CountyCounty { get; set; } = null!;
        public virtual ICollection<Hospital> Hospitals { get; set; }
    }
}
