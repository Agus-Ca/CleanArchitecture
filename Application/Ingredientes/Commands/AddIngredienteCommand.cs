using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Ingredientes.Commands
{
    public record AddIngredienteCommand(string Nombre, string ImageUrl) : IRequest<Unit>;

    public class AddIngredienteHandler : IRequestHandler<AddIngredienteCommand, Unit>
    {
        private readonly IComidaDBContext _context;
        public AddIngredienteHandler(IComidaDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddIngredienteCommand request, CancellationToken cancellationToken)
        {
            var ingrediente = new Ingrediente
            {
                Nombre = request.Nombre,
                ImagenUrl = request.ImageUrl
            };

            _context.Ingrediente.Add(ingrediente);

            await _context.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}