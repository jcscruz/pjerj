using MediatR;

namespace Application.UseCases.Types.Queries.GetTypeById;
public sealed record GetTypeByIdQuery(Int64 TypeId) : IRequest<GetTypeByIdResponse>;