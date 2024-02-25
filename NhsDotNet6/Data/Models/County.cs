using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class County
    {
        public County()
        {
            Towncities = new HashSet<Towncity>();
        }

        public int CountyId { get; set; }
        public string? CountyName { get; set; }

        public virtual ICollection<Towncity> Towncities { get; set; }
    }
}
