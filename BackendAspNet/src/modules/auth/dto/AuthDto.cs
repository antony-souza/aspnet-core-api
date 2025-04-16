using System.ComponentModel.DataAnnotations;

namespace BackendAspNet.modules.auth.dto;

public class AuthDto
{
    [Required(ErrorMessage = "Email is required!")]   
    [EmailAddress(ErrorMessage = "Email is invalid!")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required!")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long!")]
    public string Password { get; set; } = string.Empty;
}