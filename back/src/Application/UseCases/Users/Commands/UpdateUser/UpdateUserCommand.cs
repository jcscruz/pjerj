using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.UseCases.Users.Commands.UpdateUser;

public sealed class UpdateUserCommand : IRequest<UpdateUserResponse>
{
    [StringLength(200, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 200 characters long.")]
    public string? Name { get; init; }

    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? EmailAddress { get; init; }

    public string? Registration { get; init; }
    public DateOnly? DateOfBirth { get; init; }
    public string? Origin { get; init; }

    [JsonIgnore]
    public Int64? UserId { get; private set; }

    [JsonIgnore]
    public Int64? TypeId { get; private set; }

    public void SetUserId(Int64 userId)
    {
        this.UserId = userId;
    }

    public void SetTypeId(Int64? typeId)
    {
        this.TypeId = typeId;
    }

    public UserEntity ToUserEntity()
    {
        return new UserEntity(this.Name, this.Registration, this.DateOfBirth, this.EmailAddress, this.TypeId, this.UserId);
    }
}