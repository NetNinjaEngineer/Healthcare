using Healthcare.Application.DTOs.Employee;
using Healthcare.Domain.Entities;
using System.Text.Json;

namespace Healthcare.Infrastructure.Persistence.SeedWork;
public static class SeedDatabase
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!context.Schedules.Any())
        {
            var schedulesData = File.ReadAllText("../Healthcare.Infrastructure/Persistence/SeedWork/Schedules.json");
            var schedules = JsonSerializer.Deserialize<List<Schedule>>(schedulesData);
            if (schedules?.Count > 0)
                foreach (var schedule in schedules)
                    await context.Schedules.AddAsync(schedule);
            await context.SaveChangesAsync();
        }

        if (!context.Employees.Any())
        {
            var employeesData = File.ReadAllText("../Healthcare.Infrastructure/Persistence/SeedWork/Employees.json");
            var employees = JsonSerializer.Deserialize<IEnumerable<EmployeeDto>>(employeesData);
            if (employees?.Count() > 0)
            {
                foreach (var employeeDto in employees)
                {
                    if (employeeDto.Phone is not null)
                    {
                        var employee = Employee.Create(
                            Guid.NewGuid().ToString(), employeeDto.FirstName!, employeeDto.LastName!,
                            employeeDto.Phone, employeeDto.JobTitle!, employeeDto.Salary,
                            employeeDto.DateOfBirth, employeeDto.HireDate, employeeDto.Gender,
                            employeeDto.Email!, employeeDto.AddressInformation!).Value;

                        await context.Employees.AddAsync(employee);

                    }

                }

                await context.SaveChangesAsync();
            }
        }

    }
}
