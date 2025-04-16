using System.ComponentModel.DataAnnotations;

namespace BackendAspNet.modules.user.schema;

public class UserSchema
{
    [Required(ErrorMessage = "Name is required!")]
    public string Name { get; set; } = String.Empty;
    
    [Required(ErrorMessage = "Email is required!")]
    public string Email { get; set; } = String.Empty;
    
    [Required(ErrorMessage = "Password is required!")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long!")]
    public string Password { get; set; } = String.Empty;
}