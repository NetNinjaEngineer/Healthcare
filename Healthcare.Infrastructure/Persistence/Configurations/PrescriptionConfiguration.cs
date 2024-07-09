using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PrescriptionDate)
            .HasColumnType("date")
            .IsRequired();
        builder.HasMany(x => x.Medications)
            .WithMany(x => x.Prescriptions)
            .UsingEntity<PrescriptionMedication>(
                left => left.HasOne(x => x.Medication).WithMany(x => x.PrescriptionMedications)
                .HasForeignKey(x => x.MedicationId),
                right => right.HasOne(x => x.Prescription).WithMany(x => x.PrescriptionMedications)
                .HasForeignKey(x => x.PrescriptionId)
            );

        builder.ToTable("Prescriptions");
    }
}