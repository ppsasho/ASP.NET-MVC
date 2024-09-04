using Domain_Models.Enums;

namespace Domain_Models
{
    public class User : BaseEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Role Role { get; set; }
    }
}
