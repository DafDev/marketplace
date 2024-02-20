
namespace Marketplace.Domain;

public class ClassifiedAd(ClassifiedAdId id, UserId ownerId)
{
    private UserId _ownerId = ownerId ?? throw new ArgumentNullException(nameof(ownerId), "Owner must be specified");
    private string? _title;
    private string? _text;
    private decimal _price;
    public ClassifiedAdId Id { get; } = id ?? throw new ArgumentNullException(nameof(id), "Identity must be specified");

    public void SetTitle(string title) => _title = title;

    public void UpdateText(string text) => _text = text;

    public void UpdatePrice(decimal price) => _price = price;
}
