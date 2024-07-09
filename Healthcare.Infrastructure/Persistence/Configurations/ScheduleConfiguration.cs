using Healthcare.Domain.Entities;
using Healthcare.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasConversion(
                x => x.ToString(),
                x => (ScheduleEnum)Enum.Parse(typeof(ScheduleEnum), x)
            );

        builder.OwnsOne(x => x.TimeSlot,
            ts =>
            {
                ts.Property(p => p.StartTime)
                .HasColumnName("StartTime").HasColumnType("time").IsRequired();

                ts.Property(p => p.EndTime)
                .HasColumnName("EndTime").HasColumnType("time").IsRequired();
            });

        builder.ToTable("Schedules");
    }
}
