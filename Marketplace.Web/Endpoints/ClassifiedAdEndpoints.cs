using Marketplace.Application.Ad.Contracts.V1;
using Marketplace.Application.Shared;
using Marketplace.Application.Shared.Services;

namespace Marketplace.Web.Endpoints;

public class ClassifiedAdEndpoints : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapPost("/ad", CreateAd);
        app.MapPut("/ad/title", SetTitle);
        app.MapPut("/ad/text", UpdateText);
        app.MapPut("/ad/price", UpdatePrice);
        app.MapPut("/ad/picture", AddPicture);
        app.MapPut("/ad/publih", RequestToPublish);
    }

    public async Task<IResult> CreateAd(Create command, IApplicationService<AdContract> classifiedAdsApplicationServices)
        => await RequestHandler.Handle(command, classifiedAdsApplicationServices.Handle);

    public async Task<IResult> SetTitle(SetTitle command, IApplicationService<AdContract> classifiedAdsApplicationServices)
        => await RequestHandler.Handle(command, classifiedAdsApplicationServices.Handle);

    public async Task<IResult> UpdateText(UpdateText command, IApplicationService<AdContract> classifiedAdsApplicationServices)
        => await RequestHandler.Handle(command, classifiedAdsApplicationServices.Handle);

    public async Task<IResult> UpdatePrice(UpdatePrice command, IApplicationService<AdContract> classifiedAdsApplicationServices)
        => await RequestHandler.Handle(command, classifiedAdsApplicationServices.Handle);

    public async Task<IResult> AddPicture(AddPicture command, IApplicationService<AdContract> classifiedAdsApplicationServices)
        => await RequestHandler.Handle(command, classifiedAdsApplicationServices.Handle);

    public async Task<IResult> RequestToPublish(RequestToPublish command, IApplicationService<AdContract> classifiedAdsApplicationServices)
        => await RequestHandler.Handle(command, classifiedAdsApplicationServices.Handle);
}
