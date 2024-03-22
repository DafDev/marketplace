using Marketplace.Application.Shared;

namespace Marketplace.Application.Ad.Contracts.V1;
public class SetTitle : AbstractContract
{
    public string Title { get; set; } = string.Empty;
}
