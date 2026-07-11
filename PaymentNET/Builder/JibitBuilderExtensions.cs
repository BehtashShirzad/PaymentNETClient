using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PaymentNET.Contracts;
using PaymentNET.Infrastructure;
using PaymentNET.Providers.Jibit;
using PaymentNET.Providers.Jibit.Authentication;

namespace PaymentNET.Builder;

public static class JibitBuilderExtensions
{
    public static PaymentBuilder AddJibit(
        this PaymentBuilder builder,
        Action<JibitOptions> configure)
    {
        builder.Services.Configure(configure);
        builder.Services.AddSingleton<IJibitTokenProvider, JibitTokenProvider>();
        // Authentication Handler
        builder.Services.AddTransient<
            JibitAuthenticationHandler>();


        // Client for getting token
        builder.Services.AddHttpClient(
            "JibitAuth",
            (serviceProvider, client) =>
            {
                var options = serviceProvider
                    .GetRequiredService<IOptions<JibitOptions>>()
                    .Value;

                client.BaseAddress =
                    new Uri(options.BaseUrl);
            });


        // Main Jibit Client
        builder.Services.AddHttpClient<JibitPaymentService>(
                (serviceProvider, client) =>
                {
                    var options = serviceProvider
                        .GetRequiredService<IOptions<JibitOptions>>()
                        .Value;

                    client.BaseAddress =
                        new Uri(options.BaseUrl);
                })
            .AddHttpMessageHandler<JibitAuthenticationHandler>();


        return builder;
    }
}