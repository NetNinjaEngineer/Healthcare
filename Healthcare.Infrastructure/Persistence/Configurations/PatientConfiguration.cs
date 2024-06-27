using Healthcare.Domain.Entities;
using Healthcare.Domain.ValueObjects;
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
    }
}

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");
        builder.HasMany(x => x.Appointments)
            .WithOne(x => x.Doctor)
    }
}
