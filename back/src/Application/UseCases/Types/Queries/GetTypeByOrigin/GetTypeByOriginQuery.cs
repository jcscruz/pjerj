using MediatR;

namespace Application.UseCases.Types.Queries.GetTypeByOrigin;
public sealed record GetTypeByOriginQuery(string Origin) : IRequest<GetTypeByOriginResponse>;