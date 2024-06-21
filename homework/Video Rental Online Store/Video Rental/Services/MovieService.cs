using Mappers;
using Models;
using Storage.Implementations;
using ViewModels;

namespace Services
{
    public class MovieService
    {
        private readonly MovieStorage _movieStorage;
        public MovieService() 
        {
            _movieStorage = new MovieStorage();
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
