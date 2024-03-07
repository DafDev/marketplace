using Marketplace.Domain.Contexts.Ad.Entities;

namespace Marketplace.Domain.Contexts.Ad.InvariantRules;
public static class PictureInvariants
{
    public static bool HasCorrectSize(this Picture picture)
        => picture != null
           && picture.Size.Width >= 800
           && picture.Size.Height >= 600;
}
