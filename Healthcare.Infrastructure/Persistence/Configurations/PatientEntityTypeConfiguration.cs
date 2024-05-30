using Healthcare.Domain.Entities;
using Healthcare.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> patientConfiguration)
    {
        patientConfiguration.ToTable("Patients", "dbo");

        patientConfiguration.Ignore(e => e.DomainEvents);

        patientConfiguration.HasKey(e => e.Id);

        patientConfiguration.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        patientConfiguration.Property(e => e.FirstName)
            .HasColumnType("varchar").HasMaxLength(50)
            .IsRequired();

        patientConfiguration.Property(e => e.Email)
            .HasColumnType("varchar").HasMaxLength(125)
            .IsRequired();

        patientConfiguration.Property(e => e.LastName)
            .HasColumnType("varchar").HasMaxLength(50)
            .IsRequired();


        patientConfiguration.Property(e => e.Phone)
            .HasColumnType("varchar").HasMaxLength(20)
            .IsRequired();

        patientConfiguration
        .Property(e => e.Gender)
        .HasConversion(
            g => g.ToString(),
            g => (Gender)Enum.Parse(typeof(Gender), g)
        );

    }
}
