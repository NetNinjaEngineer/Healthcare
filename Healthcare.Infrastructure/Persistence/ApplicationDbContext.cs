using Healthcare.Domain.Entities;
using Healthcare.Domain.Interceptors;
using Healthcare.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Persistence;
public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeLog> EmployeeLogs { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.AddInterceptors(new EmployeeLogsSaveChangesInterceptor());

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new PatientEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentEntityTypeConfiguration());

    }

}
