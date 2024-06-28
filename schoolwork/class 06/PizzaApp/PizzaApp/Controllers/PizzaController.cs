using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Services.Implementation;
using Services.Interface;
using ViewModels;

namespace PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaService;
        public PizzaController(IPizzaService dbContext)
        {
            _pizzaService = dbContext;
        }
        public IActionResult Index()
        {
            var items = _pizzaService.GetAll();
            return View(items);
        }
        public IActionResult Details(int id)
        {
            var item = _pizzaService.GetDetails(id);
            return View(item);
        }
        public IActionResult SearchByName(string name)
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.Types = _pizzaService.GetTypeOptions();
            var pizza = new PizzaViewModel();
            return View(pizza);
        }
        [HttpPost]
        public IActionResult Create([FromForm] PizzaViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                ViewBag.Types = _pizzaService.GetTypeOptions();
                return View(model);
            }
            _pizzaService.Create(model);

            return RedirectToAction("Index");
        }
    }

}
