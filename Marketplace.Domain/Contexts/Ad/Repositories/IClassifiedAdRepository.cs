using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Domain.Contexts.Ad.ValueObjects;

namespace Marketplace.Domain.Contexts.Ad.Repositories;

public interface IClassifiedAdRepository
{
    Task<bool> Exists(ClassifiedAdId id);

    Task<ClassifiedAd> Load<ClassifiedAd>(ClassifiedAdId id);

    Task Add(ClassifiedAd entity);
}