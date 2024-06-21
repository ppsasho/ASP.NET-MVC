using Models;
using ViewModels;

namespace Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToModel(this User user)
        {
            var viewModel = new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Email = user.Email,
                Password = user.Password,
                SubscriptionType = user.SubscriptionType,
            };
            return viewModel;
        }
    }
}
