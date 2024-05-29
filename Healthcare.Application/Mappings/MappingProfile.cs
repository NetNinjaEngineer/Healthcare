using AutoMapper;
using Healthcare.Application.DTOs;
using Healthcare.Domain.Entities;

namespace Healthcare.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmployeeForCreateDto, Employee>();
        CreateMap<EmployeeForUpdateDto, Employee>();
    }
}
