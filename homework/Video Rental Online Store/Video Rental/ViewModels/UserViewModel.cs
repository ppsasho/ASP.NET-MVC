using Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public SubscriptionType? SubscriptionType { get; set; }
    }
}
