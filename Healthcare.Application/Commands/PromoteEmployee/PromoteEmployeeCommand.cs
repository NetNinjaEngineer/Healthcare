﻿using Healthcare.Application.DTOs.Employee;
using MediatR;

namespace Healthcare.Application.Commands.PromoteEmployee;
public sealed class PromoteEmployeeCommand : IRequest<Unit>
{
    public string? EmployeeId { get; set; }
    public PromoteEmployeeDto? PromoteEmployeeModel { get; set; }
}
