using BackendAspNet.context;
using BackendAspNet.core.contracts;
using BackendAspNet.core.interfaces;
using BackendAspNet.modules.user.entity;
using BackendAspNet.modules.user.dto;
using BackendAspNet.utils;
using Microsoft.EntityFrameworkCore;

namespace BackendAspNet.modules.user.usecase;

public class CreateUserUseCase : IUseCaseContract<UserDto>
{
    private readonly AppDbContext _appDbContext;
        
    public CreateUserUseCase(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<ApiResponse> Handler(UserDto userDto)
    {
        var existingUser = await _appDbContext.User.FirstOrDefaultAsync(u => u.Email == userDto.Email);

        if (existingUser != null)
        {
            return new ApiResponse
            {
                Message = "Oops!",
                Errors = ["User already exists!"]
            };
        }

        var user = new UserEntity()
        {
            Name = userDto.Name,
            Email = userDto.Email,
            Password =  HashPasswordUtil.Hash(userDto.Password)
        };
        
        await _appDbContext.User.AddAsync(user);
        await _appDbContext.SaveChangesAsync();

        return new ApiResponse
        {
            Message = "User created successfully!"
        };
    }
}