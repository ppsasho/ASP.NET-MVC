using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Implementations;

namespace BBQApp.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController()
        {
            _restaurantService = new RestaurantService();
        }
        public IActionResult Index()
        {
            var result = _restaurantService.GetRestaurantDetails();
            return View();
        }
    }
}
