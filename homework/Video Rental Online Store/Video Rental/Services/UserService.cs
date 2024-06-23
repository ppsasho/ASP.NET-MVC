using Mappers;
using Models;
using Storage;
using Storage.Implementations;
using ViewModels;

namespace Services
{
    public class UserService
    {
        private readonly UserStorage _userStorage;
        public UserViewModel GetCurrentUser()
        {
            var user = CurrentSession.CurrentUser;
            if(user != null) return new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
            };
            else
            {
                return new UserViewModel()
                {
                    FirstName = null,
                    LastName = null,
                };
            }
        }
        public UserService() 
        {
            _userStorage = new UserStorage();
        }
        public List<UserViewModel> GetAll()
        {
            var users = _userStorage.GetAll();
            return users.Select(x => x.ToModel()).ToList();
        }
        public void NewRegister(UserViewModel model)
        {
            var user = new User(model.FirstName, model.LastName, model.Password, model.Email, model.Age);
            _userStorage.Add(user);
        }
        public void Login(LogInViewModel model)
        {
            var users = _userStorage.GetAll();
            if (!users.Any(x => x.Email == model.Email)) throw new Exception($"User with email {model.Email} was not found!");
            var found = users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password) ?? throw new Exception("Incorrect user credentials!");
            CurrentSession.Set(found);
        }
        public void LogOut()
        {
            CurrentSession.Remove();
        }
    }
}
