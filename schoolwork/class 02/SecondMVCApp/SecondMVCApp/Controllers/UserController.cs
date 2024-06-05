using Microsoft.AspNetCore.Mvc;

namespace SecondMVCApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index() {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult PlainText()
        {
            return Content("Random text message appeared?");
        }

        public IActionResult JsonAction() 
        {
            List<string> userList  = new List<string>() { "Sasho Popovski", "David Davidsky" };

            return Json(userList);
        }
    }
}
