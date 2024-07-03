using Healthcare.Domain.Entities;
using Healthcare.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.RoomType)
            .HasConversion(
                x => x.ToString(),
                x => (RoomType)Enum.Parse(typeof(RoomType), x)
            );

        builder.Property(x => x.AvailabilityStatus)
            .HasConversion(
                x => x.ToString(),
                x => (AvailabilityStatus)Enum.Parse(typeof(AvailabilityStatus), x)
            );

        builder.HasOne(x => x.MedicalDepartment)
            .WithMany(x => x.Rooms)
            .HasForeignKey(x => x.MedicalDepartmentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.ToTable("Rooms");
    }
}
