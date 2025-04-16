using BackendAspNet.context;
using BackendAspNet.core.contracts;
using BackendAspNet.core.interfaces;
using BackendAspNet.modules.auth.dto;

namespace BackendAspNet.modules.auth.usecase;

public class AuthUseCase : IUseCaseContract<AuthDto>
{
    private readonly AppDbContext _appDbContext;
    
    public AuthUseCase(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Task<ApiResponse> Handler(AuthDto authDto)
    {
        throw new NotImplementedException();
    }
    
}