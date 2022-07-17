using Application.Common.Interfaces;
using MediatR;

namespace Application.Comida.Commands
{
    public record UpdateComidaCommand(int Id, string Nombre, string ImagenUrl, string Descripcion) : IRequest<Unit>;

    public class UpdateComidaHandler : IRequestHandler<UpdateComidaCommand>
    {
        private readonly IComidaDBContext _context;

        public UpdateComidaHandler(IComidaDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateComidaCommand command, CancellationToken cancellationToken)
        {
            var comida = _context.Comida.Where(c => c.Id == command.Id).FirstOrDefault();

            if (comida == null)
            {
                return new Unit();
            }

            comida.Nombre = command.Nombre;
            comida.ImagenUrl = command.ImagenUrl;
            comida.Descripcion = command.Descripcion;

            await _context.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}