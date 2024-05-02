using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Notes.Application.CQRS;
using Notes.Application.Services.PasswordHasher;

namespace Notes.Application
{
    public static class DIExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(
                    Assembly.GetExecutingAssembly());
            });

            services.AddAutoMapper(typeof(CQRSMapProfile));
            services.AddScoped<IPasswordHash,PasswordHash>();
        }
    }
}
