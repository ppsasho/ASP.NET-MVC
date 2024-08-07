﻿using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;
using Services;
using Services.Interfaces;
using Storage;
using ViewModels;

namespace Video_Rental.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        public UserController(IUserService userService, IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
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
            if (!_movieService.GetAll().Any())
            {
                _movieService.AddDummyMovies();
            }
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
            var rentals = _movieService.GetUserRentals();
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
            var userRentals = _movieService.GetUserRentals().Where(x => x.ReturnedOn == null).ToList();
            switch (CurrentSession.CurrentUser.SubscriptionType)
            {
                case SubscriptionType.None:
                    if (userRentals.Count > 0) return RedirectToAction("Subscribe");
                    break;

                case SubscriptionType.Monthly:
                    if (userRentals.Count > 3) return RedirectToAction("Subscribe");
                    break;

                case SubscriptionType.Yearly:
                    if (userRentals.Count > 9) return RedirectToAction("MovieRentLimitReached");
                    break;
            }
            _movieService.Rent(id, CurrentSession.CurrentUser.Id);

            return RedirectToAction("ViewMovies");
        }
        public IActionResult Subscribe()
        {
            var user = _userService.GetCurrentUser();
            return View(user);
        }
        public IActionResult ChangeSubscription(string subType)
        {
            var userRentals = _movieService.GetUserRentals().Where(x => x.ReturnedOn == null).ToList();
            switch (subType)
            {
                case "Monthly":
                    if(userRentals.Count > 4)
                    {
                        return RedirectToAction("ReturnMovies");
                    }
                    else
                    {
                        CurrentSession.CurrentUser.SubscriptionType = SubscriptionType.Monthly;
                        ViewBag.SubscriptionType = "Monthly";
                        _userService.UpdateUser();
                    }
                    break;

                case "Yearly":
                    CurrentSession.CurrentUser.SubscriptionType = SubscriptionType.Yearly;
                    ViewBag.SubscriptionType = "Yearly";
                    _userService.UpdateUser();
                    break;

                case "Unsubscribe":
                    if (userRentals.Count > 1)
                    {
                        return RedirectToAction("ReturnMovies");
                    }
                    else
                    {
                        CurrentSession.CurrentUser.RemoveSubscription();
                        ViewBag.SubscriptionType = "None";
                        _userService.UpdateUser();
                    }
                    break;
            }
            return RedirectToAction("SubscriptionChangeSuccess");
        }
        public IActionResult ReturnMovies()
        {
            return View();
        }
        public IActionResult SubscriptionChangeSuccess()
        {
            return View();
        }
        public IActionResult MovieRentLimitReached()
        {
            return View();
        }
        public IActionResult ReturnMovie(int id)
        {
            _movieService.Return(id);

            return RedirectToAction("UserMovies");
        }
    }
}
