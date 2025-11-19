
namespace Domain.Common.Abstractions;

public interface IAuditableEntity
{
    public DateTimeOffset CreatedAtUtc { get; }
    public string CreatedBy { get; }
    public DateTimeOffset LastModifiedAtUtc { get; }
    public string LastModifiedBy { get; }

    public void SetCreated(string? userId, DateTimeOffset date = default);
    public void SetModified(string? userId, DateTimeOffset date = default);
}

public class AuditableEntity<TId> : SoftDeletableEntity<TId>, IAuditableEntity
{
    public DateTimeOffset CreatedAtUtc { get; private set; }
    public string CreatedBy { get; private set; } = string.Empty;
    public DateTimeOffset LastModifiedAtUtc { get; private set; }
    public string LastModifiedBy { get; private set; } = string.Empty;

    protected AuditableEntity(TId? id = default) : base(id) { }

    public void SetModified(string? userId, DateTimeOffset date = default)
    {
        LastModifiedBy = string.IsNullOrWhiteSpace(userId) ? SystemConstants.SystemId : userId;
        LastModifiedAtUtc = date == default ? DateTimeOffset.UtcNow : date;
    }

    public void SetCreated(string? userId, DateTimeOffset date = default)
    {
        CreatedBy = string.IsNullOrWhiteSpace(userId) ? SystemConstants.SystemId : userId;
        CreatedAtUtc = date == default ? DateTimeOffset.UtcNow : date;

        SetModified(CreatedBy, CreatedAtUtc);
    }
}
