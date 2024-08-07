﻿using AutoMapper;
using Healthcare.Application.DTOs.Patient;
using Healthcare.Application.Interfaces;
using MediatR;

namespace Healthcare.Application.Queries.GetAllPatients;
public sealed class GetAllPatientsQueryHandler
    : IRequestHandler<GetAllPatientsQuery, IEnumerable<PatientDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPatientsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PatientDto>> Handle(
        GetAllPatientsQuery request,
        CancellationToken cancellationToken)
        => _mapper.Map<IEnumerable<PatientDto>>(await _unitOfWork.PatientRepository.GetAllAsync());
}
