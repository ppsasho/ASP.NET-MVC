using Mappers;
using Models;
using Models.Enums;
using Services.Interfaces;
using Storage;
using Storage.Interfaces;
using ViewModels;

namespace Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieStorage _movieStorage;
        private readonly IRentalStorage _rentalStorage;
        public MovieService(IMovieStorage movieStorage, IRentalStorage rentalStorage)
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
        public void AddDummyMovies()
        {
            List<MovieViewModel> movies = new()
            {
            new() {
                Title = "The Great Adventure",
                Genre = Genre.Action,
                Language = Language.English,
                ReleaseDate = new DateTime(2022, 5, 15),
                Length = new TimeSpan(2, 15, 0),
                AgeRestriction = AgeRestriction.PG13,
                Quantity = 5
            },
            new() {
                Title = "Romantic Getaway",
                Genre = Genre.Romance,
                Language = Language.French,
                ReleaseDate = new DateTime(2021, 2, 14),
                Length = new TimeSpan(1, 45, 0),
                AgeRestriction = AgeRestriction.PG,
                Quantity = 3
            },
            new() {
                Title = "Horror Night",
                Genre = Genre.Horror,
                Language = Language.German,
                ReleaseDate = new DateTime(2020, 10, 31),
                Length = new TimeSpan(1, 30, 0),
                AgeRestriction = AgeRestriction.R,
                Quantity = 4
            },
            new() {
                Title = "Comedy Hour",
                Genre = Genre.Comedy,
                Language = Language.Spanish,
                ReleaseDate = new DateTime(2019, 7, 20),
                Length = new TimeSpan(1, 20, 0),
                AgeRestriction = AgeRestriction.G,
                Quantity = 10
            },
            new() {
                Title = "Thriller Chase",
                Genre = Genre.Thriller,
                Language = Language.Macedonian,
                ReleaseDate = new DateTime(2018, 9, 5),
                Length = new TimeSpan(2, 0, 0),
                AgeRestriction = AgeRestriction.NC17,
                Quantity = 2
            },
            new() {
                Title = "Action Blast",
                Genre = Genre.Action,
                Language = Language.English,
                ReleaseDate = new DateTime(2023, 3, 22),
                Length = new TimeSpan(2, 10, 0),
                AgeRestriction = AgeRestriction.R,
                Quantity = 8
            },
            new() {
                Title = "Mystery Island",
                Genre = Genre.Thriller,
                Language = Language.French,
                ReleaseDate = new DateTime(2020, 11, 8),
                Length = new TimeSpan(1, 50, 0),
                AgeRestriction = AgeRestriction.PG13,
                Quantity = 6
            },
            new() {
                Title = "Love in Paris",
                Genre = Genre.Romance,
                Language = Language.French,
                ReleaseDate = new DateTime(2019, 6, 21),
                Length = new TimeSpan(1, 55, 0),
                AgeRestriction = AgeRestriction.PG,
                Quantity = 4
            },
            new() {
                Title = "The Haunted House",
                Genre = Genre.Horror,
                Language = Language.German,
                ReleaseDate = new DateTime(2021, 10, 31),
                Length = new TimeSpan(1, 40, 0),
                AgeRestriction = AgeRestriction.R,
                Quantity = 3
            },
            new() {
                Title = "Spanish Laughter",
                Genre = Genre.Comedy,
                Language = Language.Spanish,
                ReleaseDate = new DateTime(2018, 4, 12),
                Length = new TimeSpan(1, 30, 0),
                AgeRestriction = AgeRestriction.G,
                Quantity = 7
            },
            new() {
                Title = "Thrills of Macedonia",
                Genre = Genre.Thriller,
                Language = Language.Macedonian,
                ReleaseDate = new DateTime(2022, 8, 20),
                Length = new TimeSpan(1, 45, 0),
                AgeRestriction = AgeRestriction.NC17,
                Quantity = 1
            }
        };

            foreach(MovieViewModel movie in movies)
            {
                Add(movie);
            }
        }
        public void Add(MovieViewModel model)
        {
            var movie = new Movie(model.Title, model.Genre, model.ReleaseDate, model.AgeRestriction, model.Quantity, model.Language, model.Length);
            _movieStorage.Add(movie);
        }
    }
}
