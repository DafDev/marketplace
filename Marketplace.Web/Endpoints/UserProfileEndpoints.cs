using Marketplace.Application.Shared.Services;
using Marketplace.Application.User.Contracts.V1;

namespace Marketplace.Web.Endpoints;

public class UserProfileEndpoints : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapPost("/user", RegisterUser);
        app.MapPut("/user/fullname", UpdateFullName);
        app.MapPut("/user/displayname", UpdateDispayName);
        app.MapPut("/user/photo", UpdateProfilePhoto);
    }

    public async Task<IResult> RegisterUser(RegisterUser request, IApplicationService<UserContract> userApplicationService)
        => await RequestHandler.Handle(request, userApplicationService.Handle);

    public async Task<IResult> UpdateFullName(UpdateUserFullName request, IApplicationService<UserContract> userApplicationService)
        => await RequestHandler.Handle(request, userApplicationService.Handle);

    public async Task<IResult> UpdateDispayName(UpdateUserDisplayName request, IApplicationService<UserContract> userApplicationService)
        => await RequestHandler.Handle(request, userApplicationService.Handle);

    public async Task<IResult> UpdateProfilePhoto(UpdateUserProfilePhoto request, IApplicationService<UserContract> userApplicationService)
        => await RequestHandler.Handle(request, userApplicationService.Handle);
}