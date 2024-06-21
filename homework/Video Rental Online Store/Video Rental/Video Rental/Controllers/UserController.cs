using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Services;
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
        //[HttpPost]
        //public IActionResult LogIn([FromForm] LogInViewModel model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var loggedIn = _userService.Login(model);


        //}
        public IActionResult CreateMovies()
        {
            List<MovieViewModel> movies = new()
            {
               new MovieViewModel
            {
                Title = "The Great Adventure",
                Genre = Genre.Action,
                Language = Language.English,
                ReleaseDate = new DateTime(2022, 5, 15),
                Length = new TimeSpan(2, 15, 0),
                AgeRestriction = AgeRestriction.PG13,
                Quantity = 5
            },
            new MovieViewModel
            {
                Title = "Romantic Getaway",
                Genre = Genre.Romance,
                Language = Language.French,
                ReleaseDate = new DateTime(2021, 2, 14),
                Length = new TimeSpan(1, 45, 0),
                AgeRestriction = AgeRestriction.PG,
                Quantity = 3
            },
            new MovieViewModel
            {
                Title = "Horror Night",
                Genre = Genre.Horror,
                Language = Language.German,
                ReleaseDate = new DateTime(2020, 10, 31),
                Length = new TimeSpan(1, 30, 0),
                AgeRestriction = AgeRestriction.R,
                Quantity = 4
            },
            new MovieViewModel
            {
                Title = "Comedy Hour",
                Genre = Genre.Comedy,
                Language = Language.Spanish,
                ReleaseDate = new DateTime(2019, 7, 20),
                Length = new TimeSpan(1, 20, 0),
                AgeRestriction = AgeRestriction.G,
                Quantity = 10
            },
            new MovieViewModel
            {
                Title = "Thriller Chase",
                Genre = Genre.Thriller,
                Language = Language.Macedonian,
                ReleaseDate = new DateTime(2018, 9, 5),
                Length = new TimeSpan(2, 0, 0),
                AgeRestriction = AgeRestriction.NC17,
                Quantity = 2
            },
            new MovieViewModel
            {
                Title = "Action Blast",
                Genre = Genre.Action,
                Language = Language.English,
                ReleaseDate = new DateTime(2023, 3, 22),
                Length = new TimeSpan(2, 10, 0),
                AgeRestriction = AgeRestriction.R,
                Quantity = 8
            },
            new MovieViewModel
            {
                Title = "Mystery Island",
                Genre = Genre.Thriller,
                Language = Language.French,
                ReleaseDate = new DateTime(2020, 11, 8),
                Length = new TimeSpan(1, 50, 0),
                AgeRestriction = AgeRestriction.PG13,
                Quantity = 6
            },
            new MovieViewModel
            {
                Title = "Love in Paris",
                Genre = Genre.Romance,
                Language = Language.French,
                ReleaseDate = new DateTime(2019, 6, 21),
                Length = new TimeSpan(1, 55, 0),
                AgeRestriction = AgeRestriction.PG,
                Quantity = 4
            },
            new MovieViewModel
            {
                Title = "The Haunted House",
                Genre = Genre.Horror,
                Language = Language.German,
                ReleaseDate = new DateTime(2021, 10, 31),
                Length = new TimeSpan(1, 40, 0),
                AgeRestriction = AgeRestriction.R,
                Quantity = 3
            },
            new MovieViewModel
            {
                Title = "Spanish Laughter",
                Genre = Genre.Comedy,
                Language = Language.Spanish,
                ReleaseDate = new DateTime(2018, 4, 12),
                Length = new TimeSpan(1, 30, 0),
                AgeRestriction = AgeRestriction.G,
                Quantity = 7
            },
            new MovieViewModel
            {
                Title = "Thrills of Macedonia",
                Genre = Genre.Thriller,
                Language = Language.Macedonian,
                ReleaseDate = new DateTime(2022, 8, 20),
                Length = new TimeSpan(1, 45, 0),
                AgeRestriction = AgeRestriction.NC17,
                Quantity = 4
            }
            };
            foreach (var movie in movies)
            {
                _movieService.Add(movie);
            }
            return View();
        }

        public IActionResult ViewMovies()
        {
            var movies = _movieService.GetAll();
            return View(movies);
        }

    }
}
