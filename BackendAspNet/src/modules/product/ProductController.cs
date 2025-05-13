using BackendAspNet.core.utils;
using BackendAspNet.modules.product.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.modules.product;

[Authorize]
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
        return GenericResponseController.Handler(response);
    }
    
    [HttpGet]
    [Route("all-products")]
    public async Task<IActionResult> FindAllProducts()
    {
        var response = await _productService.FindAllProducts();
        return GenericResponseController.Handler(response);
    }
    
    [HttpGet]
    [Route("find-by-id/{id:guid}")]
    public async Task<IActionResult> FindProductById([FromRoute] string id)
    {
        var response = await _productService.FindProductById(id);
        return GenericResponseController.Handler(response);
    }
}