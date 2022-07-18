using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ingredientes.Commands
{
    public record UpdateIngredienteCommand(int Id, string Nombre, string ImageUrl) : IRequest<Unit>;

    public class UpdateIngredienteHandler : IRequestHandler<UpdateIngredienteCommand, Unit>
    {
        private readonly IComidaDBContext _context;

        public UpdateIngredienteHandler(IComidaDBContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateIngredienteCommand command, CancellationToken cancellationToken)
        {
            var ingrediente = _context.Ingrediente.Where(i => i.Id == command.Id).FirstOrDefault();

            if (ingrediente == null)
            {
                return new Unit();
            }

            ingrediente.Nombre = command.Nombre;
            ingrediente.ImagenUrl = command.ImageUrl;

            await _context.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
