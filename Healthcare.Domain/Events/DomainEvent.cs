namespace Healthcare.Domain.Events
{
    public abstract class DomainEvent
    {
        public DateTime OccuredOn { get; } = DateTime.UtcNow;
        protected DomainEvent() { }
    }
}
