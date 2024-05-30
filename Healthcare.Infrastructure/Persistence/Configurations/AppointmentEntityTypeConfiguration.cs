using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
internal class AppointmentEntityTypeConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> appointmentConfiguration)
    {
        appointmentConfiguration.HasKey(x => x.Id);
        appointmentConfiguration.Property(x => x.Id).ValueGeneratedOnAdd();

        appointmentConfiguration.Property(x => x.EmployeeId).IsRequired();
        appointmentConfiguration.Property(x => x.PatientId).IsRequired();

        appointmentConfiguration.Property(x => x.AppointmentDate)
          .HasColumnType("date")
          .IsRequired();

        appointmentConfiguration.Property(x => x.AppointmentTime)
         .HasConversion(
            v => v.TimeOfDay, // Convert DateTime to TimeSpan
            v => DateTime.Today.Add(v)
            ).IsRequired();

        appointmentConfiguration.HasOne(x => x.Employee)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.EmployeeId)
            .IsRequired();

        appointmentConfiguration.HasOne(x => x.Patient)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.PatientId)
            .IsRequired();

        appointmentConfiguration.HasQueryFilter(x => x.IsDeleted == false);

        appointmentConfiguration.ToTable("Appointments");

    }
}
