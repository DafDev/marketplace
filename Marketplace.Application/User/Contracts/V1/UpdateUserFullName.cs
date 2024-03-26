namespace Marketplace.Application.User.Contracts.V1;
public class UpdateUserFullName : UserContract
{
    public string FullName { get; set; } = string.Empty;
}
