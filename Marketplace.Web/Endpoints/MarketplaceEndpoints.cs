using Microsoft.AspNetCore.Http.HttpResults;

namespace Marketplace.Web.Endpoints;

public class MarketplaceEndpoints : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapPost("/ad", CreateAd);
    }

    public async Task<IResult> CreateAd()
    {
        return Results.Created();
    }

}
