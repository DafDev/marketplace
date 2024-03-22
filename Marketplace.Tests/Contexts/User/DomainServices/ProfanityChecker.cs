namespace Marketplace.Tests.Contexts.User.DomainServices;
public class ProfanityChecker
{
    private readonly List<string> _profanities = ["cunt", "fuck", "shit", "merde", "son of a bitch", "bitch", "connard"];

    public bool Check(string text) => _profanities.Any(profanity => text.Contains(profanity, StringComparison.InvariantCultureIgnoreCase));

}
