using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ingredientes.Commands
{
    public record DeleteIngredienteCommand(int Id) : IRequest<Unit>;

    public class DeleteIngredienteHandler : IRequestHandler<DeleteIngredienteCommand, Unit>
    {
        private readonly IComidaDBContext _context;

        public DeleteIngredienteHandler(IComidaDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteIngredienteCommand command, CancellationToken cancellationToken)
        {
            var ingrediente = _context.Ingrediente.Where(i => i.Id == command.Id).FirstOrDefault();

            if (ingrediente == null) return new Unit();

            ingrediente.FechaFinVigencia = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}