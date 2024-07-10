using Healthcare.Domain.Entities;

namespace Healthcare.Domain.Specifications;
public class EmployeeWithFilterationCountSpecification : BaseSpecification<Employee>
{
    public EmployeeWithFilterationCountSpecification(EmployeeSpecParams employeeParams)
         : base(e =>
            (string.IsNullOrEmpty(employeeParams.SearchTerm) || string.Concat(e.FirstName, " ", e.LastName).ToLower().Contains(employeeParams.SearchTerm))
            &&
            (string.IsNullOrEmpty(employeeParams.Gender.ToString()) || e.Gender == employeeParams.Gender)
            &&
            (string.IsNullOrEmpty(employeeParams.Email) || e.Email.ToLower() == employeeParams.Email.ToLower())
        )
    {

    }
}
