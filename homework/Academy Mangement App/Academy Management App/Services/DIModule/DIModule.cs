using Data_Access;
using Data_Access.Implementations;
using Data_Access.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Services.DIModule
{
    public static class DIModule
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, string connString)
        {
            services.AddDbContext<AcademyManagementDbContext>(options =>
                        options.UseSqlServer(connString));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IGradeRepository, GradeRepository>();

            return services;
        }
    }
}
