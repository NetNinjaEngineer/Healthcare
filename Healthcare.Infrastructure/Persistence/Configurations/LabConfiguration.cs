using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class LabConfiguration : IEntityTypeConfiguration<Lab>
{
    public void Configure(EntityTypeBuilder<Lab> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.LabName)
            .HasMaxLength(100).IsRequired();
        builder.Property(x => x.Location)
            .HasMaxLength(100).IsRequired();
        builder.ToTable("Labs");
    }
}
