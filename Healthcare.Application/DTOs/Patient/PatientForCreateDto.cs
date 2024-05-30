using Healthcare.Domain.ValueObjects;

namespace Healthcare.Application.DTOs.Patient;

public record PatientForCreateDto(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    Gender Gender);
