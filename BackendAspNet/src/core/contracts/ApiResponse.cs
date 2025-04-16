namespace BackendAspNet.core.contracts;

public class ApiResponse
{
    public string Message { get; set; } = string.Empty;
    public object? Data { get; set; } 
    public string[] Errors { get; set; } = [];
}