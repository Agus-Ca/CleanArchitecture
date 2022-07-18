using MediatR;

using Application.Common.Interfaces;



namespace Application.Comida.Commands
{
    public record DeleteComidaCommand(int IdComida) : IRequest<Unit>;

    public class DeleteComidaHandler : IRequestHandler<DeleteComidaCommand, Unit>
    {
        private readonly IComidaDBContext _context;

        public DeleteComidaHandler(IComidaDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteComidaCommand command, CancellationToken cancellationToken)
        {
            var comida = _context.Comida.Where(c => c.Id == command.IdComida).FirstOrDefault();

            if (comida == null)
            {
                return new Unit();
            }

            comida.FechaFinVigencia = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}