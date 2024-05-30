using Healthcare.Domain.Entities;
using Healthcare.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> employeeConfiguration)
    {
        employeeConfiguration.ToTable("Employees", "dbo");

        employeeConfiguration.Ignore(e => e.DomainEvents);

        employeeConfiguration.HasKey(e => e.Id);
        employeeConfiguration.Property(e => e.Id).ValueGeneratedOnAdd();

        employeeConfiguration
            .Property(e => e.FirstName)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        employeeConfiguration
            .Property(e => e.Email)
            .HasColumnType("varchar")
            .HasMaxLength(125)
            .IsRequired();

        employeeConfiguration
            .Property(e => e.JobTitle)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        employeeConfiguration
            .Property(e => e.LastName)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


        employeeConfiguration
            .Property(e => e.Phone)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .IsRequired();

        employeeConfiguration
            .Property(e => e.HireDate)
            .HasColumnName("HireDate")
            .HasColumnType("DATE")
            .IsRequired();

        employeeConfiguration
            .Property(e => e.DateOfBirth)
            .HasColumnType("DATE")
            .IsRequired();

        employeeConfiguration
            .Property(e => e.Salary)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        employeeConfiguration
            .Property(e => e.Gender)
            .HasConversion(
                g => g.ToString(),
                g => (Gender)Enum.Parse(typeof(Gender), g)
            );
    }
}
