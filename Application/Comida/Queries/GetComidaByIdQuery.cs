using MediatR;

using Application.Common.Interfaces;



namespace Application.Comida.Queries
{
    public record GetComidaByIdQuery(int ComidaId) : IRequest<Domain.Entities.Comida>;

    public class GetComidaByIdHandler : IRequestHandler<GetComidaByIdQuery, Domain.Entities.Comida>
    {
        private readonly IComidaQueries _queries;

        public GetComidaByIdHandler(IComidaQueries queries)
        {
            _queries = queries;
        }

        public async Task<Domain.Entities.Comida> Handle(GetComidaByIdQuery request, CancellationToken cancellationToken)
        {
            return await _queries.GetComidaById(request.ComidaId, cancellationToken);
        }
    }
}