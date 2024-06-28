using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class LabTestConfiguration : IEntityTypeConfiguration<LabTest>
{
    public void Configure(EntityTypeBuilder<LabTest> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasOne(x => x.Lab)
            .WithMany(x => x.LabTests)
            .HasForeignKey(x => x.LabId)
            .IsRequired();

        builder.Property(x => x.TestName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.TestDescription)
            .HasMaxLength(100).IsRequired();

        builder.ToTable("LabTests");
    }
}
