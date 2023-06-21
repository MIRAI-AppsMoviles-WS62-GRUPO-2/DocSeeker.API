using System.Net.Mime;
using AutoMapper;
using DocSeeker.API.News.Domain.Models;
using DocSeeker.API.News.Domain.Services;
using DocSeeker.API.News.Resources;
using DocSeeker.API.Profiles.Domain.Models;
using DocSeeker.API.Profiles.Domain.Services;
using DocSeeker.API.Profiles.Resources;
using DocSeeker.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DocSeeker.API.News.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class NewController : ControllerBase
{
    private readonly INewService _newService;
    private readonly IMapper _mapper;

    public NewController(INewService newService, IMapper mapper)
    {
        _newService = newService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<NewResource>),200)]
    public async Task<IEnumerable<NewResource>> GetAllAsync()
    {
        var news = await _newService.ListAsync();
        var resources = _mapper.Map<IEnumerable<New>, IEnumerable<NewResource>>(news);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveNewResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        var news = _mapper.Map<SaveNewResource, New>(resource);
        var result = await _newService.SaveAsync(news);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        var newResource = _mapper.Map<New, NewResource>(result.Resource);
        return Created(nameof(PostAsync), newResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveNewResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        var news = _mapper.Map<SaveNewResource, New>(resource);
        var result = await _newService.UpdateAsync(id, news);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        var newResource = _mapper.Map<New, NewResource>(result.Resource);
        return Ok(newResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _newService.DeleteAsync(id);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        var newResource = _mapper.Map<New, NewResource>(result.Resource);
        return Ok(newResource);
    }
}