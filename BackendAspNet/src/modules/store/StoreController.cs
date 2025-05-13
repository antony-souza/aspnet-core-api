using BackendAspNet.core.utils;
using BackendAspNet.modules.store.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.modules.store;

[Authorize]
[Route("store")]
public class StoreController : ControllerBase
{
    private readonly StoreService _storeService;

    public StoreController(StoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateStore([FromBody] CreateStoreDto dto)
    {
        var response = await _storeService.CreateStore(dto);
        return GenericResponseController.Handler(response);
    }
    
    [HttpGet]
    [Route("all-stores")]
    public async Task<IActionResult> FindAllStores()
    {
        var response = await _storeService.FindAllStores();
        return GenericResponseController.Handler(response);
    }
    
    [HttpGet]
    [Route("find-by-id/{id:guid}")]
    public async Task<IActionResult> FindStoreById([FromRoute] string id)
    {
        var response = await _storeService.FindStoreById(id);
        return GenericResponseController.Handler(response);
    }
}