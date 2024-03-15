using Marketplace.Application.DependencyInjection;
using Marketplace.Infrastructure.DependencyInjection;
using Marketplace.Web.Endpoints;
using Marketplace.Web.Endpoints.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddInfrastructure()
    .AddDependencies()
    .AddSwaggerServices()
    .AddEndpointDefinitions(typeof(IEndpointDefinition));

var app = builder.Build();

app.UseEndpointDefinitions();
app.Run();
