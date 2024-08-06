using Microsoft.EntityFrameworkCore;
using Models;

namespace Storage
{
    public class VideoRentalDbContext : DbContext
    {
        public VideoRentalDbContext(DbContextOptions<VideoRentalDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
    }
}
