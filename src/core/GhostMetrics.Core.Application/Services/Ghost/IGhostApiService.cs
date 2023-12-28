using GhostSharp.Entities;

namespace GhostMetrics.Core.Application.Services.Ghost;

public interface IGhostApiService
{
    public List<Post> GetAllGhostPosts(string apiUrl, string contentApiKey);
}