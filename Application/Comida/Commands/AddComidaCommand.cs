using MediatR;

using Application.Common.Interfaces;

namespace Application.Comida.Commands
{
    public record AddComidaCommand(string Nombre, string ImagenUrl, string Descripcion) : IRequest<Domain.Entities.Comida>;

    public class AddComidaHandler : IRequestHandler<AddComidaCommand, Domain.Entities.Comida>
    {
        private readonly IComidaDBContext _context;

        public AddComidaHandler(IComidaDBContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Comida> Handle(AddComidaCommand request, CancellationToken cancellationToken)
        {
            var comida = new Domain.Entities.Comida
            {
                Nombre = request.Nombre,
                ImagenUrl = request.ImagenUrl,
                Descripcion = request.Descripcion
            };

            _context.Comida.Add(comida);

            await _context.SaveChangesAsync(cancellationToken);

            return comida;
        }
    }
}