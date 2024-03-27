namespace Marketplace.Web.Endpoints;

internal static class RequestHandler
{

    public static async Task<IResult> Handle<T>(T request, Func<T, Task> handler)
    {
		try
		{
			await handler(request);
			return Results.Ok();

		}
		catch (Exception ex)
		{
			return Results.BadRequest(new {error = ex.Message, stackTrace = ex.StackTrace});
		}
    }
}