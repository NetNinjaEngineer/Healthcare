using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Domain.Events;
public class EmployeePromotedDomainEvent : INotification
{
    public decimal SalaryIncrease { get; private set; }
    public Employee Employee { get; private set; }

    public EmployeePromotedDomainEvent(decimal salaryIncrease, Employee employee)
    {
        SalaryIncrease = salaryIncrease;
        Employee = employee;
    }
}
