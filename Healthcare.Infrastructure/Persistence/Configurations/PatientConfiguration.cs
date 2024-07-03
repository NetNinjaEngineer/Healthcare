using Healthcare.Domain.Entities;
using Healthcare.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.FirstName)
            .HasColumnType("varchar").HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Email)
            .HasColumnType("varchar").HasMaxLength(125)
            .IsRequired();

        builder.Property(e => e.LastName)
            .HasColumnType("varchar").HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Phone)
            .HasColumnType("varchar").HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.Gender)
            .HasConversion(
                g => g.ToString(),
                g => (Gender)Enum.Parse(typeof(Gender), g)
            );

        builder.HasMany(x => x.Doctors)
            .WithMany(x => x.Patients)
            .UsingEntity<Appointment>(
                left => left.HasOne(x => x.Doctor)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.DoctorId),
                right => right.HasOne(x => x.Patient)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.PatientId)
            );
    }
}