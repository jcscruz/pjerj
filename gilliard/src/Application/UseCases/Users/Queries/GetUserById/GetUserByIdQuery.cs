using MediatR;

namespace Application.UseCases.Users.Queries.GetUserById;

public sealed record GetUserByIdQuery(string UserID) : IRequest<GetUserByIdResponse>;