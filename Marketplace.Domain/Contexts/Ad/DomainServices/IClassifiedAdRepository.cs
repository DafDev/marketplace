using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Domain.Contexts.Ad.ValueObjects;

namespace Marketplace.Application.Services.Ad;

public interface IClassifiedAdRepository
{
    Task<bool> Exists(ClassifiedAdId id);

    Task<ClassifiedAd> Load<ClassifiedAd>(ClassifiedAdId id);

    Task Add(ClassifiedAd entity);
}