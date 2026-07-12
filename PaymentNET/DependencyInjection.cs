using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PaymentNET.Contracts;
using PaymentNET.Helper;
using PaymentNET.Infrastructure;
using PaymentNET.Standard;
using PaymentNET.Standard.Contracts;

namespace PaymentNET;

public static class DependencyInjection
{
    public static PaymentBuilder AddPaymentNetServices(this IServiceCollection services)
    {
        services.AddTransient<IPaymentServiceFactory, PaymentServiceFactory>();
        
        services.AddHybridCache();
        services.AddSingleton<ITokenCache, HybridTokenCache>();
        TypeAdapterConfig.GlobalSettings.Scan(StandardAssembly.Assembly,PaymentAssembly.Assembly);
        services.AddMapster();
        return new PaymentBuilder(services);
    }
}