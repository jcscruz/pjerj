using Application.DTOs;

namespace Application.UseCases.Users.Queries.GetUserById;

public sealed record GetUserByIdResponse
{
    public GetUserDto User { get; init; }

    public GetUserByIdResponse(Domain.Entities.UserEntity? User)
    {
        if (User is not null)
        {
            this.User = new GetUserDto(User.Id, User.Name, User.Registration, User.DateOfBirth, User.EmailAddress, User.Type?.Origin ?? string.Empty);
        }
    }
}