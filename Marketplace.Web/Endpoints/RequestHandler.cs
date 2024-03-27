namespace Marketplace.Web.Endpoints;

internal static class RequestHandler
{
    public static async Task<IResult> Handle<T>(T request, Func<T, Task> handler, Serilog.ILogger logger)
    {
        try
        {
            logger.Debug("Handling of http request of type {type}",typeof(T).Name);
            await handler(request);
            return Results.Ok();

        }
        catch (Exception ex)
        {
            logger.Error(ex, "Error w/ handling of http request of type {type}", typeof(T).Name);
            return Results.BadRequest(new { error = ex.Message, stackTrace = ex.StackTrace });
        }
    }
}