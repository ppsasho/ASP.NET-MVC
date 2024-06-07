using Microsoft.AspNetCore.Mvc;

namespace SecondMVCApp.Controllers
{
        [Route("invoice/[Action]")]

    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id) 
        {
            return View();
        }
    }
}
