using Healthcare.Domain.Entities;

namespace Healthcare.Domain.Specifications;
public sealed class GetAllEmployeesWithScheduleSpecification : BaseSpecification<Employee>
{
    public GetAllEmployeesWithScheduleSpecification()
    {
        Includes.Add(employee => employee.Schedule!);
    }
}
