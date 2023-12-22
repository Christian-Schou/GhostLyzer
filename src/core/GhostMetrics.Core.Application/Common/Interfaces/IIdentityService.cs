using GhostMetrics.Core.Application.Common.Models;

namespace GhostMetrics.Core.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUsernameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password, string firstName, string lastName);

    Task<Result> DeleteUserAsync(string userId);
}