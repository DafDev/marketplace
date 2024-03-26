namespace Marketplace.Web.Endpoints;

internal static class RequestHandler
{

    public static async Task<IResult> Handle<T>(T request, Func<T, Task> handler)
    {
        await handler(request);
        return Results.Ok();
    }
}