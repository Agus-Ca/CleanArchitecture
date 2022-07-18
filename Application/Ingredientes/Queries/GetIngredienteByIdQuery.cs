using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Ingredientes.Queries
{
    public record GetIngredienteByIdQuery(int Id) : IRequest<Ingrediente>;

    public class GetIngredienteByIdHandler : IRequestHandler<GetIngredienteByIdQuery, Ingrediente>
    {
        private readonly IIngredienteQueries _context;

        public GetIngredienteByIdHandler(IIngredienteQueries context)
        {
            _context = context;
        }

        public async Task<Ingrediente> Handle(GetIngredienteByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetIngredienteById(request.Id, cancellationToken);
        }
    }
}