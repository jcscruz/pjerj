using MediatR;

namespace Application.UseCases.Users.Queries.GetAllUsers
{
    public sealed record GetAllUsersQuery(string? Origin) : IRequest<GetAllUsersResponse>
    {
    }
}