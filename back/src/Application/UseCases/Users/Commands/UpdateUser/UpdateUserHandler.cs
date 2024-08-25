using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Users.Commands.UpdateUser
{
    public sealed class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.UpdateAsync(request.ToUserEntity());
            return new UpdateUserResponse(true);
        }
    }
}