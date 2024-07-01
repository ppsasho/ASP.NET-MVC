using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Storage;
using Storage.Interfaces;
using Storage.Implementations;

namespace Video_Rental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<VideoRentalDbContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnectionString")
                ));
            

            builder.Services.AddTransient<Storage.Interfaces.IStorage, Storage.Implementations.Storage>();
            builder.Services.AddTransient<Services.Interfaces.IUserService, Services.UserService>();
            builder.Services.AddTransient<Services.Interfaces.IMovieService, Services.MovieService>();
            builder.Services.AddTransient(typeof(IStorage<>), typeof(Storage<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}