using Data_Access.Interfaces;
using Domain_Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AcademyManagementDbContext _context;
        private readonly DbSet<User> _users;
        public UserRepository(AcademyManagementDbContext context) : base(context)
        {
            _context = context;
            _users = _context.Set<User>();
        }


    }
}
