using ViewModels;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public UserViewModel GetCurrentUser();
        public void UpdateUser();
        public void NewRegister(UserViewModel model);
        public void Login(LogInViewModel model);
        public void LogOut();
        public List<UserViewModel> GetAll();
    }
}
