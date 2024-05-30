namespace Healthcare.Domain.Entities;

public class Appointment : BaseEntity
{
    public DateTime AppointmentDate { get; set; }
    public TimeOnly AppointmentTime { get; set; }
    public bool Paid { get; set; }
    public string? EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public string? PatientId { get; set; }
    public Patient Patient { get; set; }
}