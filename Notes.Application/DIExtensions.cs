using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Notes.Application.CQRS;
using Notes.Application.Services.PasswordHasher;
using Notes.Application.JWT.Abstraction;
using Notes.Application.JWT;
using Notes.Application.Services.Emplementation;
using Notes.Application.Services.Abstraction;

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

            services.AddScoped<IAccountService,AccountService>();

            services.AddAutoMapper(typeof(CQRSMapProfile));
            services.AddScoped<IPasswordHash,PasswordHash>();
            services.AddScoped<IJwtProvider,JwtProvider>();
        }
    }
}
