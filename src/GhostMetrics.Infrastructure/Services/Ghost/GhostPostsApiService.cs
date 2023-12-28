using GhostSharp.Entities;
using GhostSharp.QueryParams;
using Microsoft.Extensions.Logging;

namespace GhostMetrics.Infrastructure.Services.Ghost;

public partial class GhostApiService
{
    public List<Post> GetAllPosts(string baseUrl, string contentApiKey)
    {
        try
        {
            var ghost = new GhostSharp.GhostContentAPI(baseUrl, contentApiKey);
            var queryParams = new PostQueryParams
            {
                IncludeAuthors = true,
                IncludeTags = true
            };
            var posts = ghost.GetPosts(queryParams);
            return posts.Posts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ghost API Service: An unhandled error occured. Please check the logs for more details");
            throw;
        }
    }
}