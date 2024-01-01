using GhostMetrics.Core.Application.Common.Data;
using GhostMetrics.Core.Application.Common.Interfaces;

namespace GhostMetrics.Infrastructure.Identity;

public class WebhookSecurityService : IWebhookSecurityService
{
    private readonly IUnitOfWork _unitOfWork;

    public WebhookSecurityService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<string> GetWebhookSecretForSiteAsync(string id)
    {
        // Convert id from string to Guid and request the webhook secret for the specific site
        Guid siteId = Guid.Parse(id);
        return _unitOfWork.Sites.GetSiteWebhookSecretAsync(siteId, new CancellationToken());
    }
}