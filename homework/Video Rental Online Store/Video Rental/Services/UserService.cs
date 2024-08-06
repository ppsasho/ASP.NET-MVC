using Mappers;
using Models;
using Services.Interfaces;
using Storage;
using Storage.Implementations;
using Storage.Interfaces;
using ViewModels;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserStorage _userStorage;
        public UserService(IUserStorage storage) 
        {
            _userStorage = storage;
        }
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
        public void UpdateUser()
        {
            _userStorage.Update(CurrentSession.CurrentUser);
        }
        public List<UserViewModel> GetAll()
        {
            var users = _userStorage.GetAll();
            return users.Select(x => x.ToModel()).ToList();
        }
        public void NewRegister(UserViewModel model)
        {
            var user = new User(model.FirstName, model.LastName, model.Password, model.Email, model.Age, Models.Enums.SubscriptionType.None);
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
