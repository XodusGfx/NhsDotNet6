using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Homeaddressstaff
    {
        public int HomeAddressId { get; set; }
        public string? County { get; set; }
        public string? TownCity { get; set; }
        public string? Postcode { get; set; }
        public string? RoadName { get; set; }
        public string? HouseNumber { get; set; }
        public string? HomeName { get; set; }
    }
}
