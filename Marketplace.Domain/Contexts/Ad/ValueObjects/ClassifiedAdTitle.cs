using System.Text.RegularExpressions;

namespace Marketplace.Domain.Contexts.Ad.ValueObjects;
public record ClassifiedAdTitle
{
    public string Title { get; init; }
    public static ClassifiedAdTitle FromString(string title)
    {
        CheckValidity(title);
        return new(title);
    }

    public static ClassifiedAdTitle FromHtml(string htmlTitle)
    {
        var replacedTitle = htmlTitle
            .Replace("<i>", "*")
            .Replace("</i>", "*")
            .Replace("<b>", "**")
            .Replace("</b>", "**");

        var cleanedTitle = Regex.Replace(replacedTitle, "<.*?>", string.Empty);
        CheckValidity(cleanedTitle);
        return new(cleanedTitle);
    }

    internal ClassifiedAdTitle(string title) => Title = title;

    private static void CheckValidity(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(nameof(title));
        if (title.Length > 100)
            throw new ArgumentException("Title is bigger than a 100 characters.");
    }

    public static implicit operator string(ClassifiedAdTitle self) => self.Title;
}
