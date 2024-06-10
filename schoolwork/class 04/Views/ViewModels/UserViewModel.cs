namespace ViewModels
{
    public class UserViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Id { get; set; }
        public UserViewModel(string firstname, string lastname, int id)
        {

            Firstname = firstname;
            Lastname = lastname;
            Id = id;
        }
    }
}
