using BackendAspNet.context;
using BackendAspNet.core.interfaces;
using BackendAspNet.modules.category.dto;
using BackendAspNet.modules.category.entity;
using Microsoft.EntityFrameworkCore;

namespace BackendAspNet.modules.category;

public class CategoryService
{
    private readonly AppDbContext _appDbContext;

    public CategoryService(AppDbContext appContext)
    {
        _appDbContext = appContext;
    }
    
    public async Task<ApiResponse> Create(CreateCategoryDto dto)
    {
        var checkCategory = await _appDbContext.Category.FirstOrDefaultAsync(c => c.Name == dto.Name);
        
        if (checkCategory != null)
        {
            return ApiResponse.ErrorResponse("Category already exists!");
        }

        var createCategory = new CategoryEntity
        {
            Name = dto.Name,
        };

        await _appDbContext.Category.AddAsync(createCategory);
        await _appDbContext.SaveChangesAsync();
        
        return ApiResponse.SuccessResponse(createCategory);
    }
}