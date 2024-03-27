
using Marketplace.Application.Ad;
using Marketplace.Application.Ad.QueryModels;

namespace Marketplace.Web.Endpoints;

public class QueryEndpoints : IEndpointDefinition
{
    private static readonly Serilog.ILogger Logger = Serilog.Log.ForContext<QueryEndpoints>();

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/ad", GetAll);
        app.MapGet("/ad/list", GetPublishedAds);
        app.MapGet("/ad/myads", GetOwnerAds);
    }

    public async Task<IResult> GetAll(GetPublicClassifiedAds request, IClassifiedAdQueryService queryService)
        => await RequestHandler.Handle(request, queryService.Query, Logger);

    public async Task<IResult> GetPublishedAds(GetPublishedClassifiedAds request, IClassifiedAdQueryService queryService)
        => await RequestHandler.Handle(request, queryService.Query, Logger);

    public async Task<IResult> GetOwnerAds(GetOwnersClassifiedAds request, IClassifiedAdQueryService queryService)
        => await RequestHandler.Handle(request, queryService.Query, Logger);
}
