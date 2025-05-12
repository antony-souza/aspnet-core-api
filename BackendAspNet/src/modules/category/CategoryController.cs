using BackendAspNet.modules.category.dto;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.modules.category;

[Route("category")]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;
    
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
    {
        var response = await _categoryService.Create(createCategoryDto);
        
        if(!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}