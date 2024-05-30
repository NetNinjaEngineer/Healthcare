using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.Entities;

public class Patient : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = [];
}