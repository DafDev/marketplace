namespace Marketplace.Application.User.Contracts.V1;
public class UpdateUserDisplayName : UserContract
{
    public string DisplayName { get; set; } = string.Empty;
}
