using MediatR;

namespace Application.UseCases.UserOrigin.Queries.GetUserOriginById;

public sealed record GetUserOriginByIdQuery(string UserOriginID) : IRequest<GetUserOriginByIdResponse>;