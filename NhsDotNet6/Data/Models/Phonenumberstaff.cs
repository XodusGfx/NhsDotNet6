using System;
using System.Collections.Generic;

namespace NhsDotNet6.Data.Models
{
    public partial class Phonenumberstaff
    {
        public int PhoneNumberId { get; set; }
        public int PhoneNumber { get; set; }
        public int StaffStaffId { get; set; }

        public virtual Staff StaffStaff { get; set; } = null!;
    }
}
