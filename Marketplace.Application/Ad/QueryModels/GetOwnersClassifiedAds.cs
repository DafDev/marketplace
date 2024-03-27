namespace Marketplace.Application.Ad.QueryModels;
public class GetOwnersClassifiedAds
{
    public Guid OwnerId { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}
