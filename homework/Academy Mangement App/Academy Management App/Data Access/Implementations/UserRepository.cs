using Data_Access.Interfaces;
using Domain_Models;

namespace Data_Access.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AcademyManagementDbContext context) : base(context)
        {
        }
    }
}
