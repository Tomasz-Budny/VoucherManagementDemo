namespace VoucherManagementDomain.ValueObjects
{
    public class CustomerId
    {
        public Guid Value { get; }

        public CustomerId(Guid value)
        {
            Value = value;
        }

        public static implicit operator CustomerId(Guid value) => new(value);

        public static implicit operator Guid(CustomerId customerId) => customerId.Value;
    }
}
