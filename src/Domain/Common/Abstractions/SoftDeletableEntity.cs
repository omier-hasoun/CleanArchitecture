
namespace Domain.Common.Abstractions;

public interface ISofDeletableEntity
{
    public bool IsDeleted { get; }
    public DateTimeOffset? DeletedAtUtc { get; }
    public string? DeletedBy { get; }

    public void Delete(string? userId, DateTimeOffset date = default);
    public void UndoDelete();
}

public abstract class SoftDeletableEntity<TId> : BaseEntity<TId>, ISofDeletableEntity
where TId : struct, IEquatable<TId>
{
    public bool IsDeleted => _isDeleted;
    public DateTimeOffset? DeletedAtUtc => _deletedAtUtc;
    public string? DeletedBy => _deletedBy;

    private bool _isDeleted = false;
    private DateTimeOffset? _deletedAtUtc = null;
    private string? _deletedBy = null;

    protected SoftDeletableEntity(TId? id = default) : base(id) { }

    public void Delete(string? userId, DateTimeOffset date = default)
    {
        _isDeleted = true;
        _deletedAtUtc = date == default ? DateTimeOffset.UtcNow : date;
        _deletedBy = string.IsNullOrWhiteSpace(userId) ? SystemConstants.SystemId : userId;
    }

    public void UndoDelete()
    {
        _isDeleted = false;
        _deletedAtUtc = null;
        _deletedBy = null;
    }
}
