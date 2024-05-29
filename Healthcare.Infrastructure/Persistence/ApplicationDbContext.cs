using Healthcare.Domain.Entities;
using Healthcare.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Persistence;
public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());

    }

}
