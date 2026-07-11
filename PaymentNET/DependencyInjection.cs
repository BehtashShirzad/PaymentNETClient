using Microsoft.Extensions.DependencyInjection;
using PaymentNET.Contracts;
using PaymentNET.Helper;
using PaymentNET.Infrastructure;
using PaymentNET.Standard.Contracts;

namespace PaymentNET;

public static class DependencyInjection
{
    public static PaymentBuilder AddPaymentNetServices(this IServiceCollection services)
    {
        services.AddTransient<IPaymentServiceFactory, PaymentServiceFactory>();
        services.AddTransient<IRestClient, RestClient>();
        services.AddHybridCache();
        services.AddSingleton<ITokenCache, HybridTokenCache>();
        return new PaymentBuilder(services);
    }
}