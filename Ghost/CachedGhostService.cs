using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;

namespace Ghost
{
public class CachedGhostService : GhostService
{
    public CachedGhostService(HttpClient httpClient) : base(httpClient)
    {
    }

#region tags
    private Tag[] _tags;
    public override async Task<Tag[]> GetTagsAsync()
    {
        if (_tags == null)
        {
            _tags = await base.GetTagsAsync();
        }
        return await Task.Run(() => _tags);
    }
#endregion

#region pages
    private Page[] _pages;
    public override async Task<Page[]> GetPagesAsync()
    {
        if (_pages == null)
        {
            _pages = await base.GetPagesAsync();
        }
        return await Task.Run(() => _pages);
    }
#endregion

#region posts
    private Post[] _posts;
    public override async Task<Post[]> GetPostsAsync()
    {
        if (_posts == null)
        {
            _posts = await base.GetPostsAsync();
        }
        return await Task.Run(() => _posts);
    }

#endregion
}
}