using System;
using System.Collections.Generic;
using PaymentNET.Standard.Enums;

namespace PaymentNET.Standard.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class SupportedProvidersAttribute : Attribute
    {
        public SupportedProvidersAttribute(params PaymentProvider[] providers)
        {
            Providers = providers;
        }

        public IReadOnlyCollection<PaymentProvider> Providers { get; }
    }
}