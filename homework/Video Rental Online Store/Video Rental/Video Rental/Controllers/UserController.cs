using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Services;
using Storage;
using ViewModels;

namespace Video_Rental.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly MovieService _movieService;
        public UserController()
        {
            _userService = new UserService();
            _movieService = new MovieService();
        }
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }
        public IActionResult Register()
        {
            var user = new UserViewModel();
            return View(user);
        }
        [HttpPost]
        public IActionResult Register([FromForm] UserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _userService.NewRegister(model);

            return RedirectToAction("RegisterSuccess");
        }
        public IActionResult RegisterSuccess()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            var user = new LogInViewModel();
            return View(user);
        }
        public IActionResult LogOut() 
        {
            _userService.LogOut();
            return RedirectToAction("LogIn");
        }
        [HttpPost]
        public IActionResult LogIn([FromForm] LogInViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _userService.Login(model);

            return RedirectToAction("LogInSuccess");
        }

        public IActionResult LogInSuccess() 
        {
            return View();
        }
        public IActionResult ViewMovies()
        {
            var userMovieModel = new UserMovieViewModel()
            {
                Movies = _movieService.GetAll(),
                User = _userService.GetCurrentUser()
            };
            return View(userMovieModel);
        }
        public IActionResult UserMovies()
        {
            var user = CurrentSession.CurrentUser;
            var rentals = _movieService.GetRentals().Where(x => x.UserId == user.Id).ToList();
            var userRentalModel = new UserRentalViewModel()
            {
                Rentals = rentals,
                User = new UserViewModel() 
                {
                    Id = user.Id,
                }
            };
            return View(userRentalModel);
        }
        public IActionResult MovieDetails(int id)
        {
            var movie = _movieService.MoreDetails(id);
            return View(movie);
        }
        public IActionResult RentMovie(int id)
        {
            _movieService.Rent(id, CurrentSession.CurrentUser.Id);

            return RedirectToAction("ViewMovies");
        }
        public IActionResult ReturnMovie(int id)
        {
            _movieService.Return(id);

            return RedirectToAction("UserMovies");
        }
    }
}
