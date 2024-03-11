using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Domain.Contexts.Ad.Repositories;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Raven.Client.Documents.Session;

namespace Marketplace.Infrastructure;

public class ClassifiedAdRepository(IAsyncDocumentSession session) : IClassifiedAdRepository
{
    private readonly IAsyncDocumentSession _session = session;

    public Task Add(ClassifiedAd entity) => _session.StoreAsync(entity, EntityId(entity.Id));
    public Task<bool> Exists(ClassifiedAdId id) => _session.Advanced.ExistsAsync(EntityId(id));
    public Task<ClassifiedAd> Load<ClassifiedAd>(ClassifiedAdId id) => _session.LoadAsync<ClassifiedAd>(EntityId(id));
    private static string EntityId(ClassifiedAdId id) => $"ClassifiedAd/{id}";
}
