using Data.Context;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crosscutting
{
    public static class DependencyInjection
    {
        public static void Register(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICriminalCodeRepository, CriminalCodeRepository>();

        }
    }
}