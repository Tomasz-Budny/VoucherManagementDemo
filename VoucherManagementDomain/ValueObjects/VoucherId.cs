namespace VoucherManagementDomain.ValueObjects
{
    public class VoucherId
    {
        public Guid Value { get; }

        public VoucherId(Guid value)
        {
            Value = value;
        }

        public static implicit operator VoucherId(Guid value) => new(value);

        public static implicit operator Guid(VoucherId voucherId) => voucherId.Value;
    }
}
