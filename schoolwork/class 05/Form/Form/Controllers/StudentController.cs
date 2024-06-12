using Form.Data;
using Form.Models;
using Microsoft.AspNetCore.Mvc;

namespace Form.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var result = StaticStorage.Students;
            return View(result);
        }
        public IActionResult CreateStudent()
        {
            var emptyStudent = new StudentViewModel();
            return View(emptyStudent);
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentViewModel model)
        {
            return RedirectToAction("Index");
        }
    }
}
