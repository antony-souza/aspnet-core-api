using System.ComponentModel.DataAnnotations;

namespace BackendAspNet.modules.product.dto;

public class CreateProductDto
{
    [Required(ErrorMessage = "Name is required!")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Price is required!")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Stock is required!")]
    public int Stock { get; set; }
    
    [Required(ErrorMessage = "CategoryId is required!")]   
    public string CategoryId { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "StoreId is required!")]
    public string StoreId { get; set; } = string.Empty;
}