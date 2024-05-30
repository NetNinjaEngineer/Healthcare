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

        appointmentConfiguration.HasOne(x => x.Employee)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.EmployeeId)
            .IsRequired();

        appointmentConfiguration.HasOne(x => x.Patient)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.PatientId)
            .IsRequired();

        appointmentConfiguration.ToTable("Appointments");

    }
}
