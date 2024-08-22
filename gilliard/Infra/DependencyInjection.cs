using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Repositories;
using Infra.Persistence;
using Infra.Repositories;
using System.Reflection;

namespace Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOriginRepository, UserOriginRepository>();

            var assembly = Assembly.Load("Application");
            services.AddMediatR(assembly);

            return services;
        }
    }
}