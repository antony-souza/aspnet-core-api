using AutoMapper;
using BackendAspNet.modules.user.dto;
using BackendAspNet.modules.user.entity;

namespace BackendAspNet.mappings;

public class MappingDtoForEntityProfile : Profile
{
    public MappingDtoForEntityProfile()
    {
        CreateMap<UserEntity, UpdateUserDto>().ReverseMap();
    }
}