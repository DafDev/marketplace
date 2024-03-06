using Marketplace.Framework.Validation;
using System.Text.RegularExpressions;

namespace Marketplace.Domain.Contexts.Ad.ValueObjects;
public record ClassifiedAdTitle(string Title)
{
    public static ClassifiedAdTitle FromString(string title) => new(title);

    public static ClassifiedAdTitle FromHtml(string htmlTitle)
    {
        var replacedTitle = htmlTitle
            .Replace("<i>", "*")
            .Replace("</i>", "*")
            .Replace("<b>", "**")
            .Replace("</b>", "**");

        var cleanedTitle = Regex.Replace(replacedTitle, "<.*?>", string.Empty);
        return new(cleanedTitle);
    }

    //To Do put this in a result function to check validity at instanciatiing
    // but not when retrieving from the database.
    /*
     * public Result<bool> IsValid => new VailidatorBuilder....
     * after persistence is done
     */
    private readonly bool _isValid = new ValidatorBuilder()
        .For(Title).NotNull().NotWhiteSpace().LengthBetween(0,100)
        .IsValid();

    
    public static implicit operator string(ClassifiedAdTitle self) => self.Title;
}
