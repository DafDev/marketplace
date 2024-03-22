using Marketplace.Application.Ad;
using Marketplace.Application.Shared.Services;
using Marketplace.Domain.Shared.DomainServices;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Application.DependencyInjection;
[ExcludeFromCodeCoverage]
public static class ServicesExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICurrencyLookup, FixedCurrencyLookup>();
        services.AddScoped<IApplicationService, ClassifiedAdApplicationService>();
        return services;
    }
}
