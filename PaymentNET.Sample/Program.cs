
using Microsoft.Extensions.Configuration;
using PaymentNET.Standard.Contracts;
using PaymentNET.Standard.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaymentNET;
using PaymentNET.Builder;
using PaymentNET.Providers.Jibit.Authentication;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;

        services
            .AddPaymentNetServices()
            .AddJibit(options =>
            {
                configuration.GetSection("Jibit").Bind(options);
            });
    })
    .Build();


var factory = host.Services
    .GetRequiredService<IPaymentServiceFactory>();


var service = factory.GetServiceProvider(PaymentProvider.Jibit);
 