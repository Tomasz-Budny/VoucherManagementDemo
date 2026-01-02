namespace VoucherManagementDomain.Primitives
{
    public enum VoucherOrderStatus
    {
        New,
        PendingPayment,
        PaymentUnknown,
        ProcessingPayment,
        Paid,
        PaymentError,
        Generated
    }
}
