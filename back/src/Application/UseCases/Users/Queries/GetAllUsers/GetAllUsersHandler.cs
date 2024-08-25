using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Users.Queries.GetAllUsers
{
    public sealed class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAllAsync(request.Origin);
            return new GetAllUsersResponse(result);
        }
    }
}