using Healthcare.Domain.Enumerations;

namespace Healthcare.Application.DTOs.Patient;
public record PatientForUpdateDto : PatientForCreateDto
{
    public PatientForUpdateDto(string FirstName, string LastName, string Email, string Phone, Gender Gender)
        : base(FirstName, LastName, Email, Phone, Gender)
    {
    }
}
