using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BackendAspNet.modules.user.dto;

public class CreateUserDto
{
    [Required(ErrorMessage = "Name is required!")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required!")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password is required!")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long!")]
    public string Password { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "StoreId is required!")]
    public string StoreId { get; set; } = string.Empty;
}