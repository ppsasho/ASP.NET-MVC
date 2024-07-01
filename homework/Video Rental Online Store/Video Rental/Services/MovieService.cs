﻿using Mappers;
using Models;
using Services.Interfaces;
using Storage;
using Storage.Interfaces;
using ViewModels;

namespace Services
{
    public class MovieService : IMovieService
    {
        private IStorage<Movie> _movieStorage;
        private IStorage<Rental> _rentalStorage;
        public MovieService(IStorage<Movie> movieStorage, IStorage<Rental> rentalStorage)
        {
            _movieStorage = movieStorage;
            _rentalStorage = rentalStorage;
        }
        public List<RentalViewModel> GetUserRentals() => GetRentals().Where(x => x.UserId == CurrentSession.CurrentUser.Id).ToList(); 
        public List<RentalViewModel> GetRentals() => _rentalStorage.GetAll().Select(x => x.ToModel()).ToList();
        public void Rent(int movieId, int userId)
        {
            var movie = _movieStorage.GetById(movieId);
            _rentalStorage.Add(new Rental(userId, movieId));
            -- movie.Quantity;
            _movieStorage.Update(movie);
        }
        public void Return(int rentalId)
        {
            var rental = _rentalStorage.GetById(rentalId);
            rental.Return();
            var movie = _movieStorage.GetById(rental.MovieId);
            movie.Quantity++;
            _rentalStorage.Update(rental);
            _movieStorage.Update(movie);
        }
        public MovieViewModel MoreDetails(int id)
        {
            var movie = _movieStorage.GetById(id);

            return movie.ToModel();
        }
        
        public List<MovieViewModel> GetAll()
        {
            var movies = _movieStorage.GetAll();
            return movies.Select(x => x.ToModel()).ToList();
        }
        public void Add(MovieViewModel model)
        {
            var movie = new Movie(model.Title, model.Genre, model.ReleaseDate, model.AgeRestriction, model.Quantity, model.Language, model.Length);
            _movieStorage.Add(movie);
        }
    }
}
