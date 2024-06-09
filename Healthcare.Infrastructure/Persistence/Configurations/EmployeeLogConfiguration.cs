using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public sealed class EmployeeLogConfiguration : IEntityTypeConfiguration<EmployeeLog>
{
    public void Configure(EntityTypeBuilder<EmployeeLog> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.HasOne(e => e.Employee)
            .WithMany(e => e.EmployeeLogs)
            .HasForeignKey(e => e.EmployeeId)
            .IsRequired();

        builder.ToTable("EmployeeLogs");

    }
}
