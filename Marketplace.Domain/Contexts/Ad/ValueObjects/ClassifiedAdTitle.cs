using System.Text.RegularExpressions;

namespace Marketplace.Domain.Contexts.Ad.ValueObjects;
public record ClassifiedAdTitle
{
    public readonly string Title;
    public static ClassifiedAdTitle FromString(string title) => new(title);
    public static ClassifiedAdTitle FromHtml(string htmlTitle)
    {
        var replacedTitle = htmlTitle
            .Replace("<i>", "*")
            .Replace("</i>", "*")
            .Replace("<b>", "**")
            .Replace("</b>", "**");
        return new(Regex.Replace(replacedTitle, "<.*?>", string.Empty));
    }

    private ClassifiedAdTitle(string title)
    {
        if(string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(nameof(title));
        if (title.Length > 100)
           throw new ArgumentException("Title is bigger than a 100 characters.");

        Title = title;
    }
}
