using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Homeaddress
    {
        public Homeaddress()
        {
            Homeaddresspatients = new HashSet<Homeaddresspatient>();
        }

        public int HomeAddressId { get; set; }
        public string? County { get; set; }
        public string? TownCity { get; set; }
        public string? Postcode { get; set; }
        public string? RoadName { get; set; }
        public string? HouseNumber { get; set; }
        public string? HomeName { get; set; }

        public virtual ICollection<Homeaddresspatient> Homeaddresspatients { get; set; }
    }
}
