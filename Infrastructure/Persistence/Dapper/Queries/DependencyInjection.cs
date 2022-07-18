using Microsoft.Extensions.DependencyInjection;

using Application.Common.Interfaces;
using Infrastructure.Persistence.Dapper.Queries.Comida;
using Infrastructure.Persistence.Dapper.Queries.Ingrediente;

namespace Infrastructure.Persistence.Dapper.Queries
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient<IComidaQueries, ComidaQueries>();
            services.AddTransient<IIngredienteQueries, IngredienteQueries>();

            return services;
        }
    }
}