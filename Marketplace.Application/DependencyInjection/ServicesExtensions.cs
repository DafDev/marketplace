using Marketplace.Application.Ad;
using Marketplace.Application.Ad.Contracts.V1;
using Marketplace.Application.Shared.Services;
using Marketplace.Application.User;
using Marketplace.Application.User.Contracts.V1;
using Marketplace.Domain.Shared.DomainServices;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Application.DependencyInjection;
[ExcludeFromCodeCoverage]
public static class ServicesExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {

        services.AddScoped<IContentModeration, PurgomalumClient>();
        services.AddScoped<ICurrencyLookup, FixedCurrencyLookup>();
        services.AddScoped<IApplicationService<AdContract>, ClassifiedAdApplicationService>();
        services.AddScoped<IApplicationService<UserContract>, UserProfileApplicationService>();
        return services;
    }
}
