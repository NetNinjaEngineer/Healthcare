using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class MedicalDepartmentConfiguration : IEntityTypeConfiguration<MedicalDepartment>
{
    public void Configure(EntityTypeBuilder<MedicalDepartment> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasColumnType("varchar")
            .HasMaxLength(40).IsRequired();

        builder.ToTable("MedicalDepartments");

    }
}
