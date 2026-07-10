using PaymentNET.Standard.Enums;

namespace PaymentNET.Standard.Contracts
{
    public interface IPaymentServiceProviderFactory
    {
        public IPaymentServiceProvider GetServiceProvider(PaymentProvider paymentProvider);
        
    }
}