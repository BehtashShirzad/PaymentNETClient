using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PaymentNET.Providers.ZarinPal;

namespace PaymentNET.Builder;

public static class ZarinPalBuilderExtensions
{
    public static PaymentBuilder AddZarinPal(
        this PaymentBuilder builder,
        Action<ZarinPalOptions> configure)
    {
        builder.Services.Configure(configure);
        builder.Services.AddHttpClient<ZarinPalPaymentService>(
            (serviceProvider, client) =>
            {
                var options = serviceProvider
                    .GetRequiredService<IOptions<ZarinPalOptions>>()
                    .Value;

                client.BaseAddress = new Uri(options.BaseUrl);
            });

        return builder;
    }
}