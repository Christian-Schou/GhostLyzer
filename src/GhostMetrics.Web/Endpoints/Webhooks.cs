using System.Text.Json;
using GhostMetrics.Web.Infrastructure.Middleware;

namespace GhostMetrics.Web.Endpoints;

public class Webhooks : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        // Middleware to check if secret matches the one generated for the site
        app.UseWhen(context => context.Request.Path
            .StartsWithSegments("/api/webhooks", StringComparison.InvariantCultureIgnoreCase), 
            appBuilder =>
                        {
                            appBuilder.UseMiddleware<ValidateWebhookSignatureMiddleware>();
                        });

        app.MapGroup(this)
            .AllowAnonymous()
            .MapPost(UpdateAuthor, "update-author")
            .MapPost(UpdatePost, "update-post");
    }

    #region Posts

    /// <summary>
    /// Update a single ghost post in GhostMetrics based on data from the payload in the HTTP Request
    /// </summary>
    /// <param name="sender">Mediator</param>
    /// <param name="request">HttpRequest</param>
    /// <param name="siteId">GhostMetrics Site ID</param>
    public async Task<IResult> UpdatePost(ISender sender, HttpRequest request, string siteId)
    {
        string postId = await _getGhostPostId(request);
        string ghostUrl = await _extractGhostSiteDomain(request);
        return Results.Ok($"Post: {postId} will now be updated in GhostMetrics for {ghostUrl}.");
    }

    #endregion

    #region Authors

    public async Task<IResult> UpdateAuthor(ISender sender, HttpRequest request, string siteId)
    {
        string authorId = "123";
        string ghostUrl = await _extractGhostSiteDomain(request);
        return Results.Ok($"Author: {authorId} will now be updated in GhostMetrics for {ghostUrl}.");
    }

    #endregion

    #region Helpers

    private async Task<string> _getGhostPostId(HttpRequest request)
    {
        using var reader = new StreamReader(request.Body);
        var body = await reader.ReadToEndAsync();
        
        // Parse the body as JSON
        var json = JsonDocument.Parse(body);
        var postId = json.RootElement.GetProperty("post").GetProperty("current").GetProperty("id").GetString();

        // Check for null or empty and return post id
        Guard.Against.NullOrEmpty(postId);
        return postId;
    }

    private async Task<string> _extractGhostSiteDomain(HttpRequest request)
    {
        using var reader = new StreamReader(request.Body);
        var body = await reader.ReadToEndAsync();
        
        // Parse the body as JSON
        var json = JsonDocument.Parse(body);
        var postUrl = json.RootElement.GetProperty("post").GetProperty("current").GetProperty("url").GetString();

        Guard.Against.NullOrEmpty(postUrl);
        
        // Extract domain
        var domain = new Uri(postUrl);
        return domain.Host;
    }
    #endregion
}