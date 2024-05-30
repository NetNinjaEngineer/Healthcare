using AutoMapper;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Application.Commands.CreatePatient;
public sealed class CreatePatientCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreatePatientCommand, Patient>
{
    public async Task<Patient> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = mapper.Map<Patient>(request.PatientForCreateDto);
        unitOfWork.PatientRepository.Create(patient);
        await unitOfWork.CommitAsync();
        return patient;
    }
}
