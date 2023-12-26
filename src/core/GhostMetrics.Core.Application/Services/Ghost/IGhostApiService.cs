using GhostMetrics.Core.Domain.Models.GhostCms.Content;

namespace GhostMetrics.Core.Application.Services.Ghost;

public interface IGhostApiService
{
    public Task<List<GhostApiPost>> GetAllGhostPostsAsync(string apiUrl, string contentApiKey);
}