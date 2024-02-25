using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Specialization
    {
        public int SpecId { get; set; }
        public string? SpecName { get; set; }
        public int StaffStaffId { get; set; }

        public virtual Staff StaffStaff { get; set; } = null!;
    }
}
