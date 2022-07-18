using System.Data;
using Dapper;

using Application.Common.Interfaces;


namespace Infrastructure.Persistence.Dapper.Queries.Ingrediente
{
    public class IngredienteQueries : IIngredienteQueries
    {
        private readonly IDbConnection _context;

        public IngredienteQueries(IDbConnection context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Ingrediente>> GetIngredientes(CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM Ingrediente I " +
                        "WHERE I.FechaFinVigencia IS NULL";

            return await _context.QueryAsync<Domain.Entities.Ingrediente>(query, cancellationToken);
        }

        public async Task<Domain.Entities.Ingrediente> GetIngredienteById(int IngredienteId, CancellationToken cancellationToken)
        {
            var query = $"SELECT * FROM Ingrediente I " +
                        $"WHERE I.Id = {IngredienteId} " +
                        $"AND I.FechaFinVigencia IS NULL";

            var result = await _context.QueryAsync<Domain.Entities.Ingrediente>(query, cancellationToken);

            return result.ToList().FirstOrDefault();
        }
    }
}