using Models;
using Storage.Interfaces;

namespace Storage.Implementations
{
    public class MovieStorage : Storage<Movie>, IMovieStorage
    {
        public MovieStorage(VideoRentalDbContext dbContext) : base(dbContext) { }
    }
}
