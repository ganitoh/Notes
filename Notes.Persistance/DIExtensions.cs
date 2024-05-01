using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notes.Persistance.Services.Repositories.Abstraction;
using Notes.Persistance.Services.Repositories.Emplementation;

namespace Notes.Persistance
{
    public static class DIExtensions
    {
        public static void AddPostgreSQL(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<ApplicationContext>(
                options => options.UseNpgsql(connectionString));
        }

        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INoteRepository,NoteRepository >();
        }
    }
}
