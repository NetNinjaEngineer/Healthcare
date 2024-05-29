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
            .Property<string>("_firstName")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("FirstName")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        employeeConfiguration
            .Property<string>("_jobTitle")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("JobTitle")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        employeeConfiguration
            .Property<string>("_lastName")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("LastName")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


        employeeConfiguration
            .Property<string>("_phone")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Phone")
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .IsRequired();

        employeeConfiguration
            .Property<DateTime>("_hireDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("HireDate")
            .HasColumnType("DATE")
            .IsRequired();

        employeeConfiguration
            .Property<DateTime>("_dateOfBirth")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("DateOfBirth")
            .HasColumnType("DATE")
            .IsRequired();

        employeeConfiguration
            .Property<decimal>("_salary")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Salary")
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        employeeConfiguration
            .Property<Gender>("_gender")
            .HasColumnName("Gender")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasConversion(
                g => g.ToString(),
                g => (Gender)Enum.Parse(typeof(Gender), g)
            );
    }
}
