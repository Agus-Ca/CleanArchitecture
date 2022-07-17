using MediatR;

using Application.Common.Interfaces;



namespace Application.Comida.Queries
{
    public record GetComidasQuery() : IRequest<IEnumerable<Domain.Entities.Comida>>;

    public class GetComidasHandler : IRequestHandler<GetComidasQuery, IEnumerable<Domain.Entities.Comida>>
    {
        private readonly IComidaQueries _queries;

        public GetComidasHandler(IComidaQueries queries)
        {
            _queries = queries;
        }

        public async Task<IEnumerable<Domain.Entities.Comida>> Handle(GetComidasQuery request, CancellationToken cancellationToken)
        {
            return await _queries.GetComidas(cancellationToken);
        }
    }
}