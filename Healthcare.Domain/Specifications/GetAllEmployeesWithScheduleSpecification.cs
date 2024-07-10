using Healthcare.Domain.Entities;

namespace Healthcare.Domain.Specifications;
public sealed class GetAllEmployeesWithScheduleSpecification : BaseSpecification<Employee>
{
    public GetAllEmployeesWithScheduleSpecification(EmployeeSpecParams employeeParams)
        : base(e =>
            (string.IsNullOrEmpty(employeeParams.SearchTerm) || string.Concat(e.FirstName, " ", e.LastName).ToLower().Contains(employeeParams.SearchTerm))
            &&
            (string.IsNullOrEmpty(employeeParams.Gender.ToString()) || e.Gender == employeeParams.Gender)
            &&
            (string.IsNullOrEmpty(employeeParams.Email) || e.Email.ToLower() == employeeParams.Email.ToLower())
        )
    {
        Includes.Add(employee => employee.Schedule!);

        if (!string.IsNullOrEmpty(employeeParams.Sort))
        {
            switch (employeeParams.Sort)
            {
                case "SalaryAsc":
                    AddOrderBy(employee => employee.Salary);
                    break;

                case "SalaryDesc":
                    AddOrderByDescending(employee => employee.Salary);
                    break;

                default:
                    break;
            }
        }

        ApplyPagination((employeeParams.PageNumber - 1) * employeeParams.PageSize, employeeParams.PageSize);

    }
}
