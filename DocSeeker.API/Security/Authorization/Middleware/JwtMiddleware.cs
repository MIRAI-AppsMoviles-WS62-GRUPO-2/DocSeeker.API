using DocSeeker.API.Security.Authorization.Handlers.Interfaces;
using DocSeeker.API.Security.Authorization.Settings;
using DocSeeker.API.Security.Domain.Services;

namespace DocSeeker.API.Security.Authorization.Middleware;

// We use Change Responsibility pattern.
// This is the jwt handler implementation.
public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, AppSettings appSettings)
    {
        _next = next;
        _appSettings = appSettings;
    }

    // For the Middleware to work we have to use the Invoke function
    // context encapsulates all information from the request
    // to manipulate the JWT we use a handler
    public async Task Invoke(HttpContext context, IUserService userService, IJwtHandler handler)
    {
        // Get Token
        // The token comes in the format Authorization 1k3... , we want the 2nd part (1k3...)
        var token = context.Request.Headers["Authorization"]
            .FirstOrDefault()?
            .Split(" ")
            .Last();
        
        // Extract UserId
        var userId = handler.ValidateToken(token);

        // Did we get any userId ?
        if (userId != null)
            context.Items["User"] = await userService.GetByIdAsync(userId.Value);
        
        // Call next in chain
        
        await _next(context);
    }
}