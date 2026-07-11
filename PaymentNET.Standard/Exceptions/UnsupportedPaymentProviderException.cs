using PaymentNET.Standard.Enums;

namespace PaymentNET.Standard.Exceptions
{
    public class UnsupportedPaymentProviderException:PaymentException
    {
        public UnsupportedPaymentProviderException(PaymentProvider provider  ):base($"Provider {provider.ToString()} does not supported")
        {
            Provider = provider;
          
        }
        public PaymentProvider Provider { get; }
    }
}