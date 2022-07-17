using MediatR;

using Application.Comida.Models;
using Application.Common.Interfaces;

namespace Application.Comida.Commands
{
    public record AddComidaCommand(string Nombre, string ImagenUrl, string Descripcion) : IRequest<Unit>;

    public class AddComidaHandler : IRequestHandler<AddComidaCommand, Unit>
    {
        private readonly IComidaDBContext _context;

        public AddComidaHandler(IComidaDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddComidaCommand request, CancellationToken cancellationToken)
        {
            var comida = new Domain.Entities.Comida
            {
                Nombre = request.Nombre,
                ImagenUrl = request.ImagenUrl,
                Descripcion = request.Descripcion
            };

            _context.Comida.Add(comida);

            await _context.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}