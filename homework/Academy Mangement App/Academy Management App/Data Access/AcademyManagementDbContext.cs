using Microsoft.EntityFrameworkCore;

namespace Data_Access
{
    public class AcademyManagementDbContext : DbContext
    {
        public AcademyManagementDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
