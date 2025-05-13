using BackendAspNet.core.utils;
using BackendAspNet.modules.category.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.modules.category;

[Authorize]
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
        return GenericResponseController.Handler(response);;
    }
    
    [HttpGet]
    [Route("all-categories")]
    public async Task<IActionResult> FindAllCategories()
    {
        var response = await _categoryService.FindAllCategories();
        return GenericResponseController.Handler(response);;
    }
    
    [HttpGet]
    [Route("find-by-id/{id:guid}")]
    public async Task<IActionResult> FindUserById([FromRoute] string id)
    {
        var response = await _categoryService.FindCategoryById(id);
        return GenericResponseController.Handler(response);;
    }
}