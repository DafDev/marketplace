namespace Marketplace.Domain.Shared.DomainServices;
public interface IContentModeration
{
    Task<bool> CheckTextForProfanity(string text);
}
