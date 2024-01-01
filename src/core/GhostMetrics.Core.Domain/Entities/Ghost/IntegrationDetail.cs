namespace GhostMetrics.Core.Domain.Entities.Ghost;

public class IntegrationDetail : BaseAuditableEntity
{
    public IntegrationDetail(string apiUrl, string contentApiKey, string adminApiKey)
    {
        ApiUrl = apiUrl;
        ContentApiKey = contentApiKey;
        AdminApiKey = adminApiKey;
        WebhookSecret = GenerateRandomSecret();
    }
    
    /// <summary>
    /// Ghost CMS Integration API Url.
    /// </summary>
    public string ApiUrl { get; private set; }
    
    /// <summary>
    /// Ghost CMS Content API Key.
    /// </summary>
    public string ContentApiKey { get; private set; }
    
    /// <summary>
    /// Ghost CMS Admin Api Key.
    /// </summary>
    public string AdminApiKey { get; private set; }
    
    /// <summary>
    /// GhostMetrics Webhook Secret for Ghost CMS site.
    /// </summary>
    public string? WebhookSecret { get; private set; }
    
    /// <summary>
    /// GhostMetrics Site ID (FK)
    /// </summary>
    public Guid GhostSiteId { get; set; }
    public Site Site { get; set; } = null!;

    /// <summary>
    /// Update the current API Url for the site.
    /// </summary>
    /// <param name="apiUrl">Ghost CMS API Url</param>
    public void UpdateApiUrl(string apiUrl)
    {
        ApiUrl = apiUrl;
    }

    /// <summary>
    /// Update the current Content API Key for the site.
    /// </summary>
    /// <param name="contentApiKey">Ghost Content API Key</param>
    public void UpdateContentApiKey(string contentApiKey)
    {
        ContentApiKey = contentApiKey;
    }

    /// <summary>
    /// Update the current Admin API Key for the site.
    /// </summary>
    /// <param name="adminApiKey">Ghost Admin API Key</param>
    public void UpdateAdminApiKey(string adminApiKey)
    {
        AdminApiKey = adminApiKey;
    }
    
    /// <summary>
    /// Update the current webhook secret with a new value from the generator.
    /// </summary>
    public void UpdateWebhookSecret()
    {
        WebhookSecret = GenerateRandomSecret();
    }

    /// <summary>
    /// Generate a random secret value to be used as the secret for webhooks on the site.
    /// </summary>
    /// <returns>string containing only digits</returns>
    private string GenerateRandomSecret()
    {
       return Guid.NewGuid().ToString("N"); // Only return digits
    }
}