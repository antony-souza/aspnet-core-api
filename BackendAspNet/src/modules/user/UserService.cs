using System.Security.Cryptography.X509Certificates;
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
        var users = await _appDbContext.User
            .Include(u => u.Store)
            .Where(u => u.Enabled == true)
            .Select((u) => new
            {
                u.Id,
                u.Name,
                u.Email,
                store = u.Store.Name,
                
            })
            .ToListAsync();

        return users.Count == 0 ? ApiResponse.ErrorResponse("Users not found!") : ApiResponse.SuccessResponse(users);
    }

    public async Task<ApiResponse> FindUserById(string id)
    {
        var user = await _appDbContext.User
            .Include(u => u.Store)
            .Where(u => u.Id == id && u.Enabled == true)
            .Select(u => new
            {
                u.Id,
                u.Name,
                u.Email,
                store = u.Store.Name,
            })
            .ToListAsync();

        return user.Count == 0 ? ApiResponse.ErrorResponse("User not found!") : ApiResponse.SuccessResponse(user);
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
            Password = HashPasswordUtil.Hash(dto.Password),
            StoreId = dto.StoreId
        };

        await _appDbContext.User.AddAsync(user);
        await _appDbContext.SaveChangesAsync();

        return ApiResponse.SuccessResponse("User created!");
    }

    public async Task<ApiResponse> UpdateUser(string id, UpdateUserDto dto)
    {
        var checkUserById = await _appDbContext.User.FirstOrDefaultAsync(u => u.Id == id && u.Enabled == true);
        if (checkUserById == null)
        {
            return ApiResponse.ErrorResponse("User not found!");
        }

        if (!string.IsNullOrEmpty(dto.Name))
        {
            checkUserById.Name = dto.Name;
        }

        if (!string.IsNullOrEmpty(dto.Email))
        {
            checkUserById.Email = dto.Email;
        }

        if (!string.IsNullOrEmpty(dto.Password))
        {
            checkUserById.Password = HashPasswordUtil.Hash(dto.Password);
        }

        await _appDbContext.SaveChangesAsync();

        return ApiResponse.SuccessResponse("User updated!");
    }

    public async Task<ApiResponse> DeleteUser(string id)
    {
        var user = await _appDbContext.User.FirstOrDefaultAsync(u => u.Id == id && u.Enabled == true);
        if (user == null)
        {
            return ApiResponse.ErrorResponse("User not found!");
        }

        user.Enabled = false;
        await _appDbContext.SaveChangesAsync();

        return ApiResponse.SuccessResponse("User deleted!");
    }
}