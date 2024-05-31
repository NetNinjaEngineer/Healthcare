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
            .Property(e => e.FirstName).HasColumnType("varchar").HasMaxLength(50).IsRequired();

        employeeConfiguration
            .Property(e => e.Email).HasColumnType("varchar")
            .HasMaxLength(125).IsRequired();

        employeeConfiguration
            .Property(e => e.JobTitle).HasColumnType("varchar")
            .HasMaxLength(50).IsRequired();

        employeeConfiguration
            .Property(e => e.LastName).HasColumnType("varchar").HasMaxLength(50)
            .IsRequired();


        employeeConfiguration
            .Property(e => e.Phone).HasColumnType("varchar")
            .HasMaxLength(20).IsRequired();

        employeeConfiguration
            .Property(e => e.HireDate)
            .HasColumnName("HireDate").HasColumnType("DATE")
            .IsRequired();

        employeeConfiguration
            .Property(e => e.DateOfBirth).HasColumnType("DATE")
            .IsRequired();

        employeeConfiguration
            .Property(e => e.Salary).HasColumnType("decimal(18, 2)")
            .IsRequired();

        employeeConfiguration
            .Property(e => e.Gender)
            .HasConversion(
                g => g.ToString(),
                g => (Gender)Enum.Parse(typeof(Gender), g)
            );

        employeeConfiguration.HasOne(e => e.Department)
            .WithMany(d => d.Employees).HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);

        employeeConfiguration.OwnsOne(e => e.Address, address =>
        {
            address.Property(e => e.City)
                .HasColumnName("City")
                .HasColumnType("varchar")
                .HasMaxLength(50).IsRequired();

            address.Property(e => e.Country)
                .HasColumnType("varchar")
                .HasColumnName("Country")
                .HasMaxLength(50)
                .IsRequired();

            address.Property(e => e.Street)
                .HasColumnName("Street")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            address.Property(e => e.State)
                .HasColumnName("State")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            address.Property(e => e.PostalCode)
                .HasColumnName("PostalCode")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

        });
    }
}
