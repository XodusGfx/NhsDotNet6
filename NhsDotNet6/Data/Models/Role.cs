using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Role
    {
        public Role()
        {
            Staff = new HashSet<Staff>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
    }
}
