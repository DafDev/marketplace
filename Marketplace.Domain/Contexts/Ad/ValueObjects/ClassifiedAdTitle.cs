using Marketplace.Framework;
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

    private static void CheckValidity(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(nameof(title));
        if (title.Length > 100)
            throw new ArgumentException("Title is bigger than a 100 characters.");
    }

    private readonly bool _isValid = new ValidatorBuilder()
        .For(Title).NotNull().NotWhiteSpace().LengthBetween(0,100)
        .IsValid();

    public static implicit operator string(ClassifiedAdTitle self) => self.Title;
}
