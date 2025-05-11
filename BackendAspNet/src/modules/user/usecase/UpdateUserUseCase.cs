using BackendAspNet.context;
using BackendAspNet.core.interfaces;
using BackendAspNet.modules.user.dto;
using BackendAspNet.utils;
using Microsoft.EntityFrameworkCore;

namespace BackendAspNet.modules.user.usecase;

public class UpdateUserUseCase
{
    private readonly AppDbContext _appDbContext;

    public UpdateUserUseCase(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<ApiResponse> Handler(UpdateUserDto dto)
    {
        var existingUser = await _appDbContext.User.FirstOrDefaultAsync(u => u.Id == dto.Id);

        if (existingUser != null)
        {
            return ApiResponse.ErrorResponse("User not found!");
        }
        
        if (dto.Password != null)
        {
            var newPassword = HashPasswordUtil.Hash(dto.Password);
        }
        
        return ApiResponse.SuccessResponse("User successfully updated!");
    }
}