using BackendAspNet.context;
using BackendAspNet.core.interfaces;
using BackendAspNet.modules.store.dto;
using BackendAspNet.modules.store.entity;
using Microsoft.EntityFrameworkCore;

namespace BackendAspNet.modules.store;

public class StoreService
{
    private readonly AppDbContext _appDbContext;

    public StoreService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ApiResponse> CreateStore(CreateStoreDto dto)
    {
        var checkStore = await _appDbContext.Store.FirstOrDefaultAsync(s => s.Name == dto.Name);
        if (checkStore != null)
        {
            return ApiResponse.ErrorResponse("Store already exists!");
        }

        var createStore = new StoreEntity()
        {
            Name = dto.Name
        };

        await _appDbContext.Store.AddAsync(createStore);
        await _appDbContext.SaveChangesAsync();

        return ApiResponse.SuccessResponse(createStore);
    }
    
    public async Task<ApiResponse> FindAllStores()
    {
        var stores = await _appDbContext.Store
            .Where(s => s.Enabled == true)
            .ToListAsync();
        
        return stores.Count == 0 ? ApiResponse.ErrorResponse("Stores not found!") : ApiResponse.SuccessResponse(stores);
    }

    public async Task<ApiResponse> FindStoreById(string id)
    {
        var store = await _appDbContext.Store.FirstOrDefaultAsync(s => s.Id == id && s.Enabled == true);

        return store == null ? ApiResponse.ErrorResponse("Store not found!") : ApiResponse.SuccessResponse(store);
    }
}