using Models.Enums;

namespace Models
{
    public class User : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public User(string firstName, string lastName, string password, string email, int age, SubscriptionType subscriptionType)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            CreatedOn = DateTime.UtcNow;
            Email = email;
            Age = age;
            SubscriptionType = subscriptionType;
        }
        public void SetSubscriptionType(SubscriptionType subType)
        {
            SubscriptionType = subType;
        }
        public void RemoveSubscription()
        {
            SubscriptionType = SubscriptionType.None;
        }

    }
}
