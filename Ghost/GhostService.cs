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
#endregion

#region tags
    private Tag[] _tags;
    public async Task<Tag[]> GetTagsAsync()
    {
        if (_tags == null)
        {
            _tags = (await _httpClient.GetFromJsonAsync<TagsRequest>($"/ghost/api/v3/content/tags/?key={GhostSettings.RestApiKey}")).Tags;
        }
        return await Task.Run(() => _tags);
    }
#endregion

#region pages
    private Page[] _pages;
    public async Task<Page[]> GetPagesAsync()
    {
        if (_pages == null)
        {
            _pages = (await _httpClient.GetFromJsonAsync<PagesRequest>($"/ghost/api/v3/content/pages/?key={GhostSettings.RestApiKey}")).Pages;
        }
        return await Task.Run(() => _pages);
    }
#endregion

#region posts
    private Post[] _posts;
    public async Task<Post[]> GetPostsAsync()
    {
        if (_posts == null)
        {
            _posts = (await _httpClient.GetFromJsonAsync<PostsRequest>($"/ghost/api/v3/content/posts/?key={GhostSettings.RestApiKey}")).Posts;
        }
        return await Task.Run(() => _posts);
    }
#endregion

}
}
