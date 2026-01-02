namespace VoucherManagementDomain.ValueObjects
{
    public class Money
    {
        public decimal Value { get; }

        public Money(decimal value)
        {
            Value = value;
        }

        public static implicit operator Money(decimal value) => new(value);

        public static implicit operator decimal(Money money) => money.Value;
    }
}
