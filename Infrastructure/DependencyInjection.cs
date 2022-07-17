using Microsoft.Extensions.Configuration;

using Infrastructure.Persistence.Dapper;
using Infrastructure.Persistence.EntityFramework;
using Infrastructure.Persistence.Dapper.Queries;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEFDatabase(configuration);
        services.AddDapperDatabase(configuration);

        services.AddQueries();

        return services;
    }
}
