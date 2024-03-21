using Marketplace.Application.Contracts.V1;
using Marketplace.Application.Services.Ad;

namespace Marketplace.Web.Endpoints;

public class MarketplaceEndpoints : IEndpointDefinition
{
      public void DefineEndpoints(WebApplication app)
    {
        app.MapPost("/ad", CreateAd);
        app.MapPut("/ad/title", SetTitle);
        app.MapPut("/ad/text", UpdateText);
        app.MapPut("/ad/price", UpdatePrice);
        app.MapPut("ad/picture", AddPicture);
        app.MapPut("/ad/publih", RequestToPublish);
    }

    public async Task<IResult> CreateAd(Create command, IApplicationService classifiedAdsApplicationServices)
    {
        await classifiedAdsApplicationServices.Handle(command);
        return Results.Created();
    }

    public async Task<IResult> SetTitle(SetTitle command, IApplicationService classifiedAdsApplicationServices)
    {
        await classifiedAdsApplicationServices.Handle(command);
        return Results.Ok();
    }

    public async Task<IResult> UpdateText(UpdateText command, IApplicationService classifiedAdsApplicationServices)
    {
        await classifiedAdsApplicationServices.Handle(command);
        return Results.Ok();
    }
    
    public async Task<IResult> UpdatePrice(UpdatePrice command, IApplicationService classifiedAdsApplicationServices)
    {
        await classifiedAdsApplicationServices.Handle(command);
        return Results.Ok();
    }

    public async Task<IResult> AddPicture(AddPicture command, IApplicationService classifiedAdsApplicationServices)
    {
        await classifiedAdsApplicationServices.Handle(command);
        return Results.Ok();
    }

    public async Task<IResult> RequestToPublish(RequestToPublish command, IApplicationService classifiedAdsApplicationServices)
    {
        await classifiedAdsApplicationServices.Handle(command);
        return Results.Ok();
    }
}
