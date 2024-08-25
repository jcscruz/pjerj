using MediatR;

namespace Application.UseCases.Users.Queries.GetUserById;

public sealed class GetUserByIdQuery() : IRequest<GetUserByIdResponse>
{
    public Int64 UserID { get; init; }
}