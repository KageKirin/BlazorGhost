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

    public virtual async Task InitializeAsync()
    {
        await Task.Run(() => null);
    }

#region json_strings
    public async Task<string> GetAuthorsJsonStringAsync()
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/authors/?key={GhostSettings.RestApiKey}&include=count.posts")).Content.ReadAsStringAsync();
    }

    public async Task<string> GetTagsJsonStringAsync()
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/tags/?key={GhostSettings.RestApiKey}&include=count.posts")).Content.ReadAsStringAsync();
    }

    public async Task<string> GetPagesJsonStringAsync()
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/pages/?key={GhostSettings.RestApiKey}&include=authors,tags")).Content.ReadAsStringAsync();
    }

    public async Task<string> GetPostsJsonStringAsync()
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/posts/?key={GhostSettings.RestApiKey}&include=authors,tags")).Content.ReadAsStringAsync();
    }

    public async Task<string> GetSettingsJsonStringAsync()
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/settings/?key={GhostSettings.RestApiKey}")).Content.ReadAsStringAsync();
    }

    public async Task<string> GetPostsByTagJsonStringAsync(string tagSlug)
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/posts/?key={GhostSettings.RestApiKey}&include=authors,tags&filter=tag:{tagSlug}")).Content.ReadAsStringAsync();
    }

    public async Task<string> GetPostsByAuthorJsonStringAsync(string authorSlug)
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/posts/?key={GhostSettings.RestApiKey}&include=authors,tags&filter=author:{authorSlug}")).Content.ReadAsStringAsync();
    }

    public async Task<string> GetPostBySlugJsonStringAsync(string postSlug)
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/posts/slug/{postSlug}/?key={GhostSettings.RestApiKey}&include=authors,tags")).Content.ReadAsStringAsync();
    }

    public async Task<string> GetPostByIdJsonStringAsync(string postId)
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/posts/{postId}/?key={GhostSettings.RestApiKey}&include=authors,tags")).Content.ReadAsStringAsync();
    }

    public async Task<string> GetPageBySlugJsonStringAsync(string pageSlug)
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/pages/slug/{pageSlug}/?key={GhostSettings.RestApiKey}&include=authors,tags")).Content.ReadAsStringAsync();
    }

    public async Task<string> GetPageByIdJsonStringAsync(string pageId)
    {
        return await(await _httpClient.GetAsync($"/ghost/api/v3/content/pages/{pageId}/?key={GhostSettings.RestApiKey}&include=authors,tags")).Content.ReadAsStringAsync();
    }
#endregion

#region settings
    public virtual async Task<Settings> GetSettingsAsync()
    {
        return (await _httpClient.GetFromJsonAsync<SettingsRequest>($"/ghost/api/v3/content/settings/?key={GhostSettings.RestApiKey}")).Settings;
    }
#endregion

#region authors
    public virtual async Task<Author[]> GetAuthorsAsync()
    {
        return (await _httpClient.GetFromJsonAsync<AuthorsRequest>($"/ghost/api/v3/content/authors/?key={GhostSettings.RestApiKey}&include=count.posts")).Authors;
    }
#endregion

#region tags
    public virtual async Task<Tag[]> GetTagsAsync()
    {
        return (await _httpClient.GetFromJsonAsync<TagsRequest>($"/ghost/api/v3/content/tags/?key={GhostSettings.RestApiKey}&include=count.posts")).Tags;
    }
#endregion

#region pages
    public virtual async Task<Page[]> GetPagesAsync()
    {
        return (await _httpClient.GetFromJsonAsync<PagesRequest>($"/ghost/api/v3/content/pages/?key={GhostSettings.RestApiKey}&include=authors,tags")).Pages;
    }

    public virtual async Task<Page> GetPageBySlugAsync(string pageSlug)
    {
        return (await _httpClient.GetFromJsonAsync<PagesRequest>($"/ghost/api/v3/content/pages/slug/{pageSlug}/?key={GhostSettings.RestApiKey}&include=authors,tags")).Pages[0];
    }

    public virtual async Task<Page> GetPageByIdAsync(string pageId)
    {
        return (await _httpClient.GetFromJsonAsync<PagesRequest>($"/ghost/api/v3/content/pages/{pageId}/?key={GhostSettings.RestApiKey}&include=authors,tags")).Pages[0];
    }
#endregion

#region posts
    public virtual async Task<Post[]> GetPostsAsync()
    {
        return (await _httpClient.GetFromJsonAsync<PostsRequest>($"/ghost/api/v3/content/posts/?key={GhostSettings.RestApiKey}&include=authors,tags")).Posts;
    }

    public virtual async Task<Post[]> GetPostsByTagAsync(string tagSlug)
    {
        return (await _httpClient.GetFromJsonAsync<PostsRequest>($"/ghost/api/v3/content/posts/?key={GhostSettings.RestApiKey}&include=authors,tags&filter=tag:{tagSlug}")).Posts;
    }

    public virtual async Task<Post[]> GetPostsByAuthorAsync(string authorSlug)
    {
        return (await _httpClient.GetFromJsonAsync<PostsRequest>($"/ghost/api/v3/content/posts/?key={GhostSettings.RestApiKey}&include=authors,tags&filter=author:{authorSlug}")).Posts;
    }

    public virtual async Task<Post> GetPostBySlugAsync(string postSlug)
    {
        return (await _httpClient.GetFromJsonAsync<PostsRequest>($"/ghost/api/v3/content/posts/slug/{postSlug}/?key={GhostSettings.RestApiKey}&include=authors,tags")).Posts[0];
    }

    public virtual async Task<Post> GetPostByIdAsync(string postId)
    {
        return (await _httpClient.GetFromJsonAsync<PostsRequest>($"/ghost/api/v3/content/posts/{postId}/?key={GhostSettings.RestApiKey}&include=authors,tags")).Posts[0];
    }

#endregion

}
}
