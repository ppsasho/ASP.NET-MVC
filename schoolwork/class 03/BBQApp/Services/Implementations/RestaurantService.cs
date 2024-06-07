using DataAccess.Implementations;
using DataAccess.Interfaces;
using DomainModels;
using Services.Interfaces;
using ViewModels;

namespace Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurantRepository;
        public RestaurantService()
        {
            _restaurantRepository = new RestaurantRepository();
        }
        public RestaurantViewModel GetRestaurantDetails()
        {
            var restaurant = _restaurantRepository.GetAll().First() ?? throw new Exception("Restaurant was not found!");
            var RestaurantMenuViewModel = new RestaurantViewModel();
            RestaurantMenuViewModel.Id = restaurant.Id;
            RestaurantMenuViewModel.Name = restaurant.Name;
            RestaurantMenuViewModel.MenuItems = new List<MenuItemViewModel>();
            
            foreach(var restaurantMenuItem in restaurant.Menu)
            {
                var menuItem = new MenuItemViewModel();
                menuItem.Id = restaurantMenuItem.Id;
                menuItem.Name = restaurantMenuItem.Name;
                menuItem.Description = restaurantMenuItem.Description;
                menuItem.Price = restaurantMenuItem.Price;

                RestaurantMenuViewModel.MenuItems.Add(menuItem);
            }
            return RestaurantMenuViewModel;
        }
    }
}
