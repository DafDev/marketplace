using Marketplace.Application.Contracts.V1;

namespace Marketplace.Application.Services.Ad;
public interface IApplicationService
{
    Task Handle(AbstractContract command);
}
