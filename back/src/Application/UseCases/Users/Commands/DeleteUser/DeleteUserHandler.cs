using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Users.Commands.DeleteUser
{
    public sealed class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteAsync(request.UserId);
            return new DeleteUserResponse(true);
        }
    }
}