using MediatR;

namespace Healthcare.Domain.Events;
public sealed class EmployeeCreatedDomainEvent : INotification
{
    public string EmployeeId { get; private set; }

    public EmployeeCreatedDomainEvent(string employeeId)
    {
        EmployeeId = employeeId;
    }
}
