using GhostMetrics.Core.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace GhostMetrics.Core.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly IUserService _userService;
    private readonly IIdentityService _identityService;

    public LoggingBehaviour(
        ILogger<TRequest> logger,
        IUserService userService,
        IIdentityService identityService)
    {
        _logger = logger;
        _userService = userService;
        _identityService = identityService;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _userService.Id ?? string.Empty;
        string? userName = string.Empty;

        if (!string.IsNullOrEmpty(userId))
        {
            userName = await _identityService.GetUsernameAsync(userId);
        }
        
        _logger.LogInformation("GhostMetrics Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, request);
    }
}