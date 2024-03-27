using Marketplace.Domain.Shared.DomainServices;
using Marketplace.Domain.Shared.Exceptions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Domain.Contexts.User.ValueObjects;
[ComplexType]
public record DisplayName(string Value)
{
    public static async Task<DisplayName> FromString(string value, IContentModeration hasProfanity)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(value));
       
        if (await hasProfanity.CheckTextForProfanity(value))
            throw new ProfanityFoundException(value);
        
        return  new(value);
    }

    public static implicit operator string(DisplayName self) => self.Value;
}
