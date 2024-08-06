using Models;
using Storage.Interfaces;

namespace Storage.Implementations
{
    public class RentalStorage : Storage<Rental>, IRentalStorage
    {
        public RentalStorage(VideoRentalDbContext dbContext) : base(dbContext)
        {

        }
    }
}
