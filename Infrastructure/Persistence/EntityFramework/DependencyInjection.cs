using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Application.Common.Interfaces;



namespace Infrastructure.Persistence.EntityFramework
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEFDatabase(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ComidasDBContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("EFDatabase"));
                });

            services.AddTransient<IComidaDBContext, ComidasDBContext>();

            return services;
        }
    }
}