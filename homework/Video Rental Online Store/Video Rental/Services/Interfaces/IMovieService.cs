using ViewModels;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        public List<MovieViewModel> GetAll();
        public void Add(MovieViewModel model);
        public MovieViewModel MoreDetails(int id);
        public void Return(int rentalId);
        public void Rent(int movieId, int userId);
        public List<RentalViewModel> GetRentals();
        public List<RentalViewModel> GetUserRentals();
    }
}
