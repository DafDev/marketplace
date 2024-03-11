using Marketplace.Application.DependencyInjection;
using Marketplace.Web.Endpoints;
using Marketplace.Web.Endpoints.Extensions;
using Marketplace.Infrastructure.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddDependencies()
    .AddInfrastructure()
    .AddSwaggerServices()
    .AddEndpointDefinitions(typeof(IEndpointDefinition));

var app = builder.Build();

app.UseEndpointDefinitions();
app.Run();
