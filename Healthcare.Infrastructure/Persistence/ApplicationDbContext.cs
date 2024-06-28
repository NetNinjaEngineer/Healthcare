using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Persistence;
public sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Nurse> Nurses { get; set; }
    public DbSet<Receptionist> Receptionists { get; set; }
    public DbSet<Accountant> Accountants { get; set; }
    public DbSet<Pharmacist> Pharmacists { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MedicalDepartment> MedicalDepartments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<PrescriptionMedication> PrescriptionMedications { get; set; }
    public DbSet<LabTest> LabTests { get; set; }
    public DbSet<Lab> Labs { get; set; }
    public DbSet<LabResult> LabResults { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

}
