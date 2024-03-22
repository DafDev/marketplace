using Marketplace.Application.Shared;

namespace Marketplace.Application.Ad.Contracts.V1;

public class Create : AbstractContract
{
    public Guid OwnerId { get; set; }
}
