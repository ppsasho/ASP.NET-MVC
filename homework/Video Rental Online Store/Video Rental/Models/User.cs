namespace Models
{
    public class User : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int CardNumber { get; set; }
        public string Email { get; set; }

        public User(string firstName, string lastName, string username, string password, int cardNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            CardNumber = cardNumber;
            Email = email;
        }

    }
}
