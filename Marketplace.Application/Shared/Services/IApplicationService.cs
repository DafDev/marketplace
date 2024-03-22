namespace Marketplace.Application.Shared.Services;
public interface IApplicationService
{
    Task Handle(AbstractContract command);
}
