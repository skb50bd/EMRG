using Microsoft.AspNetCore.Identity;
using System;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public Nullable<int> DepartmentId { get; set; }
        public Department Department { get; set; }
        public Role Role { get; set; }
    }
}
