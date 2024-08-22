using MediatR;

namespace Application.UseCases.Users.Commands.DeleteUser
{
    public sealed class DeleteUserCommand(string UserId) : IRequest<DeleteUserResponse>
    {
    }
}