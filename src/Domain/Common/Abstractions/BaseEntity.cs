namespace Domain.Common.Abstractions;

public interface IBaseEntity; // for filteration
public abstract class BaseEntity<TId> : IBaseEntity
where TId : struct, IEquatable<TId>
{
    public TId Id { get; private set; }

    private readonly List<IDomainEvent> _domainEvents = [];

    protected BaseEntity(TId? id = default)
    {
        if (id is Guid guidValue)
        {
            this.Id = (TId)(object)(guidValue == default ? Guid.CreateVersion7() : guidValue);
        }
        else if (id is int intVlaue)
        {
            this.Id = (TId)(object)(intVlaue >= 0 ? id :
            throw new ArgumentException($"Negative integer not allowed for {nameof(id)}"));
        }
        else
        {
            throw new NotSupportedException($"only Guid and int types are allowed for {nameof(id)}");
        }
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        if (domainEvent is null)
            return;

        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents(IDomainEvent domainEvent)
    {
        _domainEvents.Clear();
    }

}
