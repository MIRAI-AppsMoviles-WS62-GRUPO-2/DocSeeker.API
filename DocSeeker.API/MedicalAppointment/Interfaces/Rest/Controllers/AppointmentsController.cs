using System.Net.Mime;
using AutoMapper;
using DocSeeker.API.MedicalAppointment.Domain.Models;
using DocSeeker.API.MedicalAppointment.Domain.Services;
using DocSeeker.API.MedicalAppointment.Resources;
using DocSeeker.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DocSeeker.API.MedicalAppointment.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    private readonly IMapper _mapper;

    public AppointmentsController(IAppointmentService appointmentService, IMapper mapper)
    {
        _appointmentService = appointmentService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AppointmentResource>), 200)]
    public async Task<IEnumerable<AppointmentResource>> GetAllAsync()
    {
        var appointments = await _appointmentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAppointmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);
        var result = await _appointmentService.SaveAsync(appointment);

        if (!result.Success)
            return BadRequest(result.Message);

        var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);
        return Created(nameof(PostAsync), appointmentResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAppointmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);
        var result = await _appointmentService.UpdateAsync(id, appointment);

        if (!result.Success)
            return BadRequest(result.Message);

        var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);

        return Ok(appointmentResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _appointmentService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);

        return Ok(appointmentResource);
    }
}