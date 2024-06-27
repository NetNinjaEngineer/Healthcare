using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.DoctorId).IsRequired();
        builder.Property(x => x.PatientId).IsRequired();

        builder.Property(x => x.AppointmentDate)
          .HasColumnType("date")
          .IsRequired();

        builder.Property(x => x.AppointmentTime)
         .HasConversion(
            v => v.TimeOfDay,
            v => DateTime.Today.Add(v)
            ).IsRequired();

        builder.HasOne(x => x.Patient)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.PatientId)
            .IsRequired();

        builder.ToTable("Appointments");

    }
}
