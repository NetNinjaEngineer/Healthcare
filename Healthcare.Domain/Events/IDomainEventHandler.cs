namespace Healthcare.Domain.Events
{
    public interface IDomainEventHandler<in TEvent> where TEvent : DomainEvent
    {
        void Handle(TEvent domainEvent);
    }
}
