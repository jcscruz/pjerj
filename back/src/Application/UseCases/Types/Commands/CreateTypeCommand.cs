using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Types.Commands
{
    public sealed class CreateTypeCommand : IRequest<CreateTypeResponse>
    {
        [Required]
        public string Origin { get; init; }

        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 200 characters long.")]
        public string Description { get; init; }

        public CreateTypeCommand(string origin, string description)
        {
            Origin = origin;
            Description = description;
        }

        public TypeEntity ToTypeEntity()
        {
            return new TypeEntity
            {
                Origin = this.Origin,
                Description = this.Description,
            };
        }
    }
}