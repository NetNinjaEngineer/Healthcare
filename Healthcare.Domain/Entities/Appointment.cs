using Healthcare.Domain.Interceptors;

namespace Healthcare.Domain.Entities;

public class Appointment : BaseEntity, ISoftDeletable
{
    public DateTime AppointmentDate { get; set; }
    public DateTime AppointmentTime { get; set; }
    public bool Paid { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public Employee Employee { get; set; }
    public string PatientId { get; set; } = string.Empty;
    public Patient Patient { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}