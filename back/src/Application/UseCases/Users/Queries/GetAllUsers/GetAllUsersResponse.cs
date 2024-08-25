using Application.DTOs;
using Domain.Entities;

namespace Application.UseCases.Users.Queries.GetAllUsers;

public sealed class GetAllUsersResponse
{
    public IEnumerable<GetUserDto>? Users { get; init; } = new List<GetUserDto>();

    public GetAllUsersResponse(IEnumerable<UserEntity> Users)
    {
        if (Users.Count() > default(int))
        {
            this.Users = Users.Select(p => new GetUserDto(p.Id, p.Name, p.Registration, p.DateOfBirth, p.EmailAddress, p.Type?.Origin ?? string.Empty)).ToList();
        }
    }
}