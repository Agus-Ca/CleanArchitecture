using Microsoft.Extensions.DependencyInjection;

using Application.Common.Interfaces;
using Infrastructure.Persistence.Dapper.Queries.Comida;



namespace Infrastructure.Persistence.Dapper.Queries
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient<IComidaQueries, ComidaQueries>();

            return services;
        }
    }
}