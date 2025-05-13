using BackendAspNet.context;
using BackendAspNet.core.interfaces;
using BackendAspNet.modules.product.dto;
using BackendAspNet.modules.product.entity;
using Microsoft.EntityFrameworkCore;

namespace BackendAspNet.modules.product;

public class ProductService
{
    private readonly AppDbContext _appDbContext;
    
    public ProductService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ApiResponse> CreateProduct(CreateProductDto dto)
    {
        var checkProduct = await _appDbContext.Product.FirstOrDefaultAsync(p => p.Name == dto.Name && p.CategoryId == dto.CategoryId);

        if (checkProduct != null)
        {
            return ApiResponse.ErrorResponse("Product already exists!");       
        }

        var createProduct = new ProductEntity()
        {
            Name = dto.Name,
            Price = dto.Price,
            CategoryId = dto.CategoryId
        };
        
        await _appDbContext.Product.AddAsync(createProduct);
        await _appDbContext.SaveChangesAsync();
        
        return ApiResponse.SuccessResponse(createProduct);
    }
}