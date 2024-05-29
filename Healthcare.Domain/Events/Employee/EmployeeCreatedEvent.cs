namespace Healthcare.Domain.Events.Employee
{
    public sealed class EmployeeCreatedEvent : DomainEvent
    {
        public int EmployeeId { get; }

        public EmployeeCreatedEvent(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
