namespace Models
{
    public class User : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int Age { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }

        public User(string firstName, string lastName, string username, string password, string email, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            CreatedOn = DateTime.UtcNow;
            Email = email;
            Age = age;
        }

    }
}
