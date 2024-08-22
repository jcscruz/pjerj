using MediatR;

namespace Application.UseCases.UserOrigin.Commands.DeleteUserOrigin
{
    public sealed class DeleteUserOriginCommand(string UserOriginId) : IRequest<DeleteUserOriginCommand>
    {
    }
}
