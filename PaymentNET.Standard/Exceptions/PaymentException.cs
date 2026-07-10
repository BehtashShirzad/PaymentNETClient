using System;

namespace PaymentNET.Standard.Exceptions
{
    public abstract class PaymentException : Exception
    {
        protected PaymentException()
        {
        }

        protected PaymentException(string message)
            : base(message)
        {
        }

        protected PaymentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}