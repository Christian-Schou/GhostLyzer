using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GhostMetrics.Infrastructure.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    private readonly IUserService _userService;
    private readonly TimeProvider _dateTime;

    public AuditableEntityInterceptor(IUserService userService, TimeProvider dateTime)
    {
        _userService = userService;
        _dateTime = dateTime;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = _userService.Id;
                entry.Entity.Created = _dateTime.GetUtcNow();
            }

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
            {
                entry.Entity.LastModifiedBy = _userService.Id;
                entry.Entity.LastModified = _dateTime.GetUtcNow();
            }
        }
    }
}

public static class Extension
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(reference =>
            reference.TargetEntry != null &&
            reference.TargetEntry.Metadata.IsOwned() &&
            (reference.TargetEntry.State == EntityState.Added || reference.TargetEntry.State == EntityState.Modified));
}