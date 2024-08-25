namespace Application.DTOs
{
    public sealed record GetUserDto(
            Int64? Id,
            string? Name = "",
            string? Registration = "",
            DateOnly? DateOfBirth = null,
            string? EmailAddress = "",
            string Origin = ""
        );
}