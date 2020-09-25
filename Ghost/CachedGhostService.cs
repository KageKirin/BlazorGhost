using System.Linq;
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

    public override async Task<Post[]> GetPostsByTagAsync(string tagSlug)
    {
        var posts = await GetPostsAsync();
        var selectedPosts = await Task.Run(() =>
            from p in posts
            where p.Tags.Any(t => t.Slug == tagSlug)
            select p);
        if (selectedPosts != null)
        {
            return selectedPosts.ToArray();
        }

        return await base.GetPostsByTagAsync(tagSlug);
    }

    public override async Task<Post> GetPostBySlugAsync(string postSlug)
    {
        var posts = await GetPostsAsync();
        var post = await Task.Run(() => (
            from p in posts
            where p.Slug == postSlug
            select p
        ).First());
        if (post != null)
        {
            return post;
        }

        return await base.GetPostBySlugAsync(postSlug);
    }

    public override async Task<Post> GetPostByIdAsync(string postId)
    {
        var posts = await GetPostsAsync();
        var post = await Task.Run(() => (
            from p in posts
            where p.Id == postId
            select p
        ).First());
        if (post != null)
        {
            return post;
        }

        return await base.GetPostByIdAsync(postId);
    }


#endregion
}
}
