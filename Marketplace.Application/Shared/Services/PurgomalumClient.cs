using Marketplace.Domain.Shared.DomainServices;
using Microsoft.AspNetCore.WebUtilities;

namespace Marketplace.Application.Shared.Services;
public class PurgomalumClient(HttpClient httpClient) : IContentModeration
{
    private readonly HttpClient _httpClient = httpClient;

    public PurgomalumClient() : this(new HttpClient()) { }

    public async Task<bool> CheckTextForProfanity(string text)
    {
        var queryHelpers = QueryHelpers.AddQueryString("https://www.purgomalum.com/service/containsprofanity", "text", text);
        var result = await _httpClient.GetStringAsync(queryHelpers);

        return bool.Parse(result);
    }
}
