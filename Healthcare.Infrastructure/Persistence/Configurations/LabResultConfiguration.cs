using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class LabResultConfiguration : IEntityTypeConfiguration<LabResult>
{
    public void Configure(EntityTypeBuilder<LabResult> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.LabTest)
            .WithMany(x => x.LabResults)
            .HasForeignKey(x => x.LabTestId).IsRequired();

        builder.HasOne(x => x.Appointment)
            .WithMany(x => x.LabResults).HasForeignKey(x => x.AppointmentId)
            .IsRequired();

        builder.Property(x => x.Result)
            .HasColumnType("VARCHAR")
            .HasMaxLength(128).IsRequired();

        builder.Property(x => x.ResultDate)
            .HasColumnType("date").IsRequired();

        builder.ToTable("LabResults");
    }
}
