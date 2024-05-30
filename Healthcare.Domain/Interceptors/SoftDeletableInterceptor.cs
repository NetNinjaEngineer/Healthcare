using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Healthcare.Domain.Interceptors;
public sealed class SoftDeletableInterceptor : SaveChangesInterceptor
{
    public override ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
            return ValueTask.FromResult(result);

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is not { State: EntityState.Deleted, Entity: ISoftDeletable softDeletable })
                continue;
            entry.State = EntityState.Modified;
            softDeletable.IsDeleted = true;
            softDeletable.DeletedAt = DateTimeOffset.UtcNow;
        }

        return ValueTask.FromResult(result);

    }
}
