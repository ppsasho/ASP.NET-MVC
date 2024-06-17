using Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class UserViewModel
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public SubscriptionType? SubscriptionType { get; set; }

        public UserViewModel(string? firstName = null, string? lastName = null, int age = 0, string? username = null, string? email = null, string? password = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Username = username;
            Email = email;
            Password = password;
        }
        public UserViewModel()
        {

        }
    }
}
