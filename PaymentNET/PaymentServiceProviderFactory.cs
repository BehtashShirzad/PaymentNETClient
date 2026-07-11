using Microsoft.Extensions.DependencyInjection;
using PaymentNET.Providers.Jibit;
using PaymentNET.Standard.Contracts;
using PaymentNET.Standard.Enums;
using PaymentNET.Standard.Exceptions;

namespace PaymentNET;

public sealed class PaymentServiceFactory : IPaymentServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public PaymentServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IPaymentService GetServiceProvider(PaymentProvider provider)
    {
        return provider switch
        {
            PaymentProvider.Jibit => _serviceProvider.GetRequiredService<JibitPaymentService>(),
            // PaymentProvider.ZarinPal => _serviceProvider.GetRequiredService<ZarinPalPaymentService>(),
            _ => throw new UnsupportedPaymentProviderException(provider)
        };
    }

    
}