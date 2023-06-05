using AutoMapper;
using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Domain.Services;
using DocSeeker.API.Prescriptions.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DocSeeker.API.Prescriptions.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/prescriptions/{prescriptionId}/medicines")]
public class PrescriptionMedicinesController: ControllerBase
{
    private readonly IMedicineService _medicineService;
    private readonly IMapper _mapper;

    public PrescriptionMedicinesController(IMedicineService medicineService, IMapper mapper)
    {
        _medicineService = medicineService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<MedicineResource>> GetAllByPrescriptionId(int prescriptionId)
    {
        var medicines = await _medicineService.ListByPrescriptionIdAsync(prescriptionId);
        var resources = _mapper.Map<IEnumerable<Medicine>, IEnumerable<MedicineResource>>(medicines);

        return resources;
    }
}