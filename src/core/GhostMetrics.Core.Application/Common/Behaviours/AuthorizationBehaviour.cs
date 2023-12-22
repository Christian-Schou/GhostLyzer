using System.Reflection;
using GhostMetrics.Core.Application.Common.Exceptions;
using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Common.Security;

namespace GhostMetrics.Core.Application.Common.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IUser _user;
    private readonly IIdentityService _identityService;

    public AuthorizationBehaviour(IUser user, IIdentityService identityService)
    {
        _user = user;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (authorizeAttributes.Any())
        {
            // We want an authenticated user
            if (_user.Id == null)
            {
                throw new UnauthorizedAccessException();
            }
            
            // Let's run the role-based authorization
            var authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

            if (authorizeAttributesWithRoles.Any())
            {
                var authorized = false;

                foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                {
                    foreach (var role in roles)
                    {
                        var isInRole = await _identityService.IsInRoleAsync(_user.Id, role.Trim());
                        if (!isInRole) continue;
                        authorized = true;
                        break;
                    }

                    if (!authorized)
                    {
                        throw new ForbiddenAccessException();
                    }
                }
            }
            
            // Let's run the policy-based authorization
            var authorizeAttributeWithPolicies = authorizeAttributes.Where(x => !string.IsNullOrWhiteSpace(x.Policy));

            if (authorizeAttributeWithPolicies.Any())
            {
                foreach (var policy in authorizeAttributeWithPolicies.Select(x => x.Policy))
                {
                    var authorized = await _identityService.AuthorizeAsync(_user.Id, policy);

                    if (!authorized)
                    {
                        throw new ForbiddenAccessException();
                    }
                }
            }
        }

        // All good, the user is authorized to see this resource or authorization is not required
        return await next();
    }
}