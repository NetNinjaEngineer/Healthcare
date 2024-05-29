﻿using FluentValidation;
using Healthcare.Application.Commands.CreateEmployee;
using Healthcare.Application.DTOs;

namespace Healthcare.Application.Commands.UpdateEmployee;
public sealed class UpdateEmployeeCommandValidator : AbstractValidator<EmployeeForUpdateDto>
{
    public UpdateEmployeeCommandValidator()
    {
        Include(new CreateEmployeeCommandValidator());
    }
}
