namespace Marketplace.Application.Ad.Contracts.V1;
public class UpdatePrice : AdContract
{
    public decimal Price { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
}