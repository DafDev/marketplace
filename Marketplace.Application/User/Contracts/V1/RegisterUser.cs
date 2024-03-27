namespace Marketplace.Application.User.Contracts.V1;
public class RegisterUser : UserContract
{
    public string FullName { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
}
