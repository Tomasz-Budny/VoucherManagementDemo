namespace VoucherManagementDomain.ValueObjects
{
    public class TacCardCode
    {
        public string Code { get; }
        public string Id { get; }

        public TacCardCode(string value, string id)
        {
            Code = value;
            Id = id;
        }
    }
}
