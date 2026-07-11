using Microsoft.Extensions.DependencyInjection;
using PaymentNET.Standard.Contracts;

namespace PaymentNET;


public sealed class PaymentBuilder
{
    public IServiceCollection Services { get; }

    internal PaymentBuilder(IServiceCollection services)
    {
        Services = services;
    }
}