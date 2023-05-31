namespace DocSeeker.API.Shared.Domain.Services.Communication;

public abstract class BaseResponse<T>
{
    // Unhappy Response
    protected BaseResponse(string message)
    {
        Success = false;
        Message = message;
        Resource = default;
    }

    // Happy Response
    protected BaseResponse(T resource)
    {
        Success = true;
        Message = string.Empty;
        Resource = resource;
    }

    public bool Success { get; protected set; }
    
    public string Message { get; protected set; }
    
    public T Resource { get; protected set; }
}