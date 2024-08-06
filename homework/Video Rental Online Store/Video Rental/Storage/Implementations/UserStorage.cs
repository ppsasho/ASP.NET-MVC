using Models;
using Storage.Interfaces;

namespace Storage.Implementations
{
    public class UserStorage : Storage<User>, IUserStorage
    {
        public UserStorage(VideoRentalDbContext dbContext) : base(dbContext)
        {

        }
    }
}
