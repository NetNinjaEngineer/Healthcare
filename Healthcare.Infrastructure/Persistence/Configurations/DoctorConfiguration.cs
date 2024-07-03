using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Healthcare.Infrastructure.Persistence.Configurations;
public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasOne(x => x.MedicalDepartment)
            .WithMany(x => x.Doctors)
            .HasForeignKey(x => x.MedicalDepartmentId)
            .HasConstraintName("FK_Doctors_MedicalDepartments_MedicalDepartmentId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
