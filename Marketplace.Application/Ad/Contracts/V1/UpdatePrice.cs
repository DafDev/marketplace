using Marketplace.Application.Shared;

namespace Marketplace.Application.Ad.Contracts.V1;
public class UpdatePrice : AbstractContract
{
    public decimal Price { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
}