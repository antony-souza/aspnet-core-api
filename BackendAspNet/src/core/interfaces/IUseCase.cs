using BackendAspNet.core.contracts;

namespace BackendAspNet.core.interfaces;

public interface IUseCaseContract<T>
{
    Task<ApiResponse> Handler(T args);
}