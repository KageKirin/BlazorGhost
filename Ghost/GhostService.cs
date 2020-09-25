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

#region json_strings
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

    public async Task<string> GetPostsByTagJsonStringAsync(string tagSlug)
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/posts/?key={GhostSettings.RestApiKey}&include=tags,authors&filter=tag:{tagSlug}")).Content.ReadAsStringAsync();
    }

#endregion

#region tags
    public virtual async Task<Tag[]> GetTagsAsync()
    {
        return (await _httpClient.GetFromJsonAsync<TagsRequest>($"/ghost/api/v3/content/tags/?key={GhostSettings.RestApiKey}")).Tags;
    }
#endregion

#region pages
    public virtual async Task<Page[]> GetPagesAsync()
    {
        return (await _httpClient.GetFromJsonAsync<PagesRequest>($"/ghost/api/v3/content/pages/?key={GhostSettings.RestApiKey}")).Pages;
    }
#endregion

#region posts
    public virtual async Task<Post[]> GetPostsAsync()
    {
        return (await _httpClient.GetFromJsonAsync<PostsRequest>($"/ghost/api/v3/content/posts/?key={GhostSettings.RestApiKey}&include=tags,authors")).Posts;
    }

    public virtual async Task<Post[]> GetPostsByTagAsync(string tagSlug)
    {
        return (await _httpClient.GetFromJsonAsync<PostsRequest>($"/ghost/api/v3/content/posts/?key={GhostSettings.RestApiKey}&include=tags,authors&filter=tag:{tagSlug}")).Posts;
    }
#endregion

}
}
