namespace Domain.Entities
{
    public sealed class UserEntity
    {
        public Int64? Id { get; set; }
        public string? Name { get; init; } = string.Empty;
        public string? Registration { get; init; } = string.Empty;
        public DateOnly? DateOfBirth { get; init; }
        public string? EmailAddress { get; init; } = string.Empty;
        public Int64? TypeId { get; init; }
        public TypeEntity? Type { get; init; }

        public void SetId(Int64? id)
        {
            this.Id = id;
        }

        public UserEntity(string? name, string? registration, DateOnly? dateOfBirth, string? emailAddress, Int64? typeId)
        {
            Name = name;
            Registration = registration;
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAddress;
            TypeId = typeId;
        }

        public UserEntity(string? name, string? registration, DateOnly? dateOfBirth, string? emailAddress, Int64? typeId, Int64? userId)
        {
            Id = userId;
            Name = name;
            Registration = registration;
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAddress;
            TypeId = typeId;
        }
    }
}