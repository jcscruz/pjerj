using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Users.Queries.GetUserById
{
    public sealed class GetUserByIdHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        Task<GetUserByIdResponse> IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>.Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}