using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Interfases;
using AutoMapper.Configuration.IConfiguration;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IUserDBContext>(provider =>
                provider.GetService<UserDbContext>());
            return services;
        }
    }
}