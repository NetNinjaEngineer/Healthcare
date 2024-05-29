using MediatR;

namespace Healthcare.Domain.Events;
public sealed class EmployeePromotedDomainEventHandler
    : INotificationHandler<EmployeePromotedDomainEvent>
{
    public Task Handle(EmployeePromotedDomainEvent notification,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
