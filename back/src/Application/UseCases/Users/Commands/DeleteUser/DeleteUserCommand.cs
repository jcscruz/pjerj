using MediatR;

namespace Application.UseCases.Users.Commands.DeleteUser
{
    public sealed class DeleteUserCommand : IRequest<DeleteUserResponse>
    {
        public Int64 UserId { get; init; }
    }
}