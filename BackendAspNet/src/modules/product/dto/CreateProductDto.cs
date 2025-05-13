using System.ComponentModel.DataAnnotations;

namespace BackendAspNet.modules.product.dto;

public class CreateProductDto
{
    [Required(ErrorMessage = "Name is required!")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Price is required!")]
    public decimal Price { get; set; }
    
    public string CategoryId { get; set; } = string.Empty;
}