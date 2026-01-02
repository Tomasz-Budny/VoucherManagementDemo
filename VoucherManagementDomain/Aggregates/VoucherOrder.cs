using VoucherManagementDomain.Common;
using VoucherManagementDomain.Exceptions;
using VoucherManagementDomain.Primitives;
using VoucherManagementDomain.ValueObjects;

namespace VoucherManagementDomain.Aggregates
{
    public class VoucherOrder : AggregateRoot<VoucherId>
    {
        public CustomerId CustomerId;
        public Money Amount;
        public VoucherOrderStatus Status;
        public List<TacCardCode> TacCardCodes = new();

        protected VoucherOrder(VoucherId id) : base(id)
        {
        }

        public void ChangeStatusToPaymentUnknown()
        {
            if (Status == VoucherOrderStatus.PendingPayment)
            {
                Status = VoucherOrderStatus.PaymentUnknown;
            }
            else
            {
                throw new VoucherOrderException($"Can not change status from status: {Status} to PaymentUnknown");
            }
        }

        public void MarkPendingPayment()
        {
            if (Status == VoucherOrderStatus.New)
            {
                Status = VoucherOrderStatus.PendingPayment;
            }
            else
            {
                throw new VoucherOrderException($"Can not change status from status: {Status} to PendingPayment");
            }
        }

        public void MarkPaid()
        {
            if(Status == VoucherOrderStatus.PaymentUnknown || Status == VoucherOrderStatus.ProcessingPayment)
            {
                Status = VoucherOrderStatus.Paid;
            }
            else
            {
                throw new VoucherOrderException($"Can not change status from status: {Status} to Paid");
            }
        }

        public void MarkProcessingPayment()
        {
            if (Status == VoucherOrderStatus.PendingPayment || Status == VoucherOrderStatus.PaymentUnknown)
            {
                Status = VoucherOrderStatus.ProcessingPayment;
            }
            else
            {
                throw new VoucherOrderException($"Can not change status from status: {Status} to ProcessingPayment");
            }
        }

        public void MarkPaymentError()
        {
            if (Status == VoucherOrderStatus.PaymentUnknown)
            {
                Status = VoucherOrderStatus.PaymentError;
            }
            else
            {
                throw new VoucherOrderException($"Can not change status from status: {Status} to PaymentError");
            }
        }

        public void MarkGenerated()
        {
            if (Status == VoucherOrderStatus.Paid)
            {
                Status = VoucherOrderStatus.Generated;
            }
            else
            {
                throw new VoucherOrderException($"Can not change status from status: {Status} to Generated");
            }
        }
    }
}
