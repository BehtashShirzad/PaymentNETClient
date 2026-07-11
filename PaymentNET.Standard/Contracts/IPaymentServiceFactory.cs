using PaymentNET.Standard.Enums;

namespace PaymentNET.Standard.Contracts
{
    public interface IPaymentServiceFactory
    {
        public IPaymentService GetServiceProvider(PaymentProvider paymentProvider);
        
    }
}