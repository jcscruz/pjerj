namespace Domain.ValueObjects
{
    public sealed class EmailAddress
    {
        public string Value { get; private set; }

        public EmailAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
            {
                throw new ArgumentException("Invalid email address.");
            }

            Value = value;
        }

        public override string ToString() => Value;
    }
}