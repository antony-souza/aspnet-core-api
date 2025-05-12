using BackendAspNet.context;
using BackendAspNet.core.interfaces;
using BackendAspNet.modules.user.dto;
using BackendAspNet.modules.user.entity;
using BackendAspNet.utils;
using Microsoft.EntityFrameworkCore;

namespace BackendAspNet.modules.user;

public class UserServices
{
    private readonly AppDbContext _appDbContext;
    
    public UserServices(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<ApiResponse> FindAllUsers()
    {
        var users = await _appDbContext.User.Select((u) => new
        {
            u.Id,
            u.Name,
            u.Email,
        }).ToListAsync();

        return users.Count == 0 ? ApiResponse.ErrorResponse("Users not found!") : ApiResponse.SuccessResponse(users);
    }
    
    public async Task<ApiResponse> CreateUser(CreateUserDto dto)
    {
        var existingUser = await _appDbContext.User.FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (existingUser != null)
        {
            return ApiResponse.ErrorResponse("User already exists!");
        }

        var user = new UserEntity()
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