using AutoMapper;
using Healthcare.Application.Interfaces;
using Healthcare.Application.Responses;
using Healthcare.Domain.Entities;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Commands.ScheduleAppointment;
public sealed class ScheduleAppointmentCommandHandler
    : IRequestHandler<ScheduleAppointmentCommand, ScheduleAppointmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ScheduleAppointmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ScheduleAppointmentResponse> Handle(
        ScheduleAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var patient = await _unitOfWork.PatientRepository.GetByIdAsync(request.PatientId)
            ?? throw new PatientNotFoundException($"Patient with id: {request.PatientId} not founded.");

        // TODO: There are no departments data
        bool departmentExists = _unitOfWork.DepartmentRepository.CheckExists(request.DepartmentId);
        if (!departmentExists)
            throw new DepartmentNotFoundException($"Department with id: {request.DepartmentId} not founded.");

        var scheduleAppointment = _mapper.Map<Appointment>(request.Appointment);

        _unitOfWork.AppointmentRepository.Create(scheduleAppointment);

        await _unitOfWork.CommitAsync();

        var doctor = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.Appointment.EmployeeId);

        return new ScheduleAppointmentResponse
        {
            AppointmentId = scheduleAppointment.Id,
            DateOfAppointment = scheduleAppointment.AppointmentDate,
            PatientId = patient.Id,
            TimeOfAppointment = scheduleAppointment.AppointmentTime,
            Doctor = doctor.FirstName!
        };
    }
}
