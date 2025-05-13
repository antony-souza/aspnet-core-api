using BackendAspNet.context;
using BackendAspNet.core.interfaces;
using BackendAspNet.modules.order.dto;

namespace BackendAspNet.modules.order;

public class OrderService
{
    private readonly AppDbContext _appDbContext;
    
    public OrderService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ApiResponse> CreateOrder(CreateOrderDto dto)
    {
        
        return ApiResponse.SuccessResponse("gg");
    }
}