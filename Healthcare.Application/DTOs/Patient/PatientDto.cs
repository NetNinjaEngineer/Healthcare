using Healthcare.Application.DTOs.Common;

namespace Healthcare.Application.DTOs.Patient;
public class PatientDto : BaseDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Gender { get; set; }
}
