using MediatR;

namespace Healthcare.Application.Commands.DeleteEmployee;
public sealed class DeleteEmployeeCommand : IRequest<Unit>
{
    public int Id { get; init; }
}
