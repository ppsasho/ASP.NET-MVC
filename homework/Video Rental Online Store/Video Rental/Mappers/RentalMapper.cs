using Models;
using ViewModels;

namespace Mappers
{
    public static class RentalMapper
    {
        public static RentalViewModel ToModel(this Rental model)
        {
            return new RentalViewModel()
            {
                Id = model.Id,
                MovieId = model.MovieId,
                UserId = model.UserId,
                RentedOn = model.RentedOn,
                ReturnedOn = model.ReturnedOn,
            };
        }
    }
}
