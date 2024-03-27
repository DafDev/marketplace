using Marketplace.Domain.Shared.DomainServices;

namespace Marketplace.Tests.Contexts.User.DomainServices;
public class ProfanityChecker : IContentModeration
{
    private readonly List<string> _profanities = ["cunt", "fuck", "shit", "merde", "son of a bitch", "bitch", "connard"];

    public Task<bool> CheckTextForProfanity(string text) => Task.FromResult(_profanities.Any(profanity => text.Contains(profanity, StringComparison.InvariantCultureIgnoreCase)));
}
