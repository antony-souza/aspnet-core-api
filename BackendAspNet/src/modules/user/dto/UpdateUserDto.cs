using System.ComponentModel.DataAnnotations;

namespace BackendAspNet.modules.user.dto;

public class UpdateUserDto
{

    public string? Id { get; } = string.Empty;
    
    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}