namespace Application.DTOs
{
    public record GetTypeDto(
           Int64? Id,
           string Description = "",
           string Origin = ""
       );
}