using Marketplace.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Infrastructure.ContextConfigurations;

public static class AppBuilderDatabaseExtensions
{
    public static void EnsureDatabase(this IServiceProvider services)
    {
        var context = services.GetRequiredService<ClassifiedAdDbContext>() ?? throw new InvalidOperationException("service is not set yet");
        if (!context.Database.EnsureCreated())
            context.Database.Migrate();
    }
}