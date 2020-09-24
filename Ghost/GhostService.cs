using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;

namespace Ghost
{
public class GhostService
{
    private HttpClient _httpClient;

    public GhostService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin","*");
        _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Credentials", "true");
        _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Headers", "Access-Control-Allow-Origin,Content-Type");
    }

    public string GetBaseUrl()
    {
        return _httpClient.BaseAddress.ToString();
    }

    public async Task<string> GetTagsJsonStringAsync()
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/tags/?key={GhostSettings.RestApiKey}")).Content.ReadAsStringAsync();
    }

    public async Task<string> GetPagesJsonStringAsync()
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/pages/?key={GhostSettings.RestApiKey}")).Content.ReadAsStringAsync();
    }

    public async Task<string> GetPostsJsonStringAsync()
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/posts/?key={GhostSettings.RestApiKey}")).Content.ReadAsStringAsync();
    }
}
}
