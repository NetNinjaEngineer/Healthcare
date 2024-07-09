using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DateOfAppointment)
          .HasColumnType("date")
          .IsRequired();

        builder.Property(x => x.TimeOfAppointment)
            .HasColumnType("time")
            .IsRequired();

        builder.ToTable("Appointments");

    }
}
