using System.ComponentModel.DataAnnotations;

namespace BackendAspNet.modules.store.dto;

public class CreateStoreDto
{
    [Required(ErrorMessage = "Name is required!")]
    public string Name { get; set; } = string.Empty;
}