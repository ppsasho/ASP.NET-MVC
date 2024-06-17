using Models;
namespace Storage
{
    public static class CurrentSession
    {
        public static User? CurrentUser;

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