using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Users.Queries.GetUserById
{
    public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetByIdAsync(request.UserID);
            return new GetUserByIdResponse(result);
        }
    }
}