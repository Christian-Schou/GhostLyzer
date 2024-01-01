using System.Security.Claims;
using GhostMetrics.Core.Application.Common.Interfaces;

namespace GhostMetrics.Web.Services;

public class CurrentUserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}