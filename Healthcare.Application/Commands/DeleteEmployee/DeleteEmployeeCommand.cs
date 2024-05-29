using MediatR;

namespace Healthcare.Application.Commands.DeleteEmployee;
public sealed class DeleteEmployeeCommand : IRequest<Unit>
{
    public string? Id { get; init; }
}
