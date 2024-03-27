namespace Marketplace.Application.Ad.ReadModels;
public class ClassifiedAdListItem
{
    public Guid ClassifiedAdId { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
}
