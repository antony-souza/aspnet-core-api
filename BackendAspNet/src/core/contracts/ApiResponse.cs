public class ApiResponse
{
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public object? Data { get; set; }

    public static ApiResponse SuccessResponse(object? data)
    {
        return new ApiResponse { Success = true, Data = data };
    }

    public static ApiResponse ErrorResponse(string message)
    {
        return new ApiResponse { Success = false, Message = message };
    }
}