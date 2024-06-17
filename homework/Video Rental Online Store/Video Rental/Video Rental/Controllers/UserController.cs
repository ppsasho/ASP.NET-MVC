using Microsoft.AspNetCore.Mvc;
using Models;
using Storage.Implementations;
using Video_Rental.Storage;
using ViewModels;

namespace Video_Rental.Controllers
{
    public class UserController : Controller
    {
        //private readonly UserDataSet _storage = new(IWebHostEnvironment _webHostEnvironment);
        public IActionResult Index()
        {
            var userList = StaticDb.Users;
            //var movieList = StaticDb.Movies;

            return View(userList);
        }
        
        public IActionResult CreateUser()
        {
            var user = new UserViewModel();
            return View(user);
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel model)
        {
            model.Id = StaticDb.Users.Max(x => x.Id) + 1;
            StaticDb.Users.Add(model);
            return RedirectToAction("Index");
        }

    }
}
