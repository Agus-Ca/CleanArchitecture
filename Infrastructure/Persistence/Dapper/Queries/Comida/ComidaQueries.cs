using System.Data;

using Dapper;

using Application.Common.Interfaces;

namespace Infrastructure.Persistence.Dapper.Queries.Comida
{
    public class ComidaQueries : IComidaQueries
    {
        private readonly IDbConnection _context;

        public ComidaQueries(IDbConnection context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Comida>> GetComidas(CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM Comida C" +
                        "WHERE C.";

            return await _context.QueryAsync<Domain.Entities.Comida>(query, cancellationToken);
        }

        public async Task<Domain.Entities.Comida> GetComidaById(int ComidaId, CancellationToken cancellationToken)
        {
            var query = $"SELECT * FROM Comida C " +
                        $"WHERE C.Id = {ComidaId} " +
                        $"AND C.FechaFinVigencia IS NULL";

            var result = await _context.QueryAsync<Domain.Entities.Comida>(query, cancellationToken);

            return result.ToList().FirstOrDefault();
        }
    }
}