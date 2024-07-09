using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;

public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.MedicationName)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasPrecision(15, 2).IsRequired();
        builder.Property(x => x.ExpireDate)
            .HasColumnType("date").IsRequired();

        builder.Property(x => x.Description)
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.ToTable("Medications");
    }
}