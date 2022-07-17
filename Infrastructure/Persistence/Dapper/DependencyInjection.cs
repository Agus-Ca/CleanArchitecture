using System.Data;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Dapper
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDapperDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DapperDatabase");

            services.AddTransient<IDbConnection>((sp) => new SqlConnection(connectionString));

            return services;
        }
    }
}