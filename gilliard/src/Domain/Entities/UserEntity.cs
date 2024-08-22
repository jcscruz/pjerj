using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class UserEntity
    {
        public Guid Id { get; init; }
        public required string Nome { get; init; } = string.Empty;
        public string Matricula { get; init; } = string.Empty;
        public DateTime DataNascimento { get; init; }
        public string Email { get; init; }
        public UserOriginEntity UserOrigin { get; init; }
        
    }
}