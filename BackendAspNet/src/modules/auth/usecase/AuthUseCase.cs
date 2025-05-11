using BackendAspNet.context;
using BackendAspNet.core.interfaces;
using BackendAspNet.core.services;
using BackendAspNet.modules.auth.dto;

using BackendAspNet.utils;
using Microsoft.EntityFrameworkCore;

namespace BackendAspNet.modules.auth.usecase;

public class AuthUseCase
{
    private readonly AppDbContext _appDbContext;

    public AuthUseCase(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ApiResponse> Handler(AuthDto dto)
    {
        var existingUser = await _appDbContext.User.FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (existingUser == null)
        {
            return ApiResponse.ErrorResponse("Invalid email or password");
        }

        var isPasswordValid = HashPasswordUtil.Verify(dto.Password, existingUser.Password);

        if (!isPasswordValid)
        {
            return ApiResponse.ErrorResponse("Invalid password!");
        }
        
        var token = new JwtService().GenerateToken(existingUser.Id);

        return ApiResponse.SuccessResponse(token);
    }
}