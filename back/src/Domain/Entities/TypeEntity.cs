namespace Domain.Entities
{
    public sealed class TypeEntity
    {
        public Int64? Id { get; init; }
        public string Description { get; init; } = string.Empty;
        public string Origin { get; init; } = string.Empty;
        public ICollection<UserEntity>? Users { get; init; } = null;
    }
}