using Marketplace.Application.Shared;

namespace Marketplace.Application.Ad.Contracts.V1;
public class UpdateText : AbstractContract
{
    public string Text { get; set; } = string.Empty;
}
