namespace GhostMetrics.Core.Application.Common.Interfaces;

public interface IWebhookSecurityService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="siteUrl">Site URL</param>
    /// <returns></returns>
    public Task<string> GetWebhookSecretForSiteAsync(string siteUrl);
}