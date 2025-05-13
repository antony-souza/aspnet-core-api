using BackendAspNet.modules.product.dto;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.modules.product;

[Route("product")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
    {
        var response = await _productService.CreateProduct(createProductDto);

        if (!response.Success)
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }
}