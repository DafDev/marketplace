using Marketplace.Application.Services.Ad;
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
