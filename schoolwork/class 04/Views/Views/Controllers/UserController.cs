using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var result = StaticDb.Users;
            return View(result);
        }
        public IActionResult Details(int id)
        {
            var result = StaticDb.Users.FirstOrDefault(x => x.Id == id);
            return View(result);
        }
    }
}
