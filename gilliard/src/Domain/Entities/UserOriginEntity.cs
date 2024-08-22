using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class UserOriginEntity
    {
        public Guid Id { get; init; }
        public string Origem { get; init; } = string.Empty;
        public string Descricao { get; init; } = string.Empty;
        public required ICollection<UserOriginEntity> Users { get; set; }
    }
}