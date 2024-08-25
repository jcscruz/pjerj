using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public sealed class CreateUserCommand : IRequest<CreateUserResponse>
    {
        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 200 characters long.")]
        public string Name { get; init; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string EmailAddress { get; init; }

        [Required]
        public DateOnly DateOfBirth { get; init; }

        [Required]
        public string Origin { get; init; }

        [Required]
        public string Registration { get; init; }

        [JsonIgnore]
        public Int64? TypeId { get; private set; }

        public void SetType(Int64? typeId)
        {
            this.TypeId = typeId;
        }

        public CreateUserCommand(string name, string emailAddress, DateOnly dateOfBirth, string origin, string registration)
        {
            Name = name;
            EmailAddress = emailAddress;
            DateOfBirth = dateOfBirth;
            Origin = origin;
            Registration = registration;
        }

        public UserEntity ToUserEntity()
        {
            return new UserEntity(this.Name, this.Registration, this.DateOfBirth, this.EmailAddress, this.TypeId);
        }
    }
}