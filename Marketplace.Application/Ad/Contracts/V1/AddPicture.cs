namespace Marketplace.Application.Ad.Contracts.V1;
public class AddPicture : AdContract
{
    public int Height { get; set; }
    public int Width { get; set; }
    public string Url { get; set; } = string.Empty;
}
