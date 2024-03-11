using Marketplace.Application.Contracts.V1;
using Marketplace.Application.Services.Ad;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Web.Endpoints;

public class MarketplaceEndpoints : IEndpointDefinition
{
    private static readonly ILogger Log = (ILogger)Serilog.Log.ForContext<MarketplaceEndpoints>();
    public void DefineEndpoints(WebApplication app)
    {
        app.MapPost("/ad", CreateAd);
        app.MapPut("/ad/title", SetTitle);
        app.MapPut("/ad/text", UpdateText);
        app.MapPut("/ad/price", UpdatePrice);
        app.MapPut("/ad/publih", RequestToPublish);
    }

    public async Task<IResult> CreateAd(Create command, IApplicationService classifiedAdsApplicationServices)
        => await HandleRequest(command, classifiedAdsApplicationServices.Handle);

    public async Task<IResult> SetTitle(SetTitle command, IApplicationService classifiedAdsApplicationServices)
        => await HandleRequest(command, classifiedAdsApplicationServices.Handle);

    public async Task<IResult> UpdateText(UpdateText command, IApplicationService classifiedAdsApplicationServices)
        => await HandleRequest(command, classifiedAdsApplicationServices.Handle);

    public async Task<IResult> UpdatePrice(UpdatePrice command, IApplicationService classifiedAdsApplicationServices)
        => await HandleRequest(command, classifiedAdsApplicationServices.Handle);

    public async Task<IResult> RequestToPublish(RequestToPublish command, IApplicationService classifiedAdsApplicationServices)
        => await HandleRequest(command, classifiedAdsApplicationServices.Handle);

    private static async Task<IResult> HandleRequest<T>(T request, Func<T, Task> handler)
    {
        try
        {
            Log.LogDebug("Handling HTTP request of type {type}", typeof(T).Name);
            await handler(request);
            return Results.Ok();
        }
        catch (Exception e)
        {
            Log.LogDebug("Error handling the request, {errorMessage}", e.Message);
            return Results.BadRequest(new { error = e.Message, stackTrace = e.StackTrace });
        }
    }
}
