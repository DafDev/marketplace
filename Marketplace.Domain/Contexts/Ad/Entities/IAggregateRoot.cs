namespace Marketplace.Domain.Contexts.Ad.Entities;

internal interface IAggregateRoot
{
    public string AggregateId { get; }
}