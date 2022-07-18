using MediatR;

using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Ingredientes.Queries
{
    public record GetIngredientesQuery() : IRequest<IEnumerable<Ingrediente>>;

    public class GetIngredientesHandler : IRequestHandler<GetIngredientesQuery, IEnumerable<Ingrediente>>
    {
        private readonly IIngredienteQueries _context;

        public GetIngredientesHandler(IIngredienteQueries context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingrediente>> Handle(GetIngredientesQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetIngredientes(cancellationToken);
        }
    }
}