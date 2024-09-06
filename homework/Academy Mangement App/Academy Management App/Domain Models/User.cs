using Domain_Models.Enums;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain_Models
{
    public class User : IdentityUser
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Role Role { get; set; }
    }
}
