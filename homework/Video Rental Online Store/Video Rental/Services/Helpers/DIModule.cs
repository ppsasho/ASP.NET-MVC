using Microsoft.Extensions.DependencyInjection;
using Storage.Implementations;
using Storage.Interfaces;
using Storage;
using Microsoft.EntityFrameworkCore;

namespace Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, string connectionString) 
        {
            services.AddDbContext<VideoRentalDbContext>(option => option.UseSqlServer(
                connectionString
                ));

            services.AddTransient<IMovieStorage, MovieStorage>();
            services.AddTransient<IRentalStorage, RentalStorage>();
            services.AddTransient<IUserStorage, UserStorage>();

            services.AddTransient<Interfaces.IUserService, UserService>();
            services.AddTransient<Interfaces.IMovieService, MovieService>();
            services.AddTransient(typeof(IStorage<>), typeof(Storage<>));

            return services;
        }
    }
}
