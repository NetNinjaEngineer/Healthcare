using AutoMapper;
using Healthcare.Application.DTOs.Appointment;
using Healthcare.Application.DTOs.Department;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.DTOs.Patient;
using Healthcare.Domain.Entities;

namespace Healthcare.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmployeeForCreateDto, Employee>();
        CreateMap<EmployeeForUpdateDto, Employee>();
        CreateMap<Employee, EmployeeDto>();
        CreateMap<PatientForCreateDto, Patient>();
        CreateMap<AppointmentForCreateDto, Appointment>();
        CreateMap<Patient, PatientDto>();
        CreateMap<Appointment, AppointmentDto>();
        CreateMap<MedicalDepartment, DepartmentDto>();
    }
}
