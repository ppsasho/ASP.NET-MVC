using ViewModels;

namespace Views
{
    public static class StaticDb
    {
        public static List<UserViewModel> Users { get; set; }
        static StaticDb()
        {
            var user1 = new UserViewModel("Sasho", "Popovski", 1);
            var user2 = new UserViewModel("David", "Davidsky", 2);
            var user3 = new UserViewModel("Bob", "Bobsky", 3);
            Users = new List<UserViewModel>() { user1, user2, user3 };
        }
    }
}
