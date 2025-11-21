
namespace Domain.Common.Abstractions;

public abstract class BaseEntity
{
    public Guid Id { get; }
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();


    private readonly List<IDomainEvent> _domainEvents = [];

    protected BaseEntity(Guid id = default)
    {
        this.Id = id == default ? Guid.CreateVersion7() : id;
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
