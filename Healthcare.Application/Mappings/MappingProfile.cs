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
        CreateMap<Employee, EmployeeForListDto>()
           .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
           .ForPath(dest => dest.Address.State, opt => opt.MapFrom(src => src.AddressInformation.State))
           .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.AddressInformation.City))
           .ForPath(dest => dest.Address.PostalCode, opt => opt.MapFrom(src => src.AddressInformation.PostalCode))
           .ForPath(dest => dest.Address.Country, opt => opt.MapFrom(src => src.AddressInformation.Country))
           .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.AddressInformation.Street));


        CreateMap<PatientForCreateDto, Patient>();
        CreateMap<AppointmentForCreateDto, Appointment>();
        CreateMap<Patient, PatientDto>();
        CreateMap<Appointment, AppointmentDto>();
        CreateMap<Employee, EmployeeDto>();
        CreateMap<Employee, EmployeeForListDto>();
        CreateMap<MedicalDepartment, DepartmentDto>();
        CreateMap<Patient, PatientForListDto>();
    }
}
