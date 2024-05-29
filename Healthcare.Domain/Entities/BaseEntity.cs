using MediatR;
using System.Text.Json.Serialization;

namespace Healthcare.Domain.Entities;
public abstract class BaseEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    protected List<INotification> _domainEvents { get; private set; } = new List<INotification>();

    [JsonIgnore]
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(INotification domainEvent)
    {
        _domainEvents ??= [];
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

}
