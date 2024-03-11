using Marketplace.Domain.Contexts.Ad.Repositories;
using Marketplace.Framework.Persistence;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;

namespace Marketplace.Infrastructure.DependencyInjection;
[ExcludeFromCodeCoverage]
public static class ServicesExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var store = new DocumentStore
        {
            Urls = ["http://localhost:8080"],
            Database = "Markeplace_raven",
            Conventions =
            {
                FindIdentityProperty = m => m.Name == "_databaseId"
            }
        };
        store.Initialize();
        services.AddScoped(c => store.OpenAsyncSession());
        services.AddScoped<IUnitOfWork, RavenDbUnitOfWork>();
        services.AddScoped<IClassifiedAdRepository, ClassifiedAdRepository>();

        return services;
    }
}
