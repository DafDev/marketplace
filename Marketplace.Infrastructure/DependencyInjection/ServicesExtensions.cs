using Marketplace.Domain.Contexts.Ad.Repositories;
using Marketplace.Framework.Persistence;
using Marketplace.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Infrastructure.DependencyInjection;
[ExcludeFromCodeCoverage]
public static class ServicesExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        const string connectionString = "Host=localhost;Database=Marketplace_EFCore;Username=postgres;Password=ultim";
        services.AddEntityFrameworkNpgsql()
            .AddDbContext<ClassifiedAdDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
        services.AddScoped<IClassifiedAdRepository, ClassifiedAdRepository>();
        return services;
    }
}
