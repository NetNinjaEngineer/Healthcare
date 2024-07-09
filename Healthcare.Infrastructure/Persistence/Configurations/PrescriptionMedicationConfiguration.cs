using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;

public class PrescriptionMedicationConfiguration : IEntityTypeConfiguration<PrescriptionMedication>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedication> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Dosage)
            .HasColumnType("varchar")
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(x => x.Instructions)
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.ToTable("PrescriptionMedications");
    }
}

