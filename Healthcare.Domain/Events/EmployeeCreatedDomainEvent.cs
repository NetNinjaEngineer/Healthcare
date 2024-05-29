using MediatR;

namespace Healthcare.Domain.Events;
public sealed class EmployeeCreatedDomainEvent : INotification
{
    public int EmployeeId { get; private set; }

    public EmployeeCreatedDomainEvent(int employeeId)
    {
        EmployeeId = employeeId;
    }
}
