using Microsoft.EntityFrameworkCore;

using Domain.Entities;



namespace Application.Common.Interfaces
{
    public interface IComidaDBContext
    {
        DbSet<Domain.Entities.Comida> Comida { get; set; }
        DbSet<Ingrediente> Ingredientes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);


    }
}