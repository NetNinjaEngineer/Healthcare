using Healthcare.Application.DTOs;
using Healthcare.Domain.Entities;

namespace Healthcare.Application.Mappings;
public static class EmployeeMapper
{
    public static void MapUpdateEmployeeRequestToEmployeeType(
       this Employee employee, EmployeeForUpdateDto updatedEmployee)
    {
        ArgumentNullException.ThrowIfNull(updatedEmployee, nameof(updatedEmployee));

        if (updatedEmployee.FirstName is not null)
            employee.SetFirstName(updatedEmployee.FirstName);

        if (updatedEmployee.LastName is not null)
            employee.SetLastName(updatedEmployee.LastName);

        if (updatedEmployee.Email is not null)
            employee.SetEmail(updatedEmployee.Email);

        if (updatedEmployee.Phone is not null)
            employee.SetPhone(updatedEmployee.Phone);

        if (updatedEmployee.JobTitle is not null)
            employee.SetJobTitle(updatedEmployee.JobTitle);

        if (updatedEmployee.DateOfBirth.HasValue)
            employee.SetDateOfBirth(updatedEmployee.DateOfBirth.Value);

        if (updatedEmployee.HireDate.HasValue)
            employee.SetHiringDate(updatedEmployee.HireDate.Value);

        if (updatedEmployee.Salary.HasValue)
            employee.SetSalary(updatedEmployee.Salary.Value);

        if (updatedEmployee.Gender.HasValue)
            employee.SetGender(updatedEmployee.Gender.Value);
    }
}
