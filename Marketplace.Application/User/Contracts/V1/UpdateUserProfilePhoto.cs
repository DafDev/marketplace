namespace Marketplace.Application.User.Contracts.V1;
public class UpdateUserProfilePhoto : UserContract
{
    public string PhotoUrl { get; set; } = string.Empty;
}
