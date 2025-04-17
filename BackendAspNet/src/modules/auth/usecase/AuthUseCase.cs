using BackendAspNet.context;
using BackendAspNet.core.contracts;
using BackendAspNet.core.interfaces;
using BackendAspNet.core.services;
using BackendAspNet.modules.auth.dto;
using BackendAspNet.utils;
using Microsoft.EntityFrameworkCore;

namespace BackendAspNet.modules.auth.usecase;

public class AuthUseCase : IUseCaseContract<AuthDto>
{
    private readonly AppDbContext _appDbContext;

    public AuthUseCase(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ApiResponse> Handler(AuthDto authDto)
    {
        var existingUser = await _appDbContext.User.FirstOrDefaultAsync(u => u.Email == authDto.Email);

        if (existingUser == null)
        {
            return new ApiResponse
            {
                Message = "Oops!",
                Errors = ["User not found!"]
            };
        }

        var isPasswordValid = HashPasswordUtil.Verify(authDto.Password, existingUser.Password);

        if (!isPasswordValid)
        {
            return new ApiResponse
            {
                Message = "Oops!",
                Errors = ["Password is invalid!"]
            };       
        }


        var token = new JwtService().GenerateToken(existingUser.Id);

        return new ApiResponse
        {
            Message = "User authenticated successfully!",
            Data = token
        };
    }
}