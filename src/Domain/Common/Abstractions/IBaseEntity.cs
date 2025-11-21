namespace Domain.Common.Abstractions;

public interface IBaseEntity
{
    Guid Id { get; }
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

}
