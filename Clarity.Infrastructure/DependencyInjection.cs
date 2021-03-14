using Ironwood.Application.Common.Interaces;
using Ironwood.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clarity.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<ClarityDbContext>(options => options.UseSqlServer
            (
                connectionString: configuration.GetConnectionString("ClarityConStr")
            ));
            services.AddScoped<IClarityDbContext>(provider => provider.GetService<ClarityDbContext>());
            services.AddScoped<DbContext>(provider => provider.GetService<ClarityDbContext>());

            return services;
        }
    }
}