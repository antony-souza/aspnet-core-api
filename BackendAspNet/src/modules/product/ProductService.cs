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
        var checkProduct =
            await _appDbContext.Product.FirstOrDefaultAsync(p => p.Name == dto.Name && p.CategoryId == dto.CategoryId && p.StoreId == dto.StoreId);

        if (checkProduct != null)
        {
            return ApiResponse.ErrorResponse("Product already exists!");
        }

        var createProduct = new ProductEntity()
        {
            Name = dto.Name,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            StoreId = dto.StoreId
        };

        await _appDbContext.Product.AddAsync(createProduct);
        await _appDbContext.SaveChangesAsync();

        return ApiResponse.SuccessResponse(createProduct);
    }

    public async Task<ApiResponse> FindAllProducts()
    {
        var users = await _appDbContext.Product
            .Include(p => p.Store)
            .Include(p => p.Category)
            .Where(p => p.Enabled == true)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Price,
                category = p.Category.Name,
                store = p.Store.Name
            })
            .ToListAsync();

        return users.Count == 0 ? ApiResponse.ErrorResponse("Products not found!") : ApiResponse.SuccessResponse(users);
    }

    public async Task<ApiResponse> FindProductById(string id)
    {
        var user = await _appDbContext.Product.FirstOrDefaultAsync(p => p.Id == id && p.Enabled == true);

        if (user == null)
        {
            return ApiResponse.ErrorResponse("Product not found!");
        }

        return ApiResponse.SuccessResponse(user);
    }
}