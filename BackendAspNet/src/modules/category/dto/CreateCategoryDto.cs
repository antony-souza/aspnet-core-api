using System.ComponentModel.DataAnnotations;

namespace BackendAspNet.modules.category.dto;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "Name is required!")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "StoreId is required!")]
    public string StoreId { get; set; } = string.Empty;
}