

namespace Infrastructure.Data.Interceptors;

public sealed class SoftDeletableEntitySaveChangesInterceptor(IUserContext user, TimeProvider dateTime) : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken ct = default)
    {
        if (eventData.Context is null)
            return await ValueTask.FromResult(result);

        var entries = eventData.Context.ChangeTracker.Entries<ISofDeletableEntity>();
        var utcNow = dateTime.GetUtcNow();

        foreach (var entry in entries)
        {
            if (entry.State != EntityState.Deleted)
            {
                continue;
            }

            entry.State = EntityState.Modified;
            entry.Entity.Delete(user.Id, utcNow);
        }

        return await base.SavingChangesAsync(eventData, result, ct);
    }
}
