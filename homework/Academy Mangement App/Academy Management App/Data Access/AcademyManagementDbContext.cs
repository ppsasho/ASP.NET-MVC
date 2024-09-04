using Domain_Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Access
{
    public class AcademyManagementDbContext : DbContext
    {
        public AcademyManagementDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

    }
}
