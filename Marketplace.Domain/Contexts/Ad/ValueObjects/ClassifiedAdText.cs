using System.Text.RegularExpressions;

namespace Marketplace.Domain.Contexts.Ad.ValueObjects;

public record ClassifiedAdText
{
    public string Value { get; init; }
    public static ClassifiedAdText FromString(string value)  => new (value) ;
    public static ClassifiedAdText FromHtml(string htmlValue)
    {
        var replacedTitle = htmlValue
            .Replace("<i>", "*")
            .Replace("</i>", "*")
            .Replace("<b>", "**")
            .Replace("</b>", "**");
        return new (Regex.Replace(replacedTitle, "<.*?>", string.Empty));
    }

    internal ClassifiedAdText(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(value));

        Value = value;
    }

    public static implicit operator string(ClassifiedAdText self) => self.Value;

}
