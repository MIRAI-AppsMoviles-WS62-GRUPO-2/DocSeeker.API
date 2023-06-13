using AutoMapper;
using DocSeeker.API.Security.Authorization.Attributes;
using DocSeeker.API.Security.Domain.Models;
using DocSeeker.API.Security.Domain.Services;
using DocSeeker.API.Security.Domain.Services.Communication;
using DocSeeker.API.Security.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DocSeeker.API.Security.Interfaces.Rest.Controllers;

[Authorize] // Decorator that we have created
[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController: ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    // [Authorize] asks us by default for the token header, but that doesn't make sense
    // for sign-in and sign-up,that's why we use [AllowAnonymous]
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _userService.AuthenticateAsync(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }

    // In the case of Get, the token is necessary since only a valid user should have access to this function.
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        return Ok(resources);
    }
}