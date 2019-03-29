using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public Role Role { get; set; }
    }
}
