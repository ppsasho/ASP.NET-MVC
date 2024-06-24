using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class PizzaAppDbContext : DbContext
    {
        public PizzaAppDbContext()
        {

        }
        public PizzaAppDbContext(DbContextOptions<PizzaAppDbContext> options) : base(options) { }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaIngredient> PizzaIngredient { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Size> Size{ get; set; }
        public virtual DbSet<Status> Status{ get; set; }
        public virtual DbSet<Topping> Topping{ get; set; }
        public virtual DbSet<User> User{ get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderItem>(entity =>
            //{
            //    //entity.ToTable("Stavki")
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
