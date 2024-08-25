using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var id = await _userRepository.AddAsync(request.ToUserEntity());
            return new CreateUserResponse(id);
        }
    }
}