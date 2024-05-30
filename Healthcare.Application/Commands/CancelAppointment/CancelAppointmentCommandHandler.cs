using AutoMapper;
using Healthcare.Application.DTOs.Appointment;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Commands.CancelAppointment;
public sealed class CancelAppointmentCommandHandler
    : IRequestHandler<CancelAppointmentCommand, AppointmentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CancelAppointmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AppointmentDto> Handle(
        CancelAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var appointment = _unitOfWork.AppointmentRepository
               .GetAllAsync()
               .Result
               .SingleOrDefault(e => e.PatientId == request.PatientId && e.Id == request.AppointmentId)
               ?? throw new AppointmentNotFoundException($"Appointment with id: {request.AppointmentId} was not founded.");
        _unitOfWork.AppointmentRepository.Delete(appointment);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AppointmentDto>(appointment);
    }
}
