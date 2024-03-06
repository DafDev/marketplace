using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.Ad.Events;
public class PictureAddedToClassifiedAdEvent(Guid classifiedAdId, Guid pictureId, string url, double height, double width, int order) : DomainEvent(classifiedAdId)
{
    public Guid PictureId { get; set; } = pictureId;
    public string Url { get; set; } = url;
    public double Height { get; set; } = height;
    public double Width { get; set; } = width;
    public int Order { get; set; } = order;
}
