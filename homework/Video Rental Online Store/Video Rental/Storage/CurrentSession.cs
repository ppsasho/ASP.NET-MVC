using Models;

namespace Storage
{
    public static class CurrentSession 
    {
        public static User? CurrentUser { get; set; }
        public static void Set(User user)
        {
            CurrentUser = user;
        }
        public static void Remove()
        {
            CurrentUser = null;
        }

    }
}
