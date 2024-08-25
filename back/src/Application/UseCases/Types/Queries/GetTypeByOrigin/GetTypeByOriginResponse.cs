using Application.DTOs;
using Domain.Entities;

namespace Application.UseCases.Types.Queries.GetTypeByOrigin;

public sealed class GetTypeByOriginResponse
{
    public GetTypeDto? UserType { get; init; }

    public GetTypeByOriginResponse(TypeEntity? UserType)
    {
        if (UserType is not null)
        {
            this.UserType = new GetTypeDto(UserType.Id, UserType.Description, UserType.Origin);
        }
    }
}