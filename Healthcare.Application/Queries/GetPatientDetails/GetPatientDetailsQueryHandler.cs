using AutoMapper;
using Healthcare.Application.DTOs.Patient;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Queries.GetPatientDetails;
public sealed class GetPatientDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetPatientDetailsQuery, PatientDto>
{
    public async Task<PatientDto> Handle(
        GetPatientDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var patient = await unitOfWork.PatientRepository.GetByIdAsync(request.PatientId)
                ?? throw new PatientNotFoundException($"Patient was not founded");
        return mapper.Map<PatientDto>(patient);
    }
}
