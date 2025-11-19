
namespace Infrastructure.Data.Interceptors;

public sealed class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly IUserContext _user;

    private readonly TimeProvider _dateTime;
    public AuditableEntitySaveChangesInterceptor(IUserContext user, TimeProvider dateTime)
    {
        _dateTime = dateTime;
        _user = user;
    }
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken ct = default)
    {
        if (eventData.Context is null)
            return await ValueTask.FromResult(result);

        DateTimeOffset utcNow = _dateTime.GetUtcNow();
        foreach (var entry in eventData.Context.ChangeTracker.Entries<IAuditableEntity>())
        {

            if (entry.State == EntityState.Added)
            {
                entry.Entity.SetCreated(_user.Id, utcNow);
            }

            entry.Entity.SetModified(_user.Id, utcNow);

            foreach (var ownedEntry in entry.References)
            {
                if (ownedEntry.TargetEntry != null && ownedEntry.TargetEntry is { Entity: IAuditableEntity })
                {
                    if (ownedEntry.TargetEntry.State == EntityState.Added)
                    {
                        entry.Entity.SetCreated(_user.Id, utcNow);
                        // SetModified will be called internally
                        continue;
                    }

                    entry.Entity.SetModified(_user.Id, utcNow);
                }
            }

        }

        return await base.SavingChangesAsync(eventData, result, ct);
    }
}
