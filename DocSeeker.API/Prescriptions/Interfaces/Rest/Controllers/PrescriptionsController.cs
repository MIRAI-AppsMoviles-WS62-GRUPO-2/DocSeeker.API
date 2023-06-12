using System.Net.Mime;
using AutoMapper;
using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Domain.Services;
using DocSeeker.API.Prescriptions.Resources;
using DocSeeker.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DocSeeker.API.Prescriptions.Interfaces.Rest.Controllers;

// The world outside the API only has the controllers as the only way to get here.
// We use plural for this file because the endpoints are plural.
// The interface layer does the conversion of Resource objects to comply with the principle of not exposing the model.
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Prescriptions")]
public class PrescriptionsController: ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;
    private readonly IMapper _mapper;
    
    public PrescriptionsController(IPrescriptionService prescriptionService, IMapper mapper)
    {
        _prescriptionService = prescriptionService;
        _mapper = mapper;
    }

    [HttpGet] // When we use this decorator, our Function GetAllAsync is transformed to an Action.
    [ProducesResponseType(typeof(IEnumerable<PrescriptionResource>),200)]
    public async Task<IEnumerable<PrescriptionResource>> GetAllAsync()
    {
        var prescriptions = await _prescriptionService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Prescription>, IEnumerable<PrescriptionResource>>(prescriptions);
        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(PrescriptionResource), 201)] // Created
    [ProducesResponseType(typeof(List<string>), 400)] // BadRequest - list of error messages
    [ProducesResponseType(500)] // InternalServerError - No response type is specified in this case.
    public async Task<IActionResult> PostAsync([FromBody] SavePrescriptionResource resource)
    {
        if (!ModelState.IsValid) // ModelState will validate all the constraints that resource has.
        {
            return BadRequest(ModelState.GetErrorMessages()); // We have coded the extension GetErrorMessages.
        }

        var prescription = _mapper.Map<SavePrescriptionResource, Prescription>(resource);
        var result = await _prescriptionService.SaveAsync(prescription);

        if (!result.Success) // We have coded PrescriptionResponse.
        {
            return BadRequest(result.Message);
        }

        var prescriptionResource = _mapper.Map<Prescription, PrescriptionResource>(result.Resource);

        return Created(nameof(PostAsync), prescriptionResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePrescriptionResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        
        var prescription = _mapper.Map<SavePrescriptionResource, Prescription>(resource);
        var result = await _prescriptionService.UpdateAsync(id, prescription);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var prescriptionResource = _mapper.Map<Prescription, PrescriptionResource>(result.Resource);

        return Ok(prescriptionResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _prescriptionService.DeleteAsync(id);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var prescriptionResource = _mapper.Map<Prescription, PrescriptionResource>(result.Resource);

        return Ok(prescriptionResource);
    }
}