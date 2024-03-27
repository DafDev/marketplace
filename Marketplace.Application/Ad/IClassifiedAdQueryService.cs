using Marketplace.Application.Ad.QueryModels;
using Marketplace.Application.Ad.ReadModels;

namespace Marketplace.Application.Ad;
public interface IClassifiedAdQueryService
{
    Task<IEnumerable<ClassifiedAdListItem>> Query(GetPublishedClassifiedAds query);
    Task<IEnumerable<ClassifiedAdListItem>> Query(GetOwnersClassifiedAds query);
    Task<IEnumerable<ClassifiedAdDetails>> Query(GetPublicClassifiedAds query);
}
