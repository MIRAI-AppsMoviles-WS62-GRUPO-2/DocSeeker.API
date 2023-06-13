using DocSeeker.API.Security.Domain.Models;

namespace DocSeeker.API.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    
    // If the token is valid, the method can return the ID associated
    // with the token as an integer. If the token is not valid the method returns null.
    public int? ValidateToken(string token);
}