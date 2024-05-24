using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.FirstName)
            .HasColumnType("varchar").HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.LastName)
            .HasColumnType("varchar").HasMaxLength(50)
            .IsRequired();


        builder.Property(e => e.JobTitle)
            .HasColumnType("varchar").HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.HireDate)
            .HasColumnType("DATE")
            .IsRequired();

        builder.Property(e => e.Phone)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.DateOfBirth)
          .HasColumnType("DATE")
          .IsRequired();

        builder.Property(e => e.Salary)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        builder.Property(e => e.Gender)
            .HasConversion(
                g => g.ToString(),
                g => (Gender)Enum.Parse(typeof(Gender), g)
            );
    }
}
