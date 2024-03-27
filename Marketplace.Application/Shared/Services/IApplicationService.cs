namespace Marketplace.Application.Shared.Services;
public interface IApplicationService<TContract>
{
    Task Handle(TContract command);
}
