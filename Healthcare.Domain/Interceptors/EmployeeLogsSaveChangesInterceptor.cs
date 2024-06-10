using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Healthcare.Domain.Interceptors;
public sealed class EmployeeLogsSaveChangesInterceptor
    : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        var context = eventData.Context;
        if (context is null)
            return base.SavingChanges(eventData, result);

        var employeeEntries = context.ChangeTracker.Entries<Employee>()
            .Where(e => e.State == EntityState.Added);

        foreach (var employee in employeeEntries)
        {
            var employeeLog = new EmployeeLog
            {
                Action = "Insert",
                ActionTime = DateTime.Now,
                EmployeeId = employee.Entity.Id
            };

            context.Set<EmployeeLog>().Add(employeeLog);

            context.SaveChanges();
        }

        return base.SavingChanges(eventData, result);

    }
}
