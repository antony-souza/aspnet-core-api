using BackendAspNet.context;
using BackendAspNet.modules.user.entity;
using BackendAspNet.modules.user.dto;
using BackendAspNet.utils;
using Microsoft.EntityFrameworkCore;

namespace BackendAspNet.modules.user.usecase;

public class CreateUserUseCase
{
    private readonly AppDbContext _appDbContext;
        
    public CreateUserUseCase(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<ApiResponse> Handler(CreateUserDto dto)
    {
        var existingUser = await _appDbContext.User.FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (existingUser != null)
        {
            return ApiResponse.ErrorResponse("User already exists!");
        }

        var user = new UserEntity
        {
            Name = dto.Name,
            Email = dto.Email,
            Password =  HashPasswordUtil.Hash(dto.Password)
        };
        
        await _appDbContext.User.AddAsync(user);
        await _appDbContext.SaveChangesAsync();

        return ApiResponse.SuccessResponse("User created!");
    }
}