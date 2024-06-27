using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.Entities;

public class Patient : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public Gender Gender { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = [];
    public ICollection<Doctor> Doctors { get; set; } = [];
}