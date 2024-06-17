using Microsoft.AspNetCore.Mvc;
using Models;
using Storage.Implementations;

namespace Video_Rental.Controllers
{
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment? _webHostEnvironment;
        private readonly UserDataSet _storage = new(IWebHostEnvironment _webHostEnvironment);
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateUser()
        {
            var user = new User("Sasho", "Popovski", "ppsasho", "ppsasho123", "ppsasho@gmail.com", 19);
            return View();
        }
        
    }
}
