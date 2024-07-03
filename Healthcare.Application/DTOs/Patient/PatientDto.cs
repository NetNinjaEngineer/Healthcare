using Healthcare.Application.DTOs.Appointment;
using Healthcare.Application.DTOs.Common;
using Healthcare.Domain.Enumerations;

namespace Healthcare.Application.DTOs.Patient;
public class PatientDto : BaseEntityDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public ICollection<AppointmentDto> Appointments { get; set; } = [];
}
