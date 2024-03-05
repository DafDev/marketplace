using Marketplace.Application.Services.Ad;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Application.DependencyInjection;
[ExcludeFromCodeCoverage]
public static class ServicesExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        //services.AddSingleton<IEntityStore, RavenDbEntity>();
        services.AddScoped<IApplicationService, ClassifiedAdApplicationService>();

        return services;
    }
}
