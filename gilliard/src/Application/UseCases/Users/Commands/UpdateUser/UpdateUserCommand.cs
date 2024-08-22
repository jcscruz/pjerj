using MediatR;

namespace Application.UseCases.Users.Commands.UpdateUser;

public sealed record UpdateUserCommand : IRequest<UpdateUserResponse>;