using Marketplace.Application.Services.Ad;
using Marketplace.Domain.Contexts.Ad.DomainServices;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Application.DependencyInjection;
[ExcludeFromCodeCoverage]
public static class ServicesExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IApplicationService, ClassifiedAdApplicationService>();
        services.AddScoped<ICurrencyLookup, FixedCurrencyLookup>();

        return services;
    }
}
