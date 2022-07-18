using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IIngredienteQueries
    {
        public Task<IEnumerable<Ingrediente>> GetIngredientes(CancellationToken cancellationToken);
        public Task<Ingrediente> GetIngredienteById(int IngredienteId, CancellationToken cancellationToken);
    }
}