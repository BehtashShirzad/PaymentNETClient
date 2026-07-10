namespace PaymentNET.Standard.Exceptions
{
    public class UnsupportedProviderOptionException:PaymentException
    {
       

        public UnsupportedProviderOptionException(string provider, string option):base($"Provider {provider} does not support option {option}")
        {
            Provider = provider;
            Option = option;
        }
        public string Provider { get; }
        public string Option { get; }
    }
}