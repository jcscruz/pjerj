using Application.DTOs;
using Domain.Entities;

namespace Application.UseCases.Types.Queries.GetTypeById;

public sealed class GetTypeByIdResponse
{
    public GetTypeDto? UserType { get; init; }

    public GetTypeByIdResponse(TypeEntity? UserType)
    {
        if (UserType is not null)
        {
            this.UserType = new GetTypeDto(UserType.Id, UserType.Description, UserType.Origin);
        }
    }
}