using Application.DTOs;
using Domain.Entities;

namespace Application.UseCases.Types.Queries.GetAllTypes;

public sealed class GetAllTypesResponse
{
    public IEnumerable<GetTypeDto> Items { get; init; }

    public GetAllTypesResponse(IEnumerable<TypeEntity> entities)
    {
        this.Items = entities.Select(p => new GetTypeDto(p.Id, p.Description, p.Origin));
    }
}