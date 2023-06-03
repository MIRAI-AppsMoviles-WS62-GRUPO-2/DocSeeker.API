using System.Net.Mime;
using AutoMapper;
using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Domain.Services;
using DocSeeker.API.Prescriptions.Resources;
using DocSeeker.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DocSeeker.API.Prescriptions.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MedicinesController: ControllerBase
{
    private readonly IMedicineService _medicineService;
    private readonly IMapper _mapper;


    public MedicinesController(IMedicineService medicineService, IMapper mapper)
    {
        _medicineService = medicineService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MedicineResource>), 200)]
    public async Task<IEnumerable<MedicineResource>> GetAllAsync()
    {
        var medicines = await _medicineService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Medicine>, IEnumerable<MedicineResource>>(medicines);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveMedicineResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var medicine = _mapper.Map<SaveMedicineResource, Medicine>(resource);
        var result = await _medicineService.SaveAsync(medicine);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var medicineResource = _mapper.Map<Medicine, MedicineResource>(result.Resource);

        return Created(nameof(PostAsync), medicineResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMedicineResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var medicine = _mapper.Map<SaveMedicineResource, Medicine>(resource);
        var result = await _medicineService.UpdateAsync(id, medicine);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var medicineResource = _mapper.Map<Medicine, MedicineResource>(result.Resource);

        return Ok(medicineResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _medicineService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var medicineResource = _mapper.Map<Medicine, MedicineResource>(result.Resource);
        
        return Ok(medicineResource);
    }
}