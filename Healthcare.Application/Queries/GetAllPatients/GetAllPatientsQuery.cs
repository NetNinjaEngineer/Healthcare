using Healthcare.Application.DTOs.Patient;
using MediatR;

namespace Healthcare.Application.Queries.GetAllPatients;
public sealed class GetAllPatientsQuery : IRequest<IEnumerable<PatientForListDto>>
{
}
