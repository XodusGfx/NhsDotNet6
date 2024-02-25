using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Stafflogin
    {
        public string StaffLoginId { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int StaffStaffId { get; set; }

        public virtual Staff StaffStaff { get; set; } = null!;
    }
}
