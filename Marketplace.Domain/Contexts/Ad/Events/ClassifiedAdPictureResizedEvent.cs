using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.Ad.Events;
public class ClassifiedAdPictureResizedEvent(Guid aggregateRootId, Guid pictureId, PictureSize pictureSize) : DomainEvent(aggregateRootId)
{
    public Guid PictureId { get; set; } = pictureId;
    public double Height { get; set; } = pictureSize.Height;
    public double Width { get; set; } = pictureSize.Width;
}
