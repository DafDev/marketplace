using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.Ad.Events;
public class ClassifiedAdSentForReviewEvent(Guid id) : DomainEvent(id){}
