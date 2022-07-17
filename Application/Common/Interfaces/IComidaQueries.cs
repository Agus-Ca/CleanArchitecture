namespace Application.Common.Interfaces
{
    public interface IComidaQueries
    {
        public Task<IEnumerable<Domain.Entities.Comida>> GetComidas(CancellationToken cancellationToken);
        public Task<Domain.Entities.Comida> GetComidaById(int ComidaId, CancellationToken cancellationToken);
    }
}