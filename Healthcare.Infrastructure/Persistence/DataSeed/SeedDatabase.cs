using Healthcare.Domain.Entities;
using Newtonsoft.Json;

namespace Healthcare.Infrastructure.Persistence.DataSeed;
public static class SeedDatabase
{
    public static async Task Seed(ApplicationDbContext context)
    {
        if (!context.Employees.Any())
        {
            var employeesAsText = File.ReadAllText("..\\Healthcare.Infrastructure\\Persistence\\DataSeed\\SeedDatabase.json");
            List<Employee>? employees = JsonConvert.DeserializeObject<List<Employee>>(employeesAsText);
            if (employees?.Count > 0)
                await context.Employees.AddRangeAsync(employees);
        }

        await context.SaveChangesAsync();
    }
}
