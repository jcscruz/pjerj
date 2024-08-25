using MediatR;

namespace Application.UseCases.Types.Queries.GetAllTypes;

public sealed record GetAllTypesQuery : IRequest<GetAllTypesResponse>;